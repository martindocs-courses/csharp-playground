
namespace Linq_practice_Where
{
    public class ContainsNumbers
    {
        public IEnumerable<int> Numbers() => new[] { 2, 10, 6, 7 };

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

        public static IEnumerable<Pet> Pets()
        {
            var pets = new[]{
                new Pet(1, "Ed", PetType.Fish, 1.1f),
                new Pet(2, "Alex", PetType.Dog, 4f),
                new Pet(3, "Dexter", PetType.Cat, 2f),
                new Pet(4, "Max", PetType.Dog, 0.7f),
                new Pet(5, "Storm", PetType.Cat, 2f),
            };

            //return pets.Where(pet => pet._petWeight > 2f); 

            // No error will be throws if result is empty 
            //return pets.Where(pet => pet._petWeight > 10); 
            //return pets.Where(pet => 
            //(pet._petType == PetType.Cat || 
            //pet._petType == PetType.Dog) && 
            //pet._petName.Length > 4 && 
            //pet._petWeight > 1f && 
            //pet._petID % 2 == 1);

            // We can get the same result with LINQ with different ways
            var countOfHeavyPets1 = pets.Count(pet => pet._petWeight > 2f);
            var countOfHeavyPets2 = pets.Where(pet => pet._petWeight > 2f).Count();

            // Overload Where method with additional prop index
            var indexesSelectedByUser = new[] { 1, 2, 3 };
            return pets.Where((pet, index) => pet._petWeight > 3f && indexesSelectedByUser.Contains(index));

        }

        public enum PetType
        {
            Fish,
            Cat,
            Dog
        }
    }
}
