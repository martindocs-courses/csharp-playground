
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Linq_practice_FirstLast
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

        public static Pet Pets()
        {
            var pets = new[]{
                new Pet(1, "Ed", PetType.Fish, 1.1f),
                new Pet(2, "Alex", PetType.Dog, 4f),
                new Pet(3, "Dexter", PetType.Cat, 2f),
                new Pet(4, "Max", PetType.Dog, 0.7f),
                new Pet(5, "Storm", PetType.Cat, 2f),
            };

            // find last doog in the collection of pets
            //return pets.Last(pet => pet._petType == PetType.Dog);

            // if not match or collection empty it will throw error
            //try
            //{
            //    return pets.Last(pet => pet._petWeight > 100f);
            //}
            //catch (InvalidOperationException ex)
            //{
            //    return null;
            //}

            // If there is no first or last element that matches the given criteria.
            // FirstOrDefault & LastOrDefault does not throw an exception if: The list is empty, or No item matches the condition.
            //return pets.FirstOrDefault(pet => pet._petWeight > 100f);

            // combine OrderBy with Last method
            return pets.OrderBy(pet => pet._petWeight).Last();
        }

        public enum PetType
        {
            Fish,
            Cat,
            Dog
        }
    }
}
