/*
    create a method that displays the correct email address for both internal and external employees. You're given lists of internal and external employee names. An employee's email address consists of their username and company domain name.

    The username format is the first two characters of the employee first name, followed by their last name. For example, an employee named "Robert Bavin" would have the username "robavin". The domain for internal employees is "contoso.com".
 */

string[,] corporate =
{
    {"Robert", "Bavin"}, {"Simon", "Bright"},
    {"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
    {"Sarah", "Delucchi"}, {"Sinan", "Ali"}
};

string[,] external =
{
    {"Vinnie", "Ashton"}, {"Cody", "Dysart"},
    {"Shay", "Lawrence"}, {"Daren", "Valdes"}
};

string externalDomain = "hayworth.com";

/*
 * the domain for internal employees is "contoso.com"
 * the username for all employees is the first two characters of their first name, followed by their full last name.
 * create a method that will display the email address of internal and external employees.
 * The method should include an optional parameter for the domain name of external employees. *  
 */

void DisplayUserEmailAddress(string[,]? arr = null, string userDomain = "contoso.com")
{
    //if (arr == null) arr = corporate;

    // OR more compact with using Null-Coalescing Operator. 
    /*
        - If arr is null, arr will be assigned the value of corporate.
        - If arr is not null, it remains unchanged.
     */
    arr ??= corporate;

    string name = "";
    string lastName = "";
    string email = "";

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        /* 
         * get first name
         * extract first two characters of the first name (or whole first name if less than 2 characters)
        */
        name = arr[i, 0].ToLower().Substring(0, Math.Min(2, arr[i, 0].Length));

        // get last name
        lastName = arr[i, 1].ToLower();

        // construct email address
        Console.WriteLine($"{name}{lastName}@{userDomain}");
    }
}

DisplayUserEmailAddress();
Console.WriteLine();
DisplayUserEmailAddress(external, externalDomain);