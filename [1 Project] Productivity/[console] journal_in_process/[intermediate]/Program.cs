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
using static System.Runtime.InteropServices.JavaScript.JSType;

class JournalApp
{
    static void Main(){
        Journal();
    }

    static void Journal()
    {
        Console.WriteLine("Welcome to the Journal App!");

        Console.WriteLine("1.Add a new journal entry");
        Console.WriteLine("2.View all entries");
        Console.WriteLine("3.Filter entries by date");
        Console.WriteLine("4.Export entries to a file");
        Console.WriteLine("5.Exit");
        Console.Write("Choose an option: ");

        do
        {
            string? option = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(option?.Trim())){
                
                if(int.TryParse(option, out int result)){
                    switch(result){
                        case 1:
                            AddNewEntry();
                            break;
                        case 2:
                            ViewAllEntries();
                            break;
                        case 3:
                            FilteringEntries();
                            break;
                        case 4:
                            ExportEntries();
                            break;
                        case 5:                            
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

    private static void ExportEntries()
    {
        throw new NotImplementedException();
    }

    private static void FilteringEntries()
    {
        throw new NotImplementedException();
    }

    private static void ViewAllEntries()
    {
        throw new NotImplementedException();
    }

    private static void AddNewEntry()
    {
        throw new NotImplementedException();
    }
}