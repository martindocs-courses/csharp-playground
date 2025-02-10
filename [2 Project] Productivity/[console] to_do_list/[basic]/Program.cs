/*
    Author: Marcin Tatarski
    Description: A console app that lets users manage a simple list of tasks.

    Level: Basic

    Concepts: Loops, Arrays, Input/output operations.
    
    Features:  
    * Add, view, and remove tasks  
    
    Notes:  
    * This code is written to demonstrate basic syntax and array manipulation.
    * It uses dynamic resizing of arrays, which is less efficient but helps
      to explore how arrays can be resized and managed in C#.
    * For real-world applications, consider using more efficient data structures
      like List<T> or other collections from the System.Collections.Generic namespace.
 */

using System.Diagnostics;
using System;
using System.Linq;

string[] tasks = new string[0];
bool exit = false;

do{
    Console.WriteLine("\n1. Add Task");
    Console.WriteLine("2. View Tasks");
    Console.WriteLine("3. Remove Tasks");
    Console.WriteLine("4. Quit");
    Console.Write("Select an option: ");

    string? userInput = Console.ReadLine();

    if(userInput != null){
        if(int.TryParse(userInput, out int result)){            
            switch(result)
            {
                case 1:
                    AddTasks();
                    break;
                case 2:
                    ViewTasks();
                    break;
                case 3:
                    RemoveTask();
                    break;
                case 4:
                    exit = true;
                    break;
            }                
        }
    }
}while(!exit);


void AddTasks(){
    Console.Write("Enter task description: ");
    string? description = Console.ReadLine();

    if(description != null)
    {
        Array.Resize(ref tasks, tasks.Length + 1);
        tasks[tasks.Length - 1] = $"{tasks.Length}.{description}";
    }
}

void ViewTasks(){
    Console.WriteLine("\nTasks: ");

    string[] taskList = SortTasks(tasks);

    if(taskList.Length > 0) {
        foreach (string task in taskList)
        {
            Console.WriteLine(task);
        }
    }
    else{
        Console.WriteLine("No tasks listed");
    }
}

void RemoveTask(){
    Console.Write("Which Tasks you've like to be removed [A]ll or specify the number: ");

    string? taskToRemove = Console.ReadLine();
    bool taskNumber = int.TryParse(taskToRemove, out int result);

    if (taskNumber)
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            if(tasks[i] != "0"){
                bool getTaskPosition = tasks[i].Trim().StartsWith(result.ToString());
                if (getTaskPosition)
                {
                    tasks[i] = "0";
                }            
            }
        }

    }else if (taskToRemove?.ToLower() == "a"){
        Array.Resize(ref tasks, 0);
    }
}

string[] SortTasks(string [] taskArray){
  
    string[] newTasks = taskArray
        /*
            Using LINQ to sort the order:
            - The OrderBy method sorts elements in ascending order based on the key 
            - in our kase key is 'task == "0"'
            - if the case is true then the true will be treated as a larger value, since true is considered "greater" than false in comparison and will be placed at the bottom
            - if the case will be false then is smaller value and will be placed at the top        
         */
        .OrderBy(task => task == "0") // order "0" at the end
        .ThenBy(task => task) // order non-zero values in ascending order
        .ToArray(); // convert back to array

    int emptyTasks = newTasks.Count(task => task == "0");
                   
    Array.Resize(ref newTasks, newTasks.Length - emptyTasks);     
    
    return newTasks;
}