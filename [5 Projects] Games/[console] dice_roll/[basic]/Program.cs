
/* ROLL A DICE */
#region Pseudocode
/* 
    * generate the number from 1 to 6
    * ask the user to guess the number (user has 3 tries)
    * if the user input the number
        * check if the input is a number and if is between 1 to 6
            * if it's check if is the same as random number
                * if is right show "You win" and end the game. Optional as user if he/she wants to try again.
            * if is not, show "Wrong number" and ask user to enter again (check how many tries he/she has left)          
        * if is not a number 
            * tell the user that input must be a number and between 1 to 6, and show "Enter a number". Check how many tries user has left
        * if user didn't guess the number in 3 tries show "You loose" and end the game. Optional as user if he/she wants to try again 
 */
#endregion

// Entry point of application
var user = new GameConsoleUI();
user.GameUI();


