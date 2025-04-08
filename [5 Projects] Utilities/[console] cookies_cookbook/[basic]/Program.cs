using cookies_cookbook;

// Initialize the available ingredients, UI, and file operations
ConsoleUI ui = new ConsoleUI(new AvailableIngredients());
// AddIngredient to manage adding ingredients
AddIngredient newIngreadient = new();

// Use TXT or JSON file to save/read data (switch between then by commenting out one of them)
//JSONFileOperation file = new(new AvailableIngredients());
TXTFileOperation file = new(new AvailableIngredients());

// Start the user interface interaction with the AddIngredient and file operations
ui.UI(newIngreadient, file);

