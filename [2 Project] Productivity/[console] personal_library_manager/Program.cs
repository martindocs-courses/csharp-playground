/*
    Future enhancements:

    * Prompt User to Automatically Fix or Reset the corrupted JSON file.
    * Logging for Development all error messages to log file.
    * Add "Mark as Read/Unread" feature by tracking "Status" field.
    * Sort books by title or year before displaying.
    * Save last search.
    * Add a books lib backup before deleting it.
 
 */

using System.Text.Json;

// Program starts
ConsoleMessage("Welcome to Personal Library Manager");
ConsoleUI();

bool choice = false;
var currentBookContent = new List<Dictionary<string, string>>();

try
{
    currentBookContent = ReadFromFile();

    while (!choice)
    {       
        inputValidation("Enter your choice:", out string userInput);

        if (string.IsNullOrEmpty(userInput)) continue;

        if (userInput == "5")
        {
            choice = true;
            ConsoleMessage("Bye!");
        }
        else
        {
            switch (userInput)
            {
                case "1":
                    AddBook(currentBookContent);
                    break;
                case "2":
                    ViewAllBooks(currentBookContent);
                    break;
                case "3":
                    SearchBooks(currentBookContent);
                    break;
                case "4":
                    DeleteBook(currentBookContent);
                    break;
                default:
                    ConsoleMessage(Environment.NewLine + "Please choose between above options." + Environment.NewLine);
                    break;
            }
        }
    }
}
catch (JsonException ex)
{
    ConsoleMessage(Environment.NewLine + "Your library file is corrupted. Please fix or delete 'booksLibrary.json' and restart the app.");
}

// Add book
void AddBook(List<Dictionary<string, string>> currentContent)
{
    string[] bookData = new string[4] { "Title", "Author", "Year", "Genre" };
    Dictionary<string, string> genreList = new Dictionary<string, string>() {
        { "a","Adventure [a]" },
        { "f", "Fiction [f]" }, 
        { "n", "Novel [n]" }, 
        { "p", "Poetry [p]" }, 
        { "t", "Thriller [t]" }, 
        { "sf", "Science fiction [sf]" },
        { "h", "Horror [h]" },
    };
    Dictionary<string, string> newBook = new Dictionary<string, string>();

    ConsoleMessage(Environment.NewLine + "Please fill the following data");

    for (int i = 0; i < bookData.Length; i++)
    {
        string? userInput = "";
        bool bookEntry = false;

        while (!bookEntry)
        {
            if(bookData[i] != "Genre"){
                ConsoleMessage($"{bookData[i]}: ", oneLineMsg: true);            
            }else{
                ConsoleMessage($"{bookData[i]}: {string.Join(", ", genreList.Values)}: ", oneLineMsg: true);
            }

            userInput = Console.ReadLine()?.Trim();

            int bookYear = default;

            if (!string.IsNullOrEmpty(userInput))
            {
                switch(bookData[i]){
                    case "Title":
                    case "Author":
                        bookEntry = true;
                        break;
                    case "Year":
                        if (int.TryParse(userInput, out bookYear) && bookYear.ToString().Length == 4)
                        {
                            bookEntry = true;
                        }
                        else
                        {
                            ConsoleMessage("Please enter proper YEAR format");
                        }
                        break;
                    case "Genre":                        
                        if(genreList.ContainsKey(userInput.ToLower()) || genreList.ContainsValue(userInput))
                        {
                            bookEntry = true;
                        }else{
                            ConsoleMessage("Please enter proper GENRE format");
                        }
                        break;
                }
                
            }
        }

        if(bookData[i] != "Genre"){
            newBook.Add(bookData[i], userInput);        
        }else{
            newBook.Add(bookData[i], genreList[userInput].Split(" ")[0]);
        }

    }

    currentContent.Add(newBook);

    WriteToFile(currentContent);

    ConsoleMessage(Environment.NewLine + "New book added!");
}

void ViewAllBooks(List<Dictionary<string, string>> currentContent)
{
    if (currentContent.Count > 0)
    {
        // Get keys from the first dictionary to use as headers
        var headings = currentContent[0].Keys.ToList();

        // Add ID to table. Just for visual
        Console.Write("ID ");

        // headings: Title, Author, Year, Genre
        ConsoleMessage(string.Join("\t    ", headings));

        for (int i = 0; i < currentContent.Count; i++)
        {
            ConsoleMessage($"{i + 1}  ", oneLineMsg: true);
            foreach (var header in headings)
            {
                // Display each book details in a row
                ConsoleMessage($"{currentContent[i][header]?.PadRight(17)}", oneLineMsg: true);
            }

            ConsoleMessage();
        }

    }
    else
    {
        ConsoleMessage("Book library is empty!");
    }
}

