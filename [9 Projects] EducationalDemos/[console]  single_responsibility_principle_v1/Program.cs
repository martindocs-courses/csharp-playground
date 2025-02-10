/* Navigation Notes
    
    Single responsibility principle                                 : line 12
    Before refactoring                                              : line 18 - 95
    After refactoring                                               : line 99 - 259   

    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/

/*
    SINGLE RESPOSIBILITY PRINCIPLE:
    * a class should be responsible for only one thing or that a class should have only one reason to change.
    * is one of five SOLID principle.
 */

/* BEFORE REACTORING */
#region Old code
/*
var names = new Names();
var path = names.BuildFilePath();

if (File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names.");
    names.ReadFromTextFile();
}
else
{
    Console.WriteLine("Names file does not yet exist.");

    // let's imagine they are given by the user
    names.AddName("Martin");
    names.AddName("not a valid name");
    names.AddName("Alan");
    names.AddName("123 definitely not a valid name");

    Console.WriteLine("Saving names to the file.");
    names.WriteToTextFile();
}
Console.WriteLine(names.Format());

Console.ReadLine();

 ** THIS CLASS HAS FIVE RESPONSIBILITIES **
public class Names
{
 ** 1 - WORKS AS CONTAINER FOR NAMES **
    private readonly List<string> _names = new List<string>();

    public void AddName(string name)
    {
        if (IsValidName(name))
        {
            _names.Add(name);
        }
    }

     ** 2 - HOW NAMES SHULD BE VALIDATED **
        private bool IsValidName(string name)
    {
        return
            name.Length >= 2 &&
            name.Length < 25 &&
            char.IsUpper(name[0]) &&
            name.All(char.IsLetter);
    }

     ** 3.1 - READING THE FILE **
        public void ReadFromTextFile()
    {
        var fileContents = File.ReadAllText(BuildFilePath());
        var namesFromFile = fileContents.Split(Environment.NewLine).ToList();
        foreach (var name in namesFromFile)
        {
            AddName(name);
        }
    }

     ** 3.2 - WRITING FROM FILE **
    public void WriteToTextFile() =>
        File.WriteAllText(BuildFilePath(), Format());

     ** 4 - BUILDING PATH OF THE FILE **
        public string BuildFilePath()
    {
        //we could imagine this is much more complicated
        //for example that path is provided by the user and validated
        return "names.txt";
    }

     ** 5 - FormatException A LIST OF NAMES **
        public string Format() =>
            string.Join(Environment.NewLine, _names);
}
*/
#endregion

/* AFTER REACTORING */
var names = new Names();

// (10b) File path builder in own class
//var path = names.BuildFilePath();
var path = new NamesFilePathBuilder().BuildFilePath();

// (7) Use Repository class for reading a file
var stringsTextualRepository = new StringTextualRepository();

if (File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names.");
    //names.ReadFromTextFile();
    var stringFromFile = stringsTextualRepository.Read(path);
    // (8a)add read strings and add to the collection of names
    names.AddNames(stringFromFile);
}
else
{
    Console.WriteLine("Names file does not yet exist.");

    //let's imagine they are given by the user
    names.AddName("Martin");
    names.AddName("not a valid name");
    names.AddName("Alan");
    names.AddName("123 definitely not a valid name");

    Console.WriteLine("Saving names to the file.");
    // names.WriteToTextFile();
    // (9a) to access private field we need to make it public available
    stringsTextualRepository.Write(path, names.All); // 'All' prop, be aware that having a <list> public, even if only for reading, is a risk as its. We could use a different type of collection here. Instead of a list, we could use one of the readonly.
}
// (11) Format the names in the console
//Console.WriteLine(names.Format());
Console.WriteLine(new NamesFormatter().Format(names.All));

Console.ReadLine();


public class Names
{

    // (9b) because _names are private we need create getter 
    //private readonly List<string> _names = new List<string>();
    public List<string> All { get; } = new List<string>();
  
    // (2b) create object once and store in private field in the name class
    private readonly NamesValidator _namesValidator = new NamesValidator();

    // (8b) method to add names that will do the same, but for a collection of strings.
    public void AddNames(List<string> stringFromFile)
    {
        foreach (var name in stringFromFile)
        {
            AddName(name);

            /* 
                NOTE1: 
                * When using methods inside other methods, the rule is that inside methods should be declared below outside methods. 
                * Public methods should be above private ones.             
             */
        }
    }

    public void AddName(string name)
    {
        // (2a) In this case is not good approach to create object every time the Add name is called 
        // if (new NamesValidator().IsValid(name))

        if (_namesValidator.IsValid(name))
        {
            //_names.Add(name);
            All.Add(name);
        }
    }

    // (1) MOVE VALIDATION METHOD TO OWN CLASS
    //private bool IsValidName(string name)
    //{
    //    return
    //        name.Length >= 2 &&
    //        name.Length < 25 &&
    //        char.IsUpper(name[0]) &&
    //        name.All(char.IsLetter);
    //}
  
    // (3) MOVE READ AND WRITE TEXT FILE TO SEPARATE CLASS
    //public void ReadFromTextFile()
    //{
    //    var fileContents = File.ReadAllText(BuildFilePath());
    //    var namesFromFile = fileContents.Split(Environment.NewLine).ToList();
    //    foreach (var name in namesFromFile)
    //    {
    //        AddName(name);
    //    }
    //}

    //public void WriteToTextFile() =>
    //    File.WriteAllText(BuildFilePath(), Format());


    // (10) MOVE TO SEPARATE CLASS
    //public string BuildFilePath()
    //{
    //    //we could imagine this is much more complicated
    //    //for example that path is provided by the user and validated
    //    return "names.txt";
    //}

    // (11) MOVE TO SEPARATE CLASS
    //public string Format() =>
    //   string.Join(Environment.NewLine, _names);
   
}
class NamesFilePathBuilder{
    public string BuildFilePath() => "names.txt";    
}

class NamesFormatter{
    public string Format(List<string> names) => string.Join(Environment.NewLine, names);
}

class NamesValidator
{
    public bool IsValid(string name)
    {
        return
            name.Length >= 2 &&
            name.Length < 25 &&
            char.IsUpper(name[0]) &&
            name.All(char.IsLetter);
    }
}

// Repositories are classes or components that encapsulate the logic required to access data sources.
class StringTextualRepository{
    // (6) EnvironmentNewLine as the separator
    //private const string Separator = Environment.NewLine; // this won't compile as is not compile-time const. As new line is different for Unix: "\n" and non Unix "\r\n" 

    private static readonly string Separator = Environment.NewLine; // 'static' it wont be duplicated between instances and 'readonly' to not be modified

    // (4a) Read from text file and return list of string as result
    // public void ReadFromTextFile()
    public List<string> Read(string filePath)
    {
        // (4b) Remove method for finding path and add parameter as filePath
        // var fileContents = File.ReadAllText(BuildFilePath());
        var fileContents = File.ReadAllText(filePath);
        return  fileContents.Split(Separator).ToList();
    }

    // (5a) The repository will be a class responsible for storing a collection of strings in a text file with the full awareness that each string is stored in a separate line of this file.
    // public void WriteToTextFile(string filePath, string textToBeSaved) =>
    public void Write(string filePath, List<string> strings) =>
        // (4b) Remove method for finding path and add parameter as filePath, and the text to be saved as a parameter.
        //File.WriteAllText(BuildFilePath(), Format());

        // (5b) Join this list of strings into a single string using the new line symbol as a separator.
        File.WriteAllText(filePath, string.Join(Separator, strings));
}
