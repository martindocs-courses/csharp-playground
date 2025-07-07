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

using System;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
const string PATH = "monsters-library.json";
const string PROMPTS_YES = "y";
const string PROMPTS_NO = "n";

var character = CharacterCreation();

// we need cast to Dictionary because the retrieved value from the outer dictionary is stored as object and C# doesn't know what type it really is at runtime unless we tell it.
var characterStats = (Dictionary<string, object>)character["characterStats"];
var characterName = character["characterName"];
var characterClass = character["characterClass"];
var characterHealth = characterStats["characterHP"];
var characterDamage = characterStats["characterDMG"];
var characterGold = characterStats["characterGold"];
var characterInventory = (Dictionary<string, int>)characterStats["characterInvertory"];

var monsterHealth = 0;


bool game = false;
while (!game)
{
    Console.WriteLine($"You are {characterName} the {characterClass}. Your journey begins...");
    MainMenu();
    int characterDecision = IsIntegerValid("> ");

    CharacterActions(characterDecision);    
}
Dictionary<string, object> BaseCharacterStats(string characterType){
    var baseStats = new Dictionary<string, object>()
    {
        {"characterHP" , 0},
        {"characterDMG" , 0},
        {"characterGold" , 0},
        {"characterWepons" , ""},
        {"characterInvertory" , new Dictionary<string, int>()},
    };
        
    switch (characterType)
    {
        case nameof(PlayerClasses.Warrior):
            baseStats["characterHP"] = 45;
            baseStats["characterDMG"] = 65;
            baseStats["characterGold"] = 0;
            baseStats["characterWepons"] = "old rusty sword";
            break;
        case nameof(PlayerClasses.Mage):
            baseStats["characterHP"] = 20;
            baseStats["characterDMG"] = 100;
            baseStats["characterGold"] = 0;
            baseStats["characterWepons"] = "tiny wand";           
            break;
        case nameof(PlayerClasses.Rogue):
            baseStats["characterHP"] = 35;
            baseStats["characterDMG"] = 70;
            baseStats["characterGold"] = 0;
            baseStats["characterWepons"] = "half broken dagger";          
            break;
    }

    return baseStats;
}

void CharacterActions(int actions)
{
    switch(actions)
    {
        case 1:
            bool encounterWin = CombatEncounter(GetRandomMonster());
            if(encounterWin == true){
                LootingSystem();
            }
            break;
        case 2:
            Console.WriteLine("Village");
            break;
        case 3:
            Invertory();
            break;
        case 4:
            Console.WriteLine("Rest");
            break;
        case 5:
            Console.WriteLine("Save and Quit");
            game = true;
            break;
        default:
            Console.WriteLine("Please choose options.");
            break;
    }

    Console.ReadLine();
    //Thread.Sleep(3000); // Keep the last character message action for 2sec. before clear the screen
    Console.Clear();
}

bool CombatEncounter(Dictionary<string, JsonElement> monster)
{
    var monsterType = monster["monsterType"].GetString();
    monsterHealth = monster["hp"].GetInt32();
    var monsterDMG = monster["dmg"].GetInt32();

    bool defetMonster = false;

    Console.WriteLine($"You encounter a {monsterType}!");
    Console.WriteLine($"{monster["monsterType"]} HP: {monsterHealth}"); 
    Console.WriteLine($"Your HP {characterHealth}!");

    bool monsterBattle = false;
    while(!monsterBattle)
    {
        Console.WriteLine(Environment.NewLine + "What will you do?");
        string[] options = new string[] { "Attack", "Use Potion", "Run" };

        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{i + 1}.{options[i]}");
        }

        int characterOptions = IsIntegerValid("> ");

        switch (characterOptions)
        {
            case 1: // Attack
                int yourDMG = Randomizer((int)characterDamage);
                int mobDMG = Randomizer(monsterDMG); // (int)monsterDMG throws an error because monster["dmg"] is a JsonElement, not an int.

                Console.WriteLine($"You strike for {yourDMG} damage!");
                Console.WriteLine($"{monsterType} hits you for {mobDMG} damage.");

                characterHealth = (int)characterHealth - mobDMG;
                monsterHealth = (int)monsterHealth - yourDMG;

                if((int)characterHealth < 0){
                    Console.WriteLine("You die!");                    
                    monsterBattle = true;
                    game = true; // End game
                    return defetMonster;
                }
                else if(monsterHealth > 0){
                    Console.WriteLine(Environment.NewLine + $"{monsterType} HP: {monsterHealth}");
                    Console.WriteLine($"Your HP: {characterHealth}");

                    Console.WriteLine(Environment.NewLine + "[... battle continues ...]");
                    continue;
                }

                Console.WriteLine($"You defeated the {monsterType}!");                
                monsterBattle = true;
                defetMonster = true;
                break;
            case 2: // use potion
                // TODO: Implement use the potion
                break;
            case 3: // Run
                monsterBattle = true;                
                break;
        }
    }
    return defetMonster;
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

