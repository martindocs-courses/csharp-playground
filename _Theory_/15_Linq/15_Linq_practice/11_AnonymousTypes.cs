
namespace Linq_practice_AnonymousTypes
{
   public class ListOfNumbers{
     
        public List<List<int>> Numbers(){

            return new List<List<int>>
            {
                new List<int>{15, 68, 20, 12, 19, 8, 55},
                new List<int>{12, 1, 3, 4, -19, 8, 7, 6},
                new List<int>{5, -6, -2, -12, -10, 7},
            };
        }
   }
}
