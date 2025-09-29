
namespace Linq_practice_All
{
    public class CheckAllNumbers
    {
        public List<int> Numbers() => new List<int> { 2, 10, 6, 7 };
    }

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

        public static Dictionary<string, bool> Pets()
        {
            var pets = new[]{
                new Pet(1, "Ed", PetType.Fish, 1.1f),
                new Pet(2, "Dexter", PetType.Cat, 2f),
                new Pet(3, "Max", PetType.Dog, 0.7f),
                new Pet(4, "Storm", PetType.Cat, 40f),
            };

            var isPetNameEmpty = pets.All(pet => string.IsNullOrEmpty(pet._petName));
            var isAllPetsAreCats = pets.All(pet => pet._petType == PetType.Cat);
            
            return new Dictionary<string, bool>{
                {"Is there empty pet name:", isPetNameEmpty },
                {"Is all pets are cats:", isAllPetsAreCats },                
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