int Randomizer(int count, int minCount = 0){
    Random random = new Random();
    return random.Next(minCount, count);
}

Dictionary<string, JsonElement> GetRandomMonster(){
    var getFile = File.ReadAllText(GetPath());

    // When deserialize JSON into a Dictionary<string, object>, System.Text.Json stores all values as JsonElement, not real primitives. You get JsonElement only when you deserialize to object. In this case, System.Text.Json doesn't know the specific types, so it puts everything as JsonElement, which is a flexible type that can represent any JSON value (number, string, object, array, etc.).
    // Use Dictionary<string, JsonElement> to avoid casting
    var monsters = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(getFile);

    int selectedMonster = Randomizer(monsters.Count);

    return monsters[selectedMonster];
}

void LootingSystem(){
    var lootLibrary = new Dictionary<string, int>()
    {
        // Weapons
        { "Rusted Iron Sword", 5 },
        { "Goblin Tooth Dagger", 7 },
        { "Enchanted Oak Staff", 12 },
        { "Crossbow of the Silent Hunt", 15 },
        { "Cracked Warhammer", 25 },
        { "Shadowfang Blade", 17 },
        { "Bone-handled Throwing Knife", 10 },
        { "Flaming Torch", 28 },
        { "Whispering Bow", 30 },
        { "Cursed Blacksteel Axe", 34 },
        // Potions 
        { "Health Potion (Minor)", 10 },          
        { "Health Potion (Major)", 20 },          
        { "Healing  Salve", 30 },          
    };
   
    var lootList = lootLibrary.ToList();
    int loot = Randomizer(lootList.Count);  

    int gold = Randomizer(50, 1);
    characterGold = (int)characterGold + gold;

    Console.WriteLine("Loot Found:");
    Console.WriteLine($"- {gold} Gold");
    Console.WriteLine($"- {lootList[loot].Key} (Damage: {lootList[loot].Value})");

    bool equipCHaracter = false;
    while(!equipCHaracter)
    {
        Console.WriteLine($"Add {lootList[loot].Key} to inventory? (Y/N)");

        string equip = IsStringValid("> ");
        if(equip == "y"){
            characterInventory.Add(lootList[loot].Key, lootList[loot].Value);
            Console.WriteLine("Inventory updated.");
            equipCHaracter = true;
        }else if (equip == "n")
        {
            return;
        }
        else
        {
            Console.WriteLine("Please enter Yes[y] or No[n].");
        }
    }

}

void Invertory(){
    
    Console.WriteLine("== Inventory ==");
    if(characterInventory.ToList().Count > 0){
        foreach (var (Key, Value) in characterInventory)
        {
            Console.WriteLine($"- {Key}");
        }

        while (true)
        {

            Console.WriteLine("1. Use Potion");
            Console.WriteLine("2. Equip Weapon");
            Console.WriteLine("3. Back");

            int invetoryUse = IsIntegerValid("> ");

            switch (invetoryUse)
            {
                case 1:
                    Console.WriteLine("You used a Health Potion. +10 HP.");
                    // TODO: implement add potion to character health
                    //characterHealth = (int)characterHealth + 10;
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Please choose options form the list.");
                    break;
            }
        }

    }
    else{
        Console.WriteLine("empty");
    }

    
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

Dictionary<string, object> CharacterCreation(){

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
            Console.WriteLine("Please choose one of available classes.");
        }
    }

    Console.Clear();

    //Console.WriteLine($"You are {playerName} the {characterClass}. Your journey begins...");

    return new Dictionary<string, object>(){
        { "characterName", playerName },
        { "characterClass", characterClass },
        { "characterStats", BaseCharacterStats(characterClass) },

    }; // Return player class object
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


//Console.ReadLine();

enum PlayerClasses
{
    Warrior = 1,
    Mage,
    Rogue,
};
