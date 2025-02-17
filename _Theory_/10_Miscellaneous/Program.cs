/* Navigation Notes
    
    Enum                                                         : line 11
        

    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/

/* 
    ENUM:
    * An enum is a special "class" that represents a group of constants (unchangeable/read-only variables).
    * Cannot contain any fields, properties or methods in the enum's body.
    * Under the hood, each value of an enum is represented as an integer. By default, the first value is zero, the second is one, and so on.
 
 */

namespace Enum
{
    public enum WeekDays{
        //Monday, // default is 0 
        Monday = 1, 
        Tuesday, 
        Wednesday, 
        Friday, 
        Saturday,
        Sunday
    }
        
    class Program {

        static void Main(string[] args)
        {
            // Declaring a variable 'monday' of type WeekDays and setting it equal to WeekDays.Monday
            WeekDays monday = WeekDays.Monday;

            Console.WriteLine(monday); // Monday

            // To see int of the enum we need cast to integer
            Console.WriteLine((int)monday);

            Console.ReadKey();

        }
       
    }
}

