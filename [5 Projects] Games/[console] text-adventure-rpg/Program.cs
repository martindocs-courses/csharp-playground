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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
// will look for relative path in bin\Debug\netX.X\data.json.
//const string PATH = "monsters-library.json";
// Use relative path going up to the project root
const string PATH = @"..\..\..\GameData\monsters-library.json";
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
var characterWeapon = characterStats["characterWepon"];
var characterInvetory = (Dictionary<string, int>)characterStats["characterInvetory"];
var characterHealthPotions = characterStats["characterPotion"];

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
        {"characterWepon" , ""},
        {"characterPotion" , 0},
        {"characterInvetory", new Dictionary<string, int>() },
    };
        
    switch (characterType)
    {
        case nameof(PlayerClasses.Warrior):
            baseStats["characterHP"] = 50;
            baseStats["characterDMG"] = 15;
            baseStats["characterWepon"] = "Old Rusty Sword";
            break;
        case nameof(PlayerClasses.Mage):
            baseStats["characterHP"] = 30;
            baseStats["characterDMG"] = 25;
            baseStats["characterWepon"] = "Tiny Wand";           
            break;
        case nameof(PlayerClasses.Rogue):
            baseStats["characterHP"] = 40;
            baseStats["characterDMG"] = 20;
            baseStats["characterWepon"] = "Half Broken Dagger";          
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
    var characterCombatHP = characterHealth;
    var monsterType = monster["monsterType"].GetString();
    monsterHealth = monster["hp"].GetInt32();
    var monsterDMG = monster["dmg"].GetInt32();

    bool defetMonster = false;

    Console.WriteLine($"You enter the forest and encounter a {monsterType}!");
    Console.WriteLine($"{monster["monsterType"]} HP: {monsterHealth}, DMG: {monsterDMG} | Your HP: {characterCombatHP}, DMG: {characterDamage}");

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

                characterCombatHP = (int)characterCombatHP - mobDMG;
                monsterHealth = (int)monsterHealth - yourDMG;

                if((int)characterCombatHP < 0){
                    Console.WriteLine("You die!");                    
                    monsterBattle = true;
                    game = true; // End game
                    return defetMonster;
                }
                else if(monsterHealth > 0){
                    Console.WriteLine(Environment.NewLine + $"{monsterType} HP: {monsterHealth} | Your HP: {characterCombatHP}");

                    Console.WriteLine(Environment.NewLine + "[... battle continues ...]");
                    continue;
                }

                Console.WriteLine($"You defeated the {monsterType}!");                
                monsterBattle = true;
                defetMonster = true;
                break;
            case 2: // use potion
                if((int)characterHealthPotions > 0){
                    Console.WriteLine("You used a Health Potion. +10 HP.");
                    characterCombatHP = (int)characterCombatHP + 10;
                    characterStats["characterPotion"] = (int)characterStats["characterPotion"] - 1;
                }else{
                    Console.WriteLine("You do not have a Health Potion.");
                }
                break;
            case 3: // Run
                int baseCharacterDamage = (int)characterDamage;
                int damageReduction = (int)(Convert.ToDouble(characterDamage) * 0.1); // reduction by 10%
                characterDamage = Math.Max(0, baseCharacterDamage - damageReduction); 
                Console.WriteLine($"You run from the fight, and because of that your damage is decreasing by 10%.\nYour damage now: {characterDamage}");
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
        // Weapons, dmg:
        // Weak: 5–15
        // Mid: 16–35
        // Strong: 36–100+
        { "Rusted Iron Sword", 10 },
        { "Sharpened Steel Axe", 16 },
        { "Enchanted Staff", 22 },
        { "Cursed Dagger", 14 },
        { "Ancient Spellbook", 25 },
        { "Legendary Warhammer", 35 },
        { "Fine Short Sword", 12 },
        { "Basic Wand", 8 },
        { "Masterwork Battle Axe", 30 },
        { "Poison Kris Blade", 18 },
        { "Shadow Knife", 20 },
        { "Crystal Orb", 24 },
        { "Arcane Rod", 19 },
        { "Cursed Spiked Mace", 22 },
        { "Ancient Claymore", 28 },
        { "Stiletto of Shadows", 17 },
        { "Fine Crystal Scepter", 21 },
        { "Masterwork Spellbook", 32 },
        { "Sharpened Short Sword", 14 },
        { "Legendary Arcane Rod", 34 },
        { "Shadow Orb", 20 },
        { "Godslayer Blade", 100 },
        { "Oblivion Staff", 120 },
        { "Assassin’s Doomfang", 98 },
        { "Dagger of the Void", 92 },
        { "Runed Deathwand", 85 },
        { "Mythic Spiked Mace", 95 },
        { "Heaven’s Claymore", 110 },
        { "Ancient Staff of Ruin", 88 },
        { "Witch King's Scepter", 90 },
        { "Slayer’s Steel", 50 },
        { "Titan Hammer", 75 },
        { "Venomshadow Kris", 66 },
        { "Master Assassin Blade", 80 },
        { "Hellfire Orb", 95 },
        { "Archmage’s Wand", 70 },
        { "Fine Steel Axe", 17 },
        { "Masterwork Short Sword", 22 },
        { "Rusted Staff", 6 },
        { "Shadow Staff", 23 },
        { "Cursed Arcane Rod", 20 },
        { "Enchanted Stiletto", 15 },
        { "Crystal Spellbook", 29 },
        { "Ancient Warhammer", 26 },
        { "Poison Fang", 18 },
        { "Fine Iron Sword", 14 },
        { "Rusted Claymore", 12 },
        { "Masterwork Steel Axe", 28 },
        { "Legendary Crystal Orb", 35 },
        { "Cursed Spellbook", 24 },
        { "Shadow Short Sword", 19 },
        { "Rusted Kris Blade", 11 },
        { "Ancient Orb", 22 },
        { "Enchanted Dagger", 16 },
        { "Sharpened Wand", 13 },
        { "Fine Warhammer", 20 },
        { "Legendary Spiked Mace", 34 },
        { "Basic Wand", 7 },
        { "Rogue King's Fang", 87 },
        { "Dagger of Infinite Night", 77 },
        { "Divine Battle Axe", 102 },
        { "Black Hole Spellbook", 99 },
        { "Vampiric Shadow Blade", 68 },
        { "Spectral Wand", 26 },
        { "Bloodforged Sword", 55 },
        { "Arcane Executioner", 120 },
        { "Mage's Bane", 62 },
        { "Enchanted Claymore", 36 },
        { "The Final Stiletto", 84 },
        { "Warlord’s Sledge", 89 },
        { "Tombfang Dagger", 72 },
        { "Hellborn Arcane Rod", 93 },
        { "Draconic Staff", 100 },
        { "Lich King's Blade", 97 },
        { "Dark Priest Wand", 40 },
        { "Corrupted Hammer", 79 },
        { "Doomcaller Spellbook", 88 },
        { "Twilight Kris", 63 },
        { "Bloodsoaked Axe", 58 },
        { "Eternal Flame Staff", 101 },
        { "Frosted Fang", 37 },
        { "Duskblade", 45 },
        { "Wand of Calamity", 110 },
        { "Hellfang Knife", 73 },
        { "Plagued Iron Sword", 39 },
        { "Blight Hammer", 67 },
        { "Vortex Orb", 76 },
        { "Bonecutter Axe", 41 },
        { "Soulstealer Staff", 83 },
        { "Nightpiercer Kris", 48 },
        { "Sunblade", 95 },
        { "Dagger of Silence", 38 },
        { "Scepter of Chains", 49 },
        { "Firebrand Sword", 59 },
        { "Dagger of the Phoenix", 54 },
        { "Abyssal Claymore", 90 },
        { "Hammer of Judgement", 86 },
        { "Wraithlord’s Rod", 80 },
        { "Voidsteel Fang", 92 },
        { "Lightless Orb", 108 },
        { "Necromancer's Staff", 82 },
        { "Obsidian Warhammer", 78 },
        { "Finality Blade", 100 },
        // Potions 
        { "Health Potion", 1 },        
    };
   
    var lootList = lootLibrary.ToList();
    int loot = Randomizer(lootList.Count);  

    int gold = Randomizer(50, 1);
    characterGold = (int)characterGold + gold;

    Console.WriteLine("Loot Found:");
    Console.WriteLine($"- {gold} Gold");
    Console.WriteLine($"- {lootList[loot].Key} {(lootList[loot].Key != "Health Potion" ? $"Damage: {lootList[loot].Value}" : lootList[loot].Value)}");

    bool equipCharacter = false;
    while(!equipCharacter)
    {
        Console.WriteLine($"Add {lootList[loot].Key} to inventory? (Y/N)");

        string equip = IsStringValid("> ");
        if(equip == "y"){
            if(lootList[loot].Key == "Health Potion"){
                characterHealthPotions = (int)characterHealthPotions + 1;
            }else{                
                if(characterInvetory.ToList().Count > 0){
                    characterInvetory.Clear();
                }
                characterInvetory.Add(lootList[loot].Key, lootList[loot].Value);         
            }

            Console.WriteLine("Inventory updated.");
            equipCharacter = true;
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

    if(characterInvetory.ToList().Count > 0){
        Console.WriteLine($"- {characterInvetory.ToList()[0].Key} (Damage: {characterInvetory.ToList()[0].Value})");
    }

    Console.WriteLine($"- Health Potion: {(
        (int)characterHealthPotions > 0 ? 
        $"x{characterHealthPotions}" : "0"
    )}");   
    Console.WriteLine($"- Gold: {characterGold}");

    while (true)
    {
        Console.WriteLine("1. Use Potion");
        Console.WriteLine("2. Equip Weapon");
        Console.WriteLine("3. Back");

        int invetoryUse = IsIntegerValid("> ");

        switch (invetoryUse)
        {
            case 1:                
                if ((int)characterHealthPotions > 0)
                {
                    Console.WriteLine("You used a Health Potion. +10 HP.");
                    characterHealth = (int)characterHealth + 10;
                    characterHealthPotions = (int)characterStats["characterPotion"] - 1;
                }else
                {
                    Console.WriteLine("You do not have a Health Potion.");     
                }
                
                break;
            case 2:
                if(characterInvetory.ToList().Count > 0){

                    characterWeapon = characterInvetory.ToList()[0].Key;
                    characterDamage = characterInvetory.ToList()[0].Value;

                    Console.WriteLine($"Equipped weapon: {characterWeapon} | DMG: {characterDamage}");
                    characterInvetory.Clear();
                }else{
                    Console.WriteLine("Your inventory is empty.");
                }
                    break;
            case 3:
                return;
                //break;
            default:
                Console.WriteLine("Please choose options form the list.");
                break;
        }
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

enum PlayerClasses
{
    Warrior = 1,
    Mage,
    Rogue,
};
