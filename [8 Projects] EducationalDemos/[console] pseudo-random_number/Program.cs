/*  PSEUDRANDOM NUMBERS
 
    * The new Random class generate pseudorandom numbers, and  with seed '12' as passed value we'll always get the same sequence of values.
    * If no seed is passed to the constructor, the value of the seed is set to the number of ticks since the system was started, where one tick is 100 nanoseconds.
    * If we create two objects of the random class at almost the same moment in time, they may have the same seed and as a result give us the same sequence of numbers.
        
        var random1 = new Random();
        var random2 = new Random();
    
    * This leads to some pretty common bugs when someone expects two random objects to generate different numbers, but in fact they generate the same numbers because they were created in the same window of 100 nanoseconds.
    * The best approach is to have a single Random object in the entire program.
 */

//var random = new Random(12); 

for (int i = 0; i < 3; i++)
{
    /*
        The numbers that are generated are determined by the initial value called the seed. 
        For the same seed, we'll always get the same sequence of values.
        So it's not really a random but rather a pseudorandom numbers generator.
     */
    //Console.WriteLine(random.Next(1, 11));
   
}

Console.WriteLine();

//var random = new Random(12);
var random2 = new Random();
var diceRollResult = random2.Next(1, 7);
Console.WriteLine(diceRollResult);

Console.ReadKey();