namespace _10_Miscellaneous.Extensions
{
    // Extension methods can only be defined in static classes 
    public static class StringExtensions
    {
        // extension method must be always static
        public static int CountLines(this string input) =>
            /*
                * parameter 'string input' is of the type we want extend. 
                * 'this' modifier must be added when creating extension.
                * the extended parameter must be first in the list of parameters ... CountLines(this string input, int a) ...
                * it's good practice to have single extension for each type
             
             */
            input.Split(Environment.NewLine).Length;
    }
}
