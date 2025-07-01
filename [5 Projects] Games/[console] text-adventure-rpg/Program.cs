// Text Adventure Game – "Rogue Console RPG"
// Player exploring a dungeon-like world, fighting enemies, looting, and managing inventory.

/*
 Key Features
•	Player has health, inventory, gold, weapons
•	Enemies have random health/damage
•	Loot: weapons, potions, gold
•	Choices affect outcome
•	Random encounters and items

User Interactions:
•	Choose character name
•	Choose actions in the world (fight, explore, inventory, rest)
•	Fight a monster (random HP/attack, turn-based)
•	Pick up items and use them
•	Save/Load game

Learn by Doing This
•	Control Flow: if, switch, while, for
•	User Input & Output: Console.ReadLine, menus, decision-making
•	Collections: List<T>, Dictionary<T, T>, maybe arrays
•	Basic Algorithms: turn-based combat, inventory management
•	Data Types & Parsing: int, string, bool, Random, etc.
•	File I/O (optional): Save/load game progress (JSON)
•	DRY & Method Extraction: Write reusable functions
•	Data Validation: Don't crash when user types garbage
•	Text Formatting & UI: Make it readable, immersive
•	Design Thinking: Setting up for later OOP (classes like Player, Enemy, etc.) 
 */

using System.Text.Json;
const string PATH = "monsters-library.json";
const string PROMPTS_YES = "y";
const string PROMPTS_NO = "n";

string character = CharacterCreation();
MainMenu();
int characterAction = IsIntegerValid("> ");

void CombatEncounter(int action, string character)
{
    switch(character){
        case nameof(PlayerClasses.Warrior):
            Console.WriteLine("");
            break;
        case nameof(PlayerClasses.Mage):
            Console.WriteLine("");
            break;
        case nameof(PlayerClasses.Rogue):
            Console.WriteLine("");
            break;
        default:
            Console.WriteLine("");
            break;
    }
}

string GetPath(){
    if(!File.Exists(PATH)){
        ResetJSONFile();
    }
    return PATH;
}

void ResetJSONFile()
{
    bool coruptedFile = false;
    while(!coruptedFile){
        Console.WriteLine("JSON file corrupted do you want reset the file? [y/n]: ");
        var resetFile = Console.ReadLine()?.ToLower();

        if (resetFile == PROMPTS_YES)
        {
            File.WriteAllText(PATH, JsonSerializer.Serialize(new List<Dictionary<string, object>>()));
            coruptedFile = true;
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

int Randomizer(int monsterList){
    Random random = new Random();
    return random.Next(monsterList);
}

Dictionary<string, object> GetMonster(){

    // implement random pic monster
    // dictionary with monster type, health and dmg

    var getFile = File.ReadAllText(GetPath());
    var monsterList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(getFile);

    int selectedMonster = Randomizer(monsterList.Count);

    return monsterList[selectedMonster];
}

void LootingSystem(){

}

void InvertoryMenu(){

}

void MainMenu()
{           
    List<string> list = new List<string>()
    {
        "Explore the Forest",
        "Visit the Village",
        "Check Inventory",
        "Rest",
        "Save and Quit",
    };

    for (int i = 0; i < list.Count; i++)
    {
        Console.WriteLine($"{i+1}.{list[i]}");
    }
}

string CharacterCreation(){

    string? characterClass = null;
    string? playerName = IsStringValid("Welcome, brave one! What's your name? ");
    
    Console.WriteLine("Choose your class: ");
    // Display in console all available classes to play
    foreach (var playerClass in Enum.GetValues(typeof(PlayerClasses)))
    {
        Console.WriteLine($"{(int)playerClass}.{playerClass}");
    }

    bool classSelection = false;
    while (!classSelection)
    {        
        var selectedClass = IsStringValid("> ");

        // Check if user entered int value and check if the value exist in Enum
        if (int.TryParse(selectedClass, out int result) && Enum.IsDefined(typeof(PlayerClasses), result))
        {
            characterClass = Enum.GetName(typeof(PlayerClasses), result ); // Get the string name of the player class
            classSelection = true;
        }
        else
        {
            Console.WriteLine("Please choose one of classes.");
        }
    }

    Console.WriteLine("You are Ardin the Warrior. Your journey begins...");

    return characterClass; // Return player class as string
}

// helper function for validation of string values
string IsStringValid(string text){
  
    while(true){
        Console.Write(text);
        string? textInput = Console.ReadLine();

        if (string.IsNullOrEmpty(textInput)){
            continue;
        }

        return textInput;
    }
}

int IsIntegerValid(string text){
  
    while(true){
        Console.Write(text);
        string? textInput = Console.ReadLine();
        
        if (!int.TryParse(textInput, out int value) && string.IsNullOrEmpty(textInput)){
            continue;
        }

        return value;  
    }
}


Console.ReadLine();

enum PlayerClasses
{
    Warrior = 1,
    Mage,
    Rogue,
};
