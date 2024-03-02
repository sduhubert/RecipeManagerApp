using System.IO.Compression;
using System.Xml.Serialization;

namespace RecipeManager
{
    public interface IRecipe
    {
        // Specifies methods for adding, viewing, updating, and categorizing recipes.
        void Add(List<Recipe> recipes);
        void View(List<Recipe> recipes);
    }

    public interface IRecipeStorage
    {
        // Specifies methods for loading and saving recipe data.
    }

    public class Recipe
    {
        public Guid Id;
        public string Title;
        public List<string> Ingredients;
        public string Instructions;
        public string Category;

        public Recipe(Guid id, string title, List<string> ingredients, string instructions, string category)
        {
            Id = id;
            Title = title;
            Ingredients = ingredients;
            Instructions = instructions;
            Category = category;
        }
    }

    public class RecipeManager : IRecipe
    {
        // Includes functionality to add, update, categorize, and search for recipes.
        public void Add(List<Recipe> recipes)
        {
            string? enteredTitle;
            string? enteredIngredient;
            List<string> enteredIngredients = new List<string>();
            string? enteredInstructions;
            string? enteredCategory;

            Console.Clear();
            Console.WriteLine("Enter your recipe's title: ");
            enteredTitle = Console.ReadLine();

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Enter the ingredients, separating each one with the 'enter' key.\nWrite 'f' to finish entering them.");
                enteredIngredient = Console.ReadLine();

                if(enteredIngredient.ToLower() == "f") break;
                else enteredIngredients.Add(enteredIngredient);
            }

            Console.Clear();
            Console.WriteLine("Enter the instructions: ");
            enteredInstructions = Console.ReadLine();


            Console.Clear();
            Console.WriteLine("Enter the category of your recipe: ");
            enteredCategory = Console.ReadLine();

            Recipe newRecipe = new Recipe(Guid.NewGuid(), enteredTitle, enteredIngredients, enteredInstructions, enteredCategory);
            recipes.Add(newRecipe);
        }

        public void View(List<Recipe> recipes)
        {
            Console.Clear();

            // Checking if there are any recipes saved
            if(recipes.Count > 0)
            {
                int choice = 0;
                bool isChoiceCorrect = false;

                while(!isChoiceCorrect)
                {
                    int i = 1;
                    foreach(Recipe recipe in recipes)
                    {
                        System.Console.WriteLine($"{i}. {recipe.Title}");
                        i++;
                    }
                    System.Console.WriteLine($"\n{i}. Exit");

                    System.Console.Write("\nChoose the recipe to view: ");

                    // Checking if the entered text is a number, higher than 0 and lower or equal to the last option.
                    isChoiceCorrect = int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= i;
                    if(choice == i) return;
                }

                // Writing out the recipe.
                Console.Clear();
                System.Console.WriteLine(recipes[choice-1].Title.ToUpper());
                System.Console.WriteLine($"\nIngredients:");
                foreach(string ingredient in recipes[choice-1].Ingredients) System.Console.WriteLine($"{ingredient},");
                System.Console.WriteLine($"\nInstructions:\n{recipes[choice-1].Instructions}");
            }
            else
            {
                System.Console.WriteLine("You currently don't have any recipes saved.");
            }
        }
    }

    public class JsonRecipeStorage : IRecipeStorage
    {
        // Includes functionality to read from and write to a recipes.json file.
    }
}