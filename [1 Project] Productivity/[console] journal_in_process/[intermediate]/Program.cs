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
    public enum MenuOptions
    {
        Add = 1,
        View = 2,
        Filter = 3,
        Export = 4,
        Exit = 5
    }

    static void Main(){        
        Journal();
    }

    static void Journal()
    {
        do{            
            MainMenu();

            Console.Write("Choose an option: ");                        
            string? options = Console.ReadLine();           

            if (!string.IsNullOrWhiteSpace(options?.Trim())){
                
                if(int.TryParse(options, out int result)){
                    switch(result){
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
                            break;
                    }
                }else{
                    
                    FormatMessage("\nInvalid option. Please choose between 1 and 5: ", "red");
                }                            

                // exit the loop
                if (result == (int)MenuOptions.Exit){
                    FormatMessage("\nGoodbye!!", "green");
                    break;
                }

            }else{
                FormatMessage("\nOption cannot be empty.", "red");
            }           

        } while (true);        
    }

    static void ExportEntries()
    {
        FormatMessage("\nExport Entries not implemented yet.", "red");
    }

    static void FilterEntries()
    {
        FormatMessage("\nFiltering Entries not implemented yet.", "red");
    }

    static void ViewAllEntries()
    {
        FormatMessage("\nView All Entries not implemented yet." , "red");
    }

    static void AddNewEntry()
    {        
        string entryDescription = NonEmptyInput("Enter your journal entry:", "Entry cannot be empty");   

        // add description entry to the file if is not existing, create one 

        string entryTag = NonEmptyInput("Would you like to add a tag to this entry? [y/n]: ", "Please answer the question [Y]es or [N]o.").ToLower();

        if (entryTag == "y")
        {
            string entryTagList = NonEmptyInput("Enter a tag or multiple tags separated by commas: ", "You need to have at least one tag.").ToLower();
            
            // add tags to the entry description / file
            
        }

        FormatMessage("\nEntry added successfully!", "green");
    }

    static string NonEmptyInput(string prompt, string errorMessage){
        do
        {
            Console.Clear();
            MainMenu();

            Console.WriteLine($"\n{prompt}");
            Console.Write("> ");
            string? input = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(input)){
                return input;
            }else{
                FormatMessage(errorMessage, "red");
            }
        } while (true);
    }

    static void ClearScreen(){        
        Thread.Sleep(1500);
        Console.Clear();
    }

    static void FormatMessage(string message, string colorMessage){

        ConsoleColor setColor;
        if(Enum.TryParse(colorMessage, true, out setColor)) {
            Console.ForegroundColor = setColor;
            Console.WriteLine(message);
            Console.ResetColor();        
        }
        ClearScreen();
    }

    static void MainMenu(){
        Console.WriteLine("Welcome to the Journal App!");

        string[] menu = {"Add a new journal entry", "View all entries", "Filter entries by date", "Export entries to a file", "Exit"
            };

        for (int i = 0; i < menu.Length; i++)
        {
            Console.Write($"{i + 1}. ");
            Console.WriteLine(menu[i]);
        }        
    }

}