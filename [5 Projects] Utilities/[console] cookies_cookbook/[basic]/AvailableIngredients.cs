namespace cookies_cookbook
{
    public class AvailableIngredients
    {
        // List of available ingredients with their name and preparation instructions
        public List<(string name, string ingredient)> _ingredients { get; } = new List<(string, string)>{
            ("Wheat flour", "Sieve. Add to other ingredients."), 
            ("Coconut flour", "Sieve. Add to other ingredients."),
            ("Butter", "Melt on low heat. Add to other ingredients."),
            ("Chocolate", "Melt in a water bath. Add to other ingredients."),
            ("Sugar", "Add to other ingredients."),
            ("Cardamom", "Take half a teaspoon. Add to other ingredients."),
            ("Cinnamon", "Take half a teaspoon. Add to other ingredients."),
            ("Cocoa powder", "Add to other ingredients."),
        };

        // Display the available ingredients list
        public void IngredientList(){
            for(var i = 0; i < _ingredients.Count; i++)
            {
                // Show each ingredient's number and name
                Console.WriteLine($"{i+1}. {_ingredients[i].name}");
            } 
        }

        // Display the preparation steps for the ingredients in the given list of IDs
        public void IngredientPrep(List<string> ids)
        {
            // Loop through the list of selected IDs (ingredients) and print the preparation steps
            for (var i = 0; i < _ingredients.Count; i++)
            {
                // Check if the current ID exists in the list of selected ingredient IDs
                if (ids[0].Contains((i + 1).ToString()))
                {
                    // Print the preparation steps for the ingredient
                    Console.WriteLine($"{_ingredients[i].name}.{_ingredients[i].ingredient}");
                }
            }
        }
    }
}
    