
// EXAMPLE 1 
namespace Linq_introduction1
{
   
    public static class Introduction1
    {
        public static bool IsAnyWordUppercase_NonLinq(IEnumerable<string> words)
        {

            foreach (var word in words)
            {
                bool allUpperCase = true;
                foreach (var letter in word)
                {
                    if(char.IsLower(letter)){
                        allUpperCase = false;
                    }
                }

                if(allUpperCase){
                    return true;
                }

            }

            return false;
        }

        public static bool IsAnyWordUppercase_Linq(IEnumerable<string> words)
        {
            return words.Any(word => word.All(letter => char.IsUpper(letter)));
        }
    }
    
}

// EXAMPLE 2
namespace Linq_introduction2
{
    public static class Introduction2
    {
        public static void ModifyNumbers()
        {

            var numbers = new List<int> { 5, 3, 4, 7, 8 };
            var add10 = numbers.Append(10);

            Console.WriteLine("Numbers: " + string.Join(", ", numbers));
            Console.WriteLine("Numbers with 10: " + string.Join(", ", add10));
            Console.WriteLine("Numbers: " + string.Join(", ", numbers));
        }
    }
}

// EXAMPLE 3
namespace Linq_introduction3
{
    public static class Introduction3
    {
        public static void OddNumbers()
        {

            var numbers = new List<int> { 5, 3, 4, 7, 8 };

            var oddNumbers = numbers.Where(number => number % 2 == 1);
            var orderNumbers = oddNumbers.OrderBy(number => number);

            Console.WriteLine("Odd numbers: " + string.Join(", ", orderNumbers));
        }
    }
}

// EXAMPLE 4
namespace Linq_introduction4
{
    public static class Introduction4
    {
        public static void ShortWords()
        {

            var words = new List<string> { "a", "aaa", "cccc", "ss" };

            // shortWords is a query not data. Where query is a method to retrieve data.
            var shortWords = words.Where(word => word.Length < 3); // it not execute in this line, only query is created

            // OR if more than one syntax in lambda expression we use braces and return keyword 
            //var shortWords = words.Where(word => {
            //    Console.WriteLine(word);
            //    return word.Length < 3;

            //}); 

            // The deferred execution, also called materialization, is delayed until the result is needed, which in this case happens here in the for each loop.
            // It improves performance by avoiding unnecessary execution.
            Console.WriteLine("Words than have length lower than 3");
            foreach (var word in shortWords)
            {
                Console.WriteLine(word);
            }
            words.Add("dd");

            Console.WriteLine();
            foreach (var word in shortWords)
            {
                Console.WriteLine(word);
            }

            // One of the points of deferred execution is to improve preformance

        }
    }
}
