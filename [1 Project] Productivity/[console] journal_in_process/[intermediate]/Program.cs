/*
    Author: Marcin Tatarski
    Description: A simple journaling app.

    Level: Intermediate

    Concepts: 
    * Lists / Dictionaries
    * DateTime
    * Filtering
    * File I/O
    
    Features:  
    * Add a journal entry.
    * View past entries.
    * Filtering entries by date
    * Adds tagging
    * Export entries to a file    
 */

using System.Diagnostics;

class JournalApp
{
    // Enum to represent menu options for better readability and maintainability
    public enum MenuOptions
    {
        Add = 1,
        View = 2,
        Filter = 3,
        Export = 4,
        Exit = 5
    }

    static void Main(){
        // Start the Journal application
        Journal();
    }

    static void Journal()
    {
        // Display the main menu
        MainMenu();
        bool appRunning = true;

        do{
            
            string? options = Console.ReadLine();

            // Validate that the input is not null or whitespace
            if (!string.IsNullOrWhiteSpace(options?.Trim())){
                
                if(int.TryParse(options, out int result)){
                    // Handle the selected menu option
                    switch (result){
                        case (int)MenuOptions.Add:
                            AddNewEntry();                        
                            break;
                        case (int)MenuOptions.View:
                            ViewAllEntries();
                            break;
                        case (int)MenuOptions.Filter:
                            FilterEntries();
                            break;
                        case (int)MenuOptions.Export:
                            ExportEntries();
                            break;
                        case (int)MenuOptions.Exit:                            
                            break; // Exit the loop if Exit is chosen
                    }
                }else{
                    // Error message if the input is not a valid integer
                    FormatMessage("Invalid option. Please choose between 1 and 5: ", "red");
                }

                // Exit the loop when the Exit option is selected
                if (result == (int)MenuOptions.Exit){
                    appRunning = false;
                }

            }else{
                // Error message if the input is empty or whitespace
                FormatMessage("Option cannot be empty.", "red");
            }           

        } while (appRunning);        
        
        FormatMessage("\nGoodbye!!", "green");
    }

    static void ExportEntries()
    {
        // Placeholder for Export Entries
        FormatMessage("Export Entries not implemented yet.", "red");
    }

    static void FilterEntries()
    {
        // Placeholder for Filtering Entries
        FormatMessage("Filtering Entries not implemented yet.", "red");
    }

    static void ViewAllEntries()
    {
        // Placeholder for View All Entries
        FormatMessage("View All Entries not implemented yet." , "red");
    }

    static void AddNewEntry()
    {        
        string entryDescription = NonEmptyInput("Enter your journal entry:", "Entry cannot be empty");
        
        // add description entry to the file if is not existing, create one 
        AddTag();
        
        FormatMessage("\nEntry added successfully!", "green");

        Console.Clear();
        MainMenu();
    }

    static string NonEmptyInput(string prompt, string errorMessage){

        Console.WriteLine($"\n{prompt}");
        Console.Write("> ");

        do
        {  
            // Show the input prompt
            string? input = Console.ReadLine();

            // Validate that the input is not empty or whitespace
            if (!string.IsNullOrWhiteSpace(input)){
                return input;
            }else{
               
                // Show an error message if the input is invalid
                FormatMessage(errorMessage, "red");
                
            }
        } while (true);
    }

    //static void ClearScreen(string msg)
    //{
    //    // Wait for 2 seconds before clearing the console
    //    Thread.Sleep(2000);
    //    Console.Clear();  
    //}

    static void FormatMessage(string message, string colorMessage){
        // Save the current cursor position
        int currentLeft = Console.CursorLeft;
        int currentTop = Console.CursorTop;

        // Change the console text color based on the specified color message
        ConsoleColor setColor;
        if (Enum.TryParse(colorMessage, true, out setColor)) {
            Console.ForegroundColor = setColor;
            Console.Write(message);
            Console.ResetColor();        
        }
                    
        // Display messsage for 2000ms
        Thread.Sleep(2000);
       
        Console.SetCursorPosition(currentLeft, currentTop);
        Console.Write(new string(' ', message.Length));
        Console.SetCursorPosition(currentLeft, currentTop);
        Console.Write("> ");
    }

    static void MainMenu(){
        // Display a welcome message
        Console.WriteLine("Welcome to the Journal App!");

        // Define the menu options
        string[] menu = {
            "Add a new journal entry", 
            "View all entries", 
            "Filter entries by date", 
            "Export entries to a file", 
            "Exit"
        };

        // Display the menu options
        for (int i = 0; i < menu.Length; i++)
        {
            Console.Write($"{i + 1}. ");
            Console.WriteLine(menu[i]);
        }

        Console.WriteLine("Choose an option:");
        Console.Write("> ");
    }

    static void AddTag(){

        do
        {
            string entryTag = NonEmptyInput("Would you like to add a tag to this entry? [y/n]: ", "Please answer the question [Y]es or [N]o.").ToLower();
        
            if (entryTag == "y")
            {
                string entryTagList = NonEmptyInput("Enter a tag or multiple tags separated by commas: ", "You need to have at least one tag.").ToLower();

                // add tags to the entry description / file

                break;

            }else if (entryTag == "n"){
                return;            
            }else{
                FormatMessage("Please answer the question [Y]es or [N]o.", "red");
            }
            
        } while (true);   
        
    }

}