using ExtensionMethods;
namespace _10_Miscellaneous.Extensions
{
    public static class SeasonExtensions
    {
        public static Season NextSeason(this Season season){
            int seasonAsInt = (int)season;
            int nextSeason = (seasonAsInt + 1) % 4; // add +1 to numeric representation of enum value
              /*
                    Spring = 0
                    Summer = 1
                    Autumn = 2
                    Winter = 3
               */
            return (Season)nextSeason;
        } 

    }
}
