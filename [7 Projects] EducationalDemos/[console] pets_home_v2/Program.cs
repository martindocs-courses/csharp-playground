/* 
 Demo of Pets application data in a multidimensional string array named ourAnimals.
*/

// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
int petAge = 0;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription + "\n";
}

// display the top-level menu options
do
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");


    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information          
            for (int i = 0; i < ourAnimals.GetLength(0); i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    for (int j = 0; j < ourAnimals.GetLength(1); j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "2":
            // Add a new animal friend to the ourAnimals array
            string anotherPet = "y";
            int petCount = 0;

            for (int i = 0; i < ourAnimals.GetLength(0); i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {

                    petCount++;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }


            while (anotherPet == "y" && petCount < maxPets)
            {

                bool validEntry = false;

                // get species (cat or dog) - string animalSpecies is a required field 
                do
                {

                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();

                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }

                } while (validEntry == false);

                // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                // get the pet's age. can be ? at initial entry. 
                do
                {
                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalAge = readResult;

                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out _);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }

                } while (validEntry == false);

                // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {

                        animalPhysicalDescription = readResult.ToLower();

                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }

                } while (animalPhysicalDescription == "");

                // get a description of the pet's personality - animalPersonalityDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {

                        animalPersonalityDescription = readResult.ToLower();

                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }

                } while (animalPersonalityDescription == "");


                // get the pet's nickname. animalNickname can be blank.
                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();

                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }

                } while (animalNickname == "");

                // store the pet information in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                // increment petCount                
                petCount += 1;

                if (petCount < maxPets)
                {
                    // another pet?
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                }

                do
                {
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        anotherPet = readResult.ToLower();
                    }
                } while (anotherPet != "y" && anotherPet != "n");
            }

            if (petCount == maxPets)
                Console.WriteLine("No more pets can be added.");

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;
        case "3":
            // Ensure animal ages and physical descriptions are complete

            // List all of current pet information
            for (int i = 0; i < ourAnimals.GetLength(0); i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {

                    if (ourAnimals[i, 2] == "Age: ?")
                    {
                        Console.WriteLine($"Enter an age for {ourAnimals[i, 0]}");

                        bool validAge = false;

                        while (validAge == false)
                        {
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                validAge = int.TryParse(readResult, out petAge);

                                if (validAge)
                                {
                                    ourAnimals[i, 2] = $"Age: {petAge}";
                                }
                                else
                                {
                                    Console.WriteLine("The value needs to be an number.");
                                }

                            }
                        };
                    }

                    if (ourAnimals[i, 4] == $"Physical description: ")
                    {
                        Console.WriteLine($"Enter a physical description for {ourAnimals[i, 0]} (size, color, breed, gender, weight, housebroken)");

                        bool validDesc = false;

                        while (validDesc == false)
                        {
                            readResult = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(readResult))
                            {
                                if (!int.TryParse(readResult, out _))
                                {
                                    ourAnimals[i, 4] = $"Physical description: {readResult}";
                                    validDesc = true;
                                }
                                else
                                {
                                    Console.WriteLine("The value cannot be an number");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input cannot be empty or whitespace.");
                            }
                        };
                    }

                }
            }

            Console.WriteLine("\nAge and physical description fields are complete for all of our friends.");

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            for (int i = 0; i < ourAnimals.GetLength(0); i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {

                    if (ourAnimals[i, 3] == "Nickname: ")
                    {
                        Console.WriteLine($"Enter a nickname for {ourAnimals[i, 0]}");

                        bool validNickName = false;

                        while (validNickName == false)
                        {

                            readResult = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(readResult))
                            {
                                if (!int.TryParse(readResult, out _))
                                {
                                    ourAnimals[i, 3] = $"Nickname: {readResult}";
                                    validNickName = true;
                                }
                                else
                                {
                                    Console.WriteLine("The value cannot be an number");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input cannot be empty or whitespace.");
                            }

                        }

                    }


                    if (ourAnimals[i, 5] == "Personality: ")
                    {
                        Console.WriteLine($"Enter a nickname for {ourAnimals[i, 0]}");

                        bool validPersonality = false;

                        while (validPersonality == false)
                        {

                            readResult = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(readResult))
                            {
                                if (!int.TryParse(readResult, out _))
                                {
                                    ourAnimals[i, 5] = $"Nickname: {readResult}";
                                    validPersonality = true;
                                }
                                else
                                {
                                    Console.WriteLine("The value cannot be an number");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input cannot be empty or whitespace.");
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "5":
            // Edit an animal’s age
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "6":
            // Edit an animal’s personality description
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "7":
            // Display all cats with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "8":
            // Display all dogs with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        default:
            break;
    }

} while (menuSelection != "exit");


