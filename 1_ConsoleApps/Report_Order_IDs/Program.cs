
/*
    Outputs the Order ID of new orders where the Order ID starts with the letter "B"
 */

string[] ids = { "B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179" };

foreach (var id in ids)
{
    if (id.StartsWith('B'))
    {
        Console.WriteLine($"Fraud {id} order!");
    }
}