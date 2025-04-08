namespace cookies_cookbook
{
    public class AddIngredient
    {
        // List to store the IDs of ingredients that the user selects
        private List<string> _recipeIngredients = new List<string>{};

        // Method to add ingredients based on user input
        public List<string> AddItem(AvailableIngredients allIngredients) {
            // Keep asking for ingredients until the user types something invalid (non-integer)
            while (true)
            {
                Console.WriteLine("Add an ingredient by it's ID or type anything else if finished.");
                int ingredients = allIngredients._ingredients.Count;
                var userInput = Console.ReadLine();    
                
                // Add new id to ingredient list only if it's in range and is valid input (int)
                if(Int32.TryParse(userInput, out int id) && (id > 0 && id <= ingredients))
                {                    
                    _recipeIngredients.Add(id.ToString()); // Add ID to ingredient list as string
                }
                else{
                    break; // If entry was anything than number end the program
                }
            }

            // If there is no ids (ingredients) entered return empty list<string>
            if(_recipeIngredients.Count == 0){
                return new List<string>();
            }

            // Return new list as comma separated string
            return new List<string>{string.Join(",", _recipeIngredients) };
            
        }
    }
}

