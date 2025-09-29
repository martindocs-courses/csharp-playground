
namespace Linq_practice_Count
{
    public class Pet
    {

        private int _petID { get; set; }
        private string _petName { get; set; }
        private PetType _petType { get; set; }
        private float _petWeight { get; set; }

        public Pet(int petID, string petName, PetType type, float petWeight)
        {
            _petID = petID;
            _petName = petName;
            _petType = type;
            _petWeight = petWeight;
        }

        public static Dictionary<string, int> Pets()
        {
            var pets = new[]{
                new Pet(1, "Ed", PetType.Fish, 1.1f),
                new Pet(2, "Dexter", PetType.Cat, 2f),
                new Pet(3, "Max", PetType.Dog, 0.7f),
                new Pet(4, "Storm", PetType.Cat, 40f),
                new Pet(5, "Fast", PetType.Dog, 1.7f),
            };

            var howManyDogs = pets.Count(pet => pet._petType == PetType.Dog);

            var countPetsNamedDexter = pets.LongCount(pet => pet._petName == "Dexter");

            var countAllDogsLighterThan10kg = pets.Count(pet => pet._petType == PetType.Dog && pet._petWeight < 1f);

            var allPetsInCollection = pets.Count();

            return new Dictionary<string, int>{
                {"How many dogs are in the collection:", howManyDogs },
                {"Pet named Dexter:", (int)countPetsNamedDexter},
                {"Dogs lighter that 10kg:", countAllDogsLighterThan10kg},
                {"All pets in collection:", allPetsInCollection},
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