void SearchBooks(List<Dictionary<string, string>> currentContent)
{

    if (currentContent.Count > 0)
    {
        bool book = false;
        while (!book)
        {            
            inputValidation("Find books by typing Title/Author/Year/Genre: ", out string findBook);

            if (string.IsNullOrEmpty(findBook)) continue;

            bool notFoundBooks = false;
            var foundBooks = new List<Dictionary<string, string>>();

            for (int i = 0; i < currentContent.Count; i++)
            {
                if (currentContent[i].ContainsValue(findBook))
                {
                    foundBooks.Add(currentContent[i]);
                }
                else
                {
                    notFoundBooks = true;
                }
            }

            if (foundBooks.Count > 0)
            {
                // Get keys from the first dictionary to use as headers
                var headings = currentContent[0].Keys.ToList();

                // headings: Title, Author, Year, Genre
                ConsoleMessage(Environment.NewLine + string.Join("\t\t", headings));

                // Display each book details in a row
                for (int i = 0; i < foundBooks.Count; i++)
                {
                    foreach (var header in headings)
                    {
                        ConsoleMessage($"{foundBooks[i][header]?.PadRight(16)}", oneLineMsg: true);
                    }

                    ConsoleMessage();
                }
            }
            else
            {
                ConsoleMessage(Environment.NewLine + "No books found.");
            }                        

            inputValidation(Environment.NewLine + "Another search? [y/n]: ", out string searchAgain);

            if (searchAgain == "y")
            {
                continue;
            }
            else if (searchAgain == "n")
            {
                book = true;
            }
        }
    }
    else
    {
        ConsoleMessage("There is no books in the Library!");
    }
}

void DeleteBook(List<Dictionary<string, string>> currentContent)
{

        if(currentContent.Count > 0){        

        inputValidation("Book to remove [ID]?: ", out string bookToRemove);

        if (!string.IsNullOrEmpty(bookToRemove) && int.TryParse(bookToRemove, out int value)){

            if(value <= currentContent.Count){
                currentContent.RemoveAt(value - 1);
                WriteToFile(currentContent);
                ConsoleMessage("Book successfully removed!!");        
            }
        }
    }else{
        ConsoleMessage("There is no books in the Library!");
    }
}

// Display Menu
void ConsoleUI()
{
    string[] menu = new string[5] {
                "Add a new book",
                "View all books",
                "Search books",
                "Delete a book",
                "Exit"
        };

    for (int i = 0; i < menu.Length; i++)
    {
        ConsoleMessage($"{i + 1}.{menu[i]}");
    }
}

string GetFilePath()
{
    List<Dictionary<string, string>> booksLibrary = new List<Dictionary<string, string>>();
    
    string fileName = "booksLibrary.json";

    if (!File.Exists(fileName))
    {
        // Write as indented
        var options = new JsonSerializerOptions { WriteIndented = true };

        // Converting to JSON format         
        string newJsonFile = JsonSerializer.Serialize(booksLibrary, options);

        File.WriteAllText(fileName, newJsonFile);
    }

    return fileName;    
}

void inputValidation(string text, out string? input){
    Console.Write(text);
    input = Console.ReadLine();
}

void ConsoleMessage(string msg = "", bool oneLineMsg = false){
    if(oneLineMsg){
        Console.Write(msg);
    }
    else{
        Console.WriteLine(msg);    
    }
};

List<Dictionary<string, string>> ReadFromFile(){

    string path = GetFilePath();
    var convertExistingDataObject = new List<Dictionary<string, string>>();

    try
    {
        string existingContent = File.ReadAllText(path);

        // Read from file back into object
        convertExistingDataObject = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(existingContent);
        return convertExistingDataObject;
    }
    catch(JsonException ex)
    {
        // Re-throw the exception instead of throw ex;, which preserves the original stack trace
        throw;
    }
}

void WriteToFile(List<Dictionary<string, string>> newBook)
{
    var path = GetFilePath();

    // Write as indented
    var options = new JsonSerializerOptions { WriteIndented = true };

    // Converting enumerable object to JSON format
    string newJSONEntry = JsonSerializer.Serialize(newBook, options);

    // File.WriteAllText(string path, string contents) - overwrites the file if exists or create new file if not existing    
    File.WriteAllText(path, newJSONEntry);     
}


