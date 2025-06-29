/*
    Description: Add, remove, mark complete/incomplete tasks, and save/load from a file.
    User Interaction:
   
    1. Add Task
    2. View Tasks
    3. Mark Complete
    4. Delete Task
    5. Exit
    > Enter your choice:

    C# Concepts:
    •	Lists
    •	Loops
    •	Input validation
    •	File I/O (JSON or text)
    •	Simple status toggle logic
 */
using System.Text.Json;

const string FILENAME = "to-do-list.json";
const string TASK_STATUS_COMPLETED = "x";
const string TASK_STATUS_UNCOMPLETED = "";
const string PROMPTS_YES = "y";
const string PROMPTS_NO = "n";

StartApp();

void StartApp()
{
    var jsonContent = new List<Dictionary<string, string>>();
    try
    {
        jsonContent = ReadFile(GetFilePath());
    }
    catch (JsonException ex)
    {
        ResetJSONFile();
    }

    bool displayMenu = true;
    while (true)
    {
        if (displayMenu)
        {
            Menu();
            MenuOptions(jsonContent);
        }

        Console.Write(Environment.NewLine + "Do you want to continue [y/n]?: ");
        var userinput = Console.ReadLine();

        if (userinput == PROMPTS_YES)
        {
            Console.Clear();
            displayMenu = true;
            continue;
        }
        else if (userinput == PROMPTS_NO)
        {
            Environment.Exit(0);
        }
        else
        {
            displayMenu = false;
            Console.WriteLine(Environment.NewLine + "Please enter Yes[y] or No[n].");
        }
    }
}

void Menu()
{
    var menu = new List<string>()
    {
        "Add Task",
        "View Tasks",
        "Edit Task",
        "Mark Task",
        "Delete Task",
        "Exit",
    };

    Console.WriteLine();

    for (int i = 0; i < menu.Count; i++)
    {
        Console.WriteLine($"{i + 1}.{menu[i]}");
    }
}

void MenuOptions(List<Dictionary<string, string>> currentContent)
{

    while (true)
    {
        int userInput = InputNumericValidation("Enter your choice: ");

        switch (userInput)
        {
            case 1:
                AddTask(currentContent);
                return;
            case 2:
                ViewTasks(currentContent);
                return;
            case 3:
                EditTask(currentContent);
                return;
            case 4:
                MarkTask(currentContent);
                return;
            case 5:
                DeleteTask(currentContent);
                return;
            case 6:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine($"Please enter values between {((int)global::Menu.Add)} and {((int)global::Menu.Exit)}.");
                break;
        }
    }
}

int InputNumericValidation(string text)
{
    Console.Write(Environment.NewLine + text);
    var userInput = Console.ReadLine();

    if (!string.IsNullOrEmpty(userInput) && int.TryParse(userInput, out int result))
    {
        return result;
    }

    return 0;
}

string? InputTextValidation(string text)
{
    Console.Write(Environment.NewLine + text);
    var userInput = Console.ReadLine();

    if (!string.IsNullOrEmpty(userInput))
    {
        return userInput;
    }

    return null;
}

void AddTask(List<Dictionary<string, string>> currentContent)
{
    bool addTask = false;
    while (!addTask)
    {
        var userInput = InputTextValidation("Add new task: ");

        if (userInput != null)
        {
            currentContent.Add(new Dictionary<string, string>() { { userInput, "" } });
            addTask = true;
        }
        else
        {
            Console.WriteLine("Please enter text.");
        }

    }

    SaveToFile(FILENAME, currentContent);
    Console.WriteLine("Task added!");
}

void ViewTasks(List<Dictionary<string, string>> currentContent)
{
    if (currentContent.Count > 0)
    {
        TableHeader();
        for (int i = 0; i < currentContent.Count; i++)
        {
            foreach (var (description, taskCompletion) in currentContent[i])
            {
                Console.WriteLine($"{FormatText((i + 1).ToString(), 2)} | {FormatText(description, -55)} | {FormatText(taskCompletion, 5)} ");
            }
        }
    }
    else
    {
        DisplayNoTasksMessage();
    }
}

void EditTask(List<Dictionary<string, string>> currentContent)
{
    if (currentContent.Count > 0)
    {
        int id = InputNumericValidation("Please enter ID of the task: ");

        if (id <= currentContent.Count && id > 0)
        {
            string updateTaskDescription = "";
            string updateTaskState = "";

            int index = id - 1;

            var taskDescription = string.Join(" ", currentContent[index].Keys.ToList());

            Console.WriteLine(Environment.NewLine + $"Current task description: {taskDescription}");

            var editTaskDescription = InputTextValidation("Enter new description (or press Enter to keep current):");

            if (!string.IsNullOrWhiteSpace(editTaskDescription))
            {
                updateTaskDescription = editTaskDescription;
            }

            var taskState = string.Join(" ", currentContent[index].Values.ToList());

            Console.WriteLine(Environment.NewLine + $"Current task state: {(taskState.Length > 0 ? taskState + " (completed)" : "not set")}");

            while (true)
            {
                Console.Write($"Do you want change task status to {(taskState.Length > 0 ? "UNSET" : "SET")}? [y/n]: ");
                var editTaskState = Console.ReadLine();

                if (editTaskState == PROMPTS_YES)
                {
                    updateTaskState = taskState.Length > 0 ? TASK_STATUS_UNCOMPLETED : TASK_STATUS_COMPLETED;

                    currentContent[index][taskDescription] = updateTaskState;
                    break;
                }
                else if (editTaskState == PROMPTS_NO)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "Please choose either Yes[y] or No[n]" + Environment.NewLine);
                }
            }

            if (updateTaskDescription.Length > 0)
            {
                currentContent.Remove(currentContent[index]);

                currentContent.Insert(index, new Dictionary<string, string>(){
                    {
                        updateTaskDescription, updateTaskState
                    }
                });
            }

            SaveToFile(FILENAME, currentContent);

        }
        else
        {
            IsValidId(currentContent.Count);
        }
    }
    else
    {
        DisplayNoTasksMessage();
    }
}

void TableHeader()
{
    Console.WriteLine(Environment.NewLine + $"ID | {FormatText("Description", -55)} | Completed");
    var tableDivider = Enumerable.Repeat("-", 75);
    foreach (var divider in tableDivider)
    {
        Console.Write(divider);
    }
    Console.WriteLine();
}

void MarkTask(List<Dictionary<string, string>> currentContent)
{
    if (currentContent.Count > 0)
    {
        int markID = InputNumericValidation("Please enter task id: ");
        string? markTask = default;

        if (markID <= currentContent.Count && markID > 0)
        {
            int index = markID - 1;
            var currentKey = currentContent[index].Keys.First();

            if (!currentContent[index].ContainsValue(TASK_STATUS_COMPLETED))
            {
                currentContent[index][currentKey] = TASK_STATUS_COMPLETED;
                markTask = $"Task ID:{markID} marked as completed";
            }
            else
            {
                currentContent[index][currentKey] = TASK_STATUS_UNCOMPLETED;
                markTask = $"Task ID:{markID} marked as uncompleted";
            }

            SaveToFile(FILENAME, currentContent);
            Console.WriteLine(markTask);

        }
        else
        {
            IsValidId(currentContent.Count);
        }
    }
    else
    {
        DisplayNoTasksMessage();
    }
}

void DeleteTask(List<Dictionary<string, string>> currentContent)
{
    if (currentContent.Count > 0)
    {
        int deleteID = InputNumericValidation("Please enter task id to delete: ");

        if (deleteID <= currentContent.Count && deleteID > 0)
        {
            int index = deleteID - 1;

            currentContent.RemoveAt(index);

            SaveToFile(FILENAME, currentContent);
            Console.WriteLine("Task removed!");
        }
        else
        {
            IsValidId(currentContent.Count);
        }
    }
    else
    {
        DisplayNoTasksMessage();
    }
}

void DisplayNoTasksMessage() => Console.WriteLine("No current tasks.");

void IsValidId(int count) => Console.WriteLine($"Invalid ID. Please enter a number between 1 and {count}.");

string FormatText(string text, int textAlign)
{
    var format = $"{{0,{textAlign}}}";
    return string.Format(format, text);
}

void ResetJSONFile()
{
    bool corruptedFile = false;
    while (!corruptedFile)
    {
        Console.Write($"JSON file corrupted do you want reset the file? [y/n]: ");

        var resetFile = Console.ReadLine()?.ToLower();

        if (resetFile == PROMPTS_YES)
        {
            File.WriteAllText(FILENAME, JsonSerializer.Serialize(new List<Dictionary<string, string>>()));
            corruptedFile = true;
        }
        else if (resetFile == PROMPTS_NO)
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine(Environment.NewLine + "Please choose options Yes [y] or No [n]." + Environment.NewLine);
        }
    }

    Console.Clear();
}

string GetFilePath()
{

    if (!File.Exists(FILENAME))
    {
        ResetJSONFile();
    }

    return FILENAME;
}

List<Dictionary<string, string>> ReadFile(string filePath)
{
    try
    {
        string existingContent = File.ReadAllText(filePath);

        var convertExistingDataToObject = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(existingContent);
        return convertExistingDataToObject;

    }
    catch (JsonException ex)
    {
        throw;
    }
}

void SaveToFile(string path, List<Dictionary<string, string>> updatedContent)
{

    var options = new JsonSerializerOptions { WriteIndented = true };

    string newEntry = JsonSerializer.Serialize(updatedContent, options);

    File.WriteAllText(path, newEntry);
}

enum Menu
{
    Add = 1,
    View,
    Edit,
    Mark,
    Delete,
    Exit,
}