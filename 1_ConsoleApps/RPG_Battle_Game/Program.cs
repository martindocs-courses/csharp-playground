/*
    RPG BATTLE GAME, game rules:
    - You must use either the do-while statement or the while statement as an outer game loop.
    - The hero and the monster start with 10 health points.
    - All attacks are a value between 1 and 10.
    - The hero attacks first.
    - Print the amount of health the monster lost and their remaining health.
    - If the monster's health is greater than 0, it can attack the hero.
    - Print the amount of health the hero lost and their remaining health.
    - Continue this sequence of attacking until either the monster's health or hero's health is zero or less.
    - Print the winner. 
*/

/*
 Monster was damaged and lost 1 health and now has 9 health.
Hero was damaged and lost 1 health and now has 9 health.
Monster was damaged and lost 7 health and now has 2 health.
Hero was damaged and lost 6 health and now has 3 health.
Monster was damaged and lost 9 health and now has -7 health.
Hero wins!
 
 */

Random dice = new Random();

int heroLife = 10;
int monsterLife = 10;

do
{
    int monsterRoll = dice.Next(1, 11);

    monsterLife -= monsterRoll;
    Console.WriteLine($"Monster was damaged and lost {monsterRoll} health and now has {monsterLife} health.\n");

    //if (monsterRoll <= 0) continue; // we coud use this instead below to skip the code and move to while condition

    if( monsterLife > 0 ){
        int heroRoll = dice.Next(1, 11);
        heroLife -= heroRoll;
        Console.WriteLine($"Hero was damaged and lost {heroRoll} health and now has {heroLife} health.\n");
    }
   
}while (heroLife > 0 && monsterLife > 0);

Console.WriteLine($"{(heroLife > monsterLife ? "Hero": "Monster")} wins!");