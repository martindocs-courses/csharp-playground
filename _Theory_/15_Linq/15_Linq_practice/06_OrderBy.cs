
namespace Linq_practice_OrderBy
{
    public class OrderCollection
    {
        public List<int> Numbers() => new List<int> { 2, 10, 6, 7 };

        public List<string> Words() => new List<string> { "lion", "tiger", "leopard" };
    }

    public class Pet
    {

        private int _petID { get; set; }
        public int PetID => _petID;
        private string _petName { get; set; }
        public string PetName => _petName;
        private PetType _petType { get; set; }
        private float _petWeight { get; set; }

        public Pet(int petID, string petName, PetType type, float petWeight)
        {
            _petID = petID;
            _petName = petName;
            _petType = type;
            _petWeight = petWeight;
        }

        public static List<Pet> Pets()
        {
            var pets = new[]{
                new Pet(1, "Ed", PetType.Fish, 1.1f),
                new Pet(2, "Dexter", PetType.Cat, 2f),
                new Pet(3, "Max", PetType.Dog, 0.7f),
                new Pet(4, "Storm", PetType.Cat, 40f),
            };

            //return pets.OrderBy(pet => pet._petName).ToList();
            //return pets.OrderByDescending(pet => pet._petID).ToList();
            return pets.OrderByDescending(pet => pet._petID).ThenBy(pet => pet._petName).ToList(); //  Ordering by multiple criteria, we can have multiple ThenBy()

        }

        public enum PetType
        {
            Fish,
            Cat,
            Dog
        }
    }
}
