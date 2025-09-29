
namespace Linq_practice_Any
{
    public class CheckAnyNumber
    {
        public List<int> CheckIfTen() => new List<int>{2,10,6,7};        
    }

    public class Pet{

        private int _petID { get; set; }
        private string _petName { get; set; }

        private PetType _petType { get; set; }
        private float _petWeight { get; set; }

        // To be able to use parametless constructor with no parameters we could use 
        /* 
            1) default constructor - But be aware: this pet object will have default values (null, 0, etc.) unless you set them later.
            
                //public Pet(){}
            
            2) make method that use constructor static: public static bool Pets(){...}

            3) move method that use constructor outside class and make it as helper method: 
            
                public static class PetFactory {
                    
                    public static Pet[] GetPets(){ // return Pet class
                        ...
                    }
                }
        */


        public Pet(int petID, string petName, PetType type, float petWeight)
        {
            _petID = petID;
            _petName = petName;
            _petType = type;
            _petWeight = petWeight;
        }

        public static Dictionary<string, bool> Pets()
        {

            var pets = new[]{
                new Pet(1, "Ed", PetType.Fish, 1.1f),
                new Pet(2, "Dexter", PetType.Cat, 2f),
                new Pet(3, "Max", PetType.Dog, 0.7f),
                new Pet(4, "Storm", PetType.Cat, 40f),
            };


            var isAnyPetNamedEd = pets.Any(pet => pet._petName == "Ed");

            var isAnyFish = pets.Any(pet => pet._petType == PetType.Fish);

            var isThereAVerySpecificPet = pets.Any(pet => pet._petName.Length >= 6 && pet._petID % 2 == 0);

            var isNotEmpty = pets.Any(); // return True is there is any element in the collection, otherwise return False if is empty

            return new Dictionary<string, bool>{
                {"Is there pet named Ed:", isAnyPetNamedEd }, 
                {"Is there any fish:", isAnyFish }, 
                {"Is there pet name longer than 6 char and ID is even number:", isThereAVerySpecificPet }, 
                {"Is there pet collection not empty:", isNotEmpty },                
            };
        }

        public enum PetType
        {
            Fish,
            Cat,
            Dog
        }
    }
}
