using System.ComponentModel;

namespace MusicPlaylistAnalyzer.Utilities
{
    public static class EnumDescriptionExtensions{

        /// <summary>
        /// Returns the [Description("...")] of an enum value, or the name if no description exists.
        /// </summary>
        static public string GetDescription(this Enum @enum){ // this keyword make the method as extension method
            /*
                A method becomes an extension method if:

                * It is defined in a static class.

                * The method itself is static.

                * The first parameter is preceded by the this keyword.
             
             */

            /* Below code explanation:
                @enum.ToString() - Get the name of the enum member aka. ShowAllSongs
                .GetField(...) - Finds the field (metadata) for that member
                @enum.GetType() - Get the Type of the enum value aka. SongsFilters
             
             */

            var field = @enum.GetType().GetField(@enum.ToString());

            // If we found the field, try to get its[Description] attribute
            if (field != null)
            {
                // Try to get the DescriptionAttribute applied to this field
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                
                // If the attribute exists, return its Description value
                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            // If no description attribute was found, just return the enum name
            return @enum.ToString();
        }
    }

    
}
