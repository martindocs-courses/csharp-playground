/* 
 Improve the renewal rate of subscriptions to the software. Your task is to display a renewal message when a user logs into the software system and is notified their subscription will soon end. You'll need to add a couple of decision statements to properly add branching logic to the application to satisfy the requirements. 
 */


Random random = new Random();
int daysUntilExpiration = random.Next(12); // random number from 0 to 11
int discountProcentage = 0;

// If the user's subscription will expire in 10 days or less
if (daysUntilExpiration <= 10)
{
    // If the user's subscription will expire in one day,
    if (daysUntilExpiration == 1)
    {
        discountProcentage = 20;
        Console.WriteLine($"Your subscription expires within a day!\r\nRenew now and save {discountProcentage}%!");

        // If the user's subscription will expire in five days or less
    }
    else if (daysUntilExpiration <= 5)
    {
        discountProcentage = 10;
        Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.\r\nRenew now and save {discountProcentage}%!");
    }
    else
    {
        Console.WriteLine("Your subscription will expire soon. Renew now!");
    }

    //  If the user's subscription has expired
}
else if (daysUntilExpiration >= 10)
{
    Console.WriteLine("Your subscription has expired.");
}

// reset the discount
discountProcentage = 0;