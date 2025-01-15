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
        Console.ResetColor();
        Console.WriteLine("Welcome to the Journal App!");
        Journal();
    }

    static void Journal()
    {
        do{
            MainMenu();

            Console.Write("Choose an option: ");

            Console.ForegroundColor = ConsoleColor.Red;
            string? options = Console.ReadLine();
            Console.ResetColor();

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
                    Console.Write("Invalid option. Please choose between 1 and 5: ");
                }                            

                // exit the loop
                if (result == 5){
                    break;
                }

            }else{
                Console.WriteLine("Option cannot be empty");
            }           

        } while (true);        
    }

    static void ExportEntries()
    {
        Console.WriteLine("\nExport Entries not implemented yet.");
        ClearScreen();
    }

    static void FilterEntries()
    {
        Console.WriteLine("\nFiltering Entries not implemented yet.");
        ClearScreen();
    }

    static void ViewAllEntries()
    {
        Console.WriteLine("\nView All Entries not implemented yet.");
        ClearScreen();
    }

    static void AddNewEntry()
    {        
        string entryDescription = NonEmptyInput("Enter your journal entry:");   

        // add description entry to the file if is not existing, create one 

        string entryTag = NonEmptyInput("Would you like to add a tag to this entry? [y/n]: ").ToLower();

        if (entryTag == "y")
        {
            string entryTagList = NonEmptyInput("Enter a tag or multiple tags separated by commas: ").ToLower();
            
            // add tags to the entry description / file
            
        }

        Console.WriteLine("\nEntry added successfully!");
        ClearScreen();
    }

    static string NonEmptyInput(string prompt){
        do
        {
            Console.WriteLine($"\n{prompt}");
            Console.Write("> ");
            string? input = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(input)){
                return input;
            }else{
                Console.WriteLine("Input cannot be empty.");
            }
        } while (true);
    }

    static void ClearScreen(){        
        Thread.Sleep(1000);
        Console.Clear();
    }

    static void MainMenu(){
        string[] menu = {"Add a new journal entry", "View all entries", "Filter entries by date", "Export entries to a file", "Exit"
            };

        for (int i = 0; i < menu.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{i + 1}. ");
            Console.ResetColor();
            Console.WriteLine(menu[i]);
        }        
    }

}