/*
    * add new file (one file for each class for production code)
    * move classes to their own files
    * namespaces
    * using directives
    * file-scoped namespaces declaration
 */

// import the class using directive by the word using and the same of namespace for 'StringTextualRepository'
// 'using' directives need to be at the top of the file
using _single_responsibility_principle.DataAccess;

var names = new Names(); // we didn't have to use directive as 'Names' class belongs to global namespace
// The types from the same namespace always see each other, so we don't need to write any using directive to use the Names class here.

var path = new NamesFilePathBuilder().BuildFilePath();

var stringsTextualRepository = new StringTextualRepository();

if (File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names.");
   
    var stringFromFile = stringsTextualRepository.Read(path);
   
    names.AddNames(stringFromFile);
}
else
{
    Console.WriteLine("Names file does not yet exist.");
      
    names.AddName("Martin");
    names.AddName("not a valid name");
    names.AddName("Alan");
    names.AddName("123 definitely not a valid name");

    Console.WriteLine("Saving names to the file.");
    stringsTextualRepository.Write(path, names.All); 
}

Console.WriteLine(new NamesFormatter().Format(names.All));

Console.ReadLine();