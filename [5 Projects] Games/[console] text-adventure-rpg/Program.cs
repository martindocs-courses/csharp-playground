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
Console.WriteLine(CharacterCreation());

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


Console.ReadLine();

enum PlayerClasses
{
    Warrior = 1,
    Mage,
    Rogue,
};
