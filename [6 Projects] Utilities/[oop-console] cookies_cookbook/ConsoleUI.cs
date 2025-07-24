namespace cookies_cookbook
{
    public class ConsoleUI{
        private readonly AvailableIngredients _ingredients;

        // Constructor initializes the list of available ingredients
        public ConsoleUI(AvailableIngredients ingredients)
        {
            _ingredients = ingredients;
        }

        public void UI(AddIngredient ingredient, FileOperation file){

            // Read existing recipes from the file (either TXT or JSON)
            file.ReadFromFile();

            Console.WriteLine("Create a new cookie recipe! Available ingredient are:");
            // Display the list of ingredients that are available
            _ingredients.IngredientList();

            // Add ingredients to the recipe (the method will return the list of selected ingredient IDs)
            var addedIngredients = ingredient.AddItem(_ingredients);

            // If any ingredients were added, save the new recipe to the file
            if (addedIngredients.Count > 0){
                file.SaveToFile(addedIngredients); // save to the file
                Console.WriteLine("Recipe added:");
                // Display the preparation steps for the added ingredients
                _ingredients.IngredientPrep(addedIngredients);                    
            }
        }
    }
}

