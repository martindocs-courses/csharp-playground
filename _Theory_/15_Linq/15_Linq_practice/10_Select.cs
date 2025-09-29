
namespace Linq_practice_Select
{
    public class ContainsNumbers
    {
        public IEnumerable<int> Numbers() => new[] { 2, 10, 10, 6, 7 };

    }

    public class ContainsWords
    {
        public IEnumerable<string> Words() => new[] { "little", "brown", "fox" };
    }

    public class Pet
    {
        private int _petID { get; set; }
        private string _petName { get; set; }
        public string PetName => _petName;
        private PetType _petType { get; set; }
        private float _petWeight { get; set; }
        public float PetWeight => _petWeight;

        public Pet(int petID, string petName, PetType type, float petWeight)
        {
            _petID = petID;
            _petName = petName;
            _petType = type;
            _petWeight = petWeight;
        }

        public static IEnumerable<string> Pets()
        {
            var pets = new[]{
                new Pet(1, "Ed", PetType.Fish, 1.1f),
                new Pet(2, "Alex", PetType.Dog, 4f),
                new Pet(3, "Dexter", PetType.Cat, 2f),
                new Pet(4, "Max", PetType.Dog, 0.7f),
                new Pet(5, "Storm", PetType.Cat, 2f),
            };

            // New collection of all weights of Pets
            //return pets.Select(pet => pet._petWeight);

            // Select all those pet types for which pets heavier than 2 kilos exist.
            //return pets.Where(pet => pet._petWeight > 2)
            //.Select(pet => pet._petType)
            //.Distinct();

            // Create a list of all pets initials ordered alphabetically.
            //return pets.OrderBy(pet => pet._petName).Select(pet => pet._petName.First());

            // Convert all pets crucial data to a collection of strings.
            return pets.Select(pet => pet._petName + " " + pet._petType );
        }

        public enum PetType
        {
            Fish,
            Cat,
            Dog
        }
    }
}
