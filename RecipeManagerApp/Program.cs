namespace RecipeManager
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Console.Clear();

            // Instance of recipeManager, to make it possible to use it here
            RecipeManager recipeManager = new RecipeManager();

            // List of recipes, which will first import the saved one from json and export it back updated upon program execution.
            List<Recipe> recipes = new List<Recipe>();

            recipeManager.Add(recipes);

            System.Console.WriteLine(recipes[0].Title);
            return 0;
        }
    }
}