// Text Adventure Game – "Console RPG"
// Player exploring a dungeon-like world, fighting enemies, looting, and managing inventory.

using System;
using System.Text.Json;
using System.Linq;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
// Use relative path going up to the project root
const string MONSTER_LIBRARY_PATH = @"..\..\..\GameData\monsters-library.json";
const string LOOT_LIBRARY_PATH = @"..\..\..\GameData\loot-library.json";
const string CHARACTER_PATH = @"..\..\..\CharacterData\characters.json";
const string PROMPTS_YES = "y";
const string PROMPTS_NO = "n";

var character = new Dictionary<string, object>();
try
{
    bool continueGame = ContinueGame(out character);
    if (!continueGame)
    {
        character = CharacterCreation();    
    }
}
catch (JsonException ex) {
    if(ex is JsonException){
        ResetJSONFile(CHARACTER_PATH);        
    }
    
    character = CharacterCreation();            
}

// we need cast to Dictionary because the retrieved value from the outer dictionary is stored as object and C# doesn't know what type it really is at runtime unless we tell it.
var characterStats = (Dictionary<string, object>)character["characterStats"];

var characterName = character["characterName"];
var characterClass = character["characterClass"];
var characterHealth = characterStats["characterHP"];
var characterDamage = characterStats["characterDMG"];
var characterGold = characterStats["characterGold"];
var characterWeapon = characterStats["characterWepon"];
var characterHealthPotions = characterStats["characterPotion"];
var characterInvetory = (Dictionary<string, int>)characterStats["characterInvetory"];

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
            try{
                bool encounterWin = CombatEncounter(GetRandomMonster());
                    if(encounterWin == true){
                        try{
                            LootingSystem();
                        }catch(JsonException ex){
                            Console.WriteLine("Looting Library is empty. Please populate the data before proceeding with the game.\nThe Loot Library is located in GameData\\ folder");
                        }
                    }
            }catch(ArgumentOutOfRangeException ex){
                Console.WriteLine("Monster Library is empty. Please populate the data before proceeding with the game.\nThe Monster Library is located in GameData\\ folder");
            }
            break;        
        case 2:
            Invertory();
            break;
        case 3:
            Rest();
            break;
        case 4:
            Console.WriteLine("Save and Quit");
            SaveCharacterStatus();
            game = true;
            break;
        default:
            Console.WriteLine("Please choose options.");
            break;
    }

    Console.ReadLine();    
    Console.Clear();
}

void SaveCharacterStatus()
{
    var getFile = File.ReadAllText(GetPath(CHARACTER_PATH));
    var listOfCharacters = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(getFile);

    var newCharacter = new Dictionary<string, object>(){
        { "characterName", characterName},
        { "characterClass", characterClass},
        {"characterStats", new Dictionary<string, object>()
            {
                {"characterHP" , characterHealth},
                {"characterDMG" , characterDamage},
                {"characterGold" , characterGold},
                {"characterWepon" , characterWeapon},
                {"characterPotion" , characterHealthPotions},
                {"characterInvetory", characterInvetory}
            }
        }
    };

    listOfCharacters.Add(newCharacter);

    var options = new JsonSerializerOptions{WriteIndented = true};

    var updatedCharacters = JsonSerializer.Serialize(listOfCharacters, options);
    File.WriteAllText(CHARACTER_PATH, updatedCharacters);
}

void Rest()
{
    characterDamage = BaseCharacterStats((string)characterClass)["characterDMG"];
    Console.WriteLine($"You're well rested. Your damage is back to {characterDamage}!");
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

                Console.WriteLine(Environment.NewLine + $"You defeated the {monsterType}!");                
                monsterBattle = true;
                defetMonster = true;
                break;
            case 2: // use potion
                if((int)characterHealthPotions > 0){
                    Console.WriteLine("You used a Health Potion. +10 HP.");
                    characterCombatHP = (int)characterCombatHP + 10;                    
                    characterHealthPotions = (int)characterStats["characterPotion"] - 1;
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

string GetPath(string path){
    if(!File.Exists(path)){
        ResetJSONFile(path);
    }
    return path;
}

void ResetJSONFile(string path)
{
    string jsonFile = path.Substring(18);
    bool coruptedFile = false;
    while(!coruptedFile){
        Console.WriteLine(Environment.NewLine + $"The '{jsonFile}' file is corrupted. Do you want reset the file? [y/n]: ");
        var resetFile = Console.ReadLine()?.ToLower();

        if (resetFile == PROMPTS_YES)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(new List<Dictionary<string, object>>()));
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
    try
    {
        var getFile = File.ReadAllText(GetPath(MONSTER_LIBRARY_PATH));

        // When deserialize JSON into a Dictionary<string, object>, System.Text.Json stores all values as JsonElement, not real primitives. You get JsonElement only when you deserialize to object. In this case, System.Text.Json doesn't know the specific types, so it puts everything as JsonElement, which is a flexible type that can represent any JSON value (number, string, object, array, etc.).
        // Use Dictionary<string, JsonElement> to avoid casting
        var monsters = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(getFile);

        int selectedMonster = Randomizer(monsters.Count);

        return monsters[selectedMonster];
    }
    catch (ArgumentOutOfRangeException ex)
    {
        throw;
    }
}

void LootingSystem(){

    try{
        var getFile = File.ReadAllText(GetPath(LOOT_LIBRARY_PATH));
        var lootLibrary = JsonSerializer.Deserialize<Dictionary<string, int>>(getFile);

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
            Console.WriteLine($"Add {lootList[loot].Key} to inventory? (y/n)");

            string equip = IsStringValid("> ").ToLower();
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
    }catch(JsonException ex){
        throw;
    }

}

void Invertory(){
    
    Console.WriteLine(Environment.NewLine + "== Inventory ==");

    if(characterInvetory.ToList().Count > 0 && characterInvetory.ToList()[0].Key != "")
    {
        Console.WriteLine($"- {characterInvetory.ToList()[0].Key} (Damage: {characterInvetory.ToList()[0].Value})");
    }

    Console.WriteLine($"- Health Potion: {(
        (int)characterHealthPotions > 0 ? 
        $"x{characterHealthPotions}" : "0"
    )}");   
    Console.WriteLine($"- Gold: {characterGold}");

    while (true)
    {
        Console.WriteLine(Environment.NewLine + "1. Use Potion");
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
                    return;
                }else
                {
                    Console.WriteLine("You do not have a Health Potion.");     
                }
                
                break;
            case 2:
                if(characterInvetory.ToList().Count > 0){

                    characterWeapon = characterInvetory.ToList()[0].Key;
                    characterDamage = characterInvetory.ToList()[0].Value;

                    Console.WriteLine(Environment.NewLine + $"Equipped weapon: {characterWeapon} | DMG: {characterDamage}");
                    return;
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


bool ContinueGame(out Dictionary<string, object> character){
    character = new Dictionary<string, object>();
    bool startNewGame = false;

    try{
        var getFile = File.ReadAllText(GetPath(CHARACTER_PATH));
        var listOfCharacters = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(getFile);
        var charactersCount = listOfCharacters.Count;

        if(charactersCount > 0){
    
            Console.WriteLine("Do you want continue the game with saved characters? [y/n] ");
            while (!startNewGame)
            {
                string continueOldGame = IsStringValid("> ").ToLower();               

                if (continueOldGame == "y")
                {
                    Console.WriteLine("== Saved characters ==");

                    for (int i = 0; i < charactersCount; i++)
                    {
                        string? name = listOfCharacters[i]["characterName"].GetString();
                        string classType = listOfCharacters[i]["characterClass"].GetString();

                        Console.WriteLine($"{i + 1}.{name}, class: {classType}");
                    }

                    Console.WriteLine($"{charactersCount + 1}.Restart game");

                    bool startNewGameOptions = false;
                    while (!startNewGameOptions)
                    {
                        var savedCharacters = IsIntegerValid("> ");

                        if (savedCharacters == 0){
                            Console.WriteLine(Environment.NewLine + "Please select saved character or restart the game");
                            continue;
                        }

                        if (savedCharacters != charactersCount + 1)
                        {

                            string? name = listOfCharacters[savedCharacters - 1]["characterName"].GetString(); // Returns the actual string value from the JSON, if the JsonElement is of type String. If the element is not a string, it will throw an exception.
                            string? classType = listOfCharacters[savedCharacters - 1]["characterClass"].ToString(); // Returns the JSON representation of the element — regardless of its actual type. Can be used on any JsonElement, but the result may not be unpredictable.
                            int health = listOfCharacters[savedCharacters - 1]["characterStats"].GetProperty("characterHP").GetInt32();
                            int damage = listOfCharacters[savedCharacters - 1]["characterStats"].GetProperty("characterDMG").GetInt32();
                            int gold = listOfCharacters[savedCharacters - 1]["characterStats"].GetProperty("characterGold").GetInt32();
                            string weapon = listOfCharacters[savedCharacters - 1]["characterStats"].GetProperty("characterWepon").ToString();
                            int healthPotions = listOfCharacters[savedCharacters - 1]["characterStats"].GetProperty("characterPotion").GetInt32();

                            var inventoryJson = listOfCharacters[savedCharacters - 1]["characterStats"].GetProperty("characterInvetory");
                            string invetoryWeapon = "";
                            int invetoryWeaponDmg = 0;                            

                            if (inventoryJson.EnumerateObject().Any())
                            {
                                invetoryWeapon = inventoryJson.EnumerateObject().First().Name;
                                invetoryWeaponDmg = inventoryJson.EnumerateObject().First().Value.GetInt32();                            
                            }

                            character.Add("characterName", name);
                            character.Add("characterClass", classType);
                            character.Add("characterStats", new Dictionary<string, object>()
                        {
                            {"characterHP" , health},
                            {"characterDMG" , damage},
                            {"characterGold" , gold},
                            {"characterWepon" , weapon},
                            {"characterPotion" , healthPotions},
                            {"characterInvetory", new Dictionary<string, int>()
                                {
                                    {invetoryWeapon, invetoryWeaponDmg}
                                }
                            }
                        });

                            startNewGame = true;
                            startNewGameOptions = true;
                        }
                        else if (savedCharacters == charactersCount + 1)
                        {
                            break;
                        }
                    }

                    break;

                }else if(continueOldGame == "n"){
                    break;
                }else{
                    Console.WriteLine("Please choose [y/n] options." + Environment.NewLine);
                }
            }
        }

    }catch(JsonException ex){
        throw;
    }

    return startNewGame;
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
