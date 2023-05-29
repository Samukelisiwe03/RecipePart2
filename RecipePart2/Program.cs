using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RecipePart2
{
    class Ingredient
    {

        public int CalculateTotalCalories() // Calculates and displays the total calories of the ingredients in a recipe
        {
            int totalCalories = 0;
            foreach(var ingredient in ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories; // shows calculated calories
        }
         public void DisplayRecipe()
        {
            Console.WriteLine("Recipe: " + Name);
            Console.WriteLine("Ingredients: ");
                       foreach(var ingredient in ingredients)
            {
                Console.WriteLine("- "+ ingredient.Name);
                Console.WriteLine("Quantity: " + ingredient.Quantity);
                Console.WriteLine("Unit: " + ingredient.Unit);
                Console.WriteLine("Calories: " + ingredient.Calories);
                Console.WriteLine("FoodGroup: " + ingredient.FoodGroup);
            }

            Console.WriteLine("STEPS:");
            for(int i = 0; i <Steps.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + Steps[i]);

            }

            Console.WriteLine("Total Calories: "+ CalculateTotalCalories());// Gives you the total calories

                     if(CalculateTotalCalories() > 300) 
            {

                Console.WriteLine("NOTE: Recipe exeeds 300 calories."); //Notifies user when the total calories of a recipe exeeds 300
            }

        }

        public void ScaleRecipe(double scale)
        {
            foreach(var ingredient in ingredient)
            {
                ingredient.Quantity *= scale;
            }
        }



        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double OriginalQuantity { get; set; }
        public string FoodGroup { get; set; }
        public int Calories { get; set; }

        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            OriginalQuantity = quantity;
            FoodGroup = foodGroup;
            Calories = calories;
        }



        class Recipes {

            public List<Recipes> recipes;

                     public Recipes()
            {
                recipes = new List<Recipes>();
            }

                        public void AddRecipes(Recipes recipes)
            {
                recipes.Add(recipes);
            }
             public void DisplayRecipesList()
            {
                recipes.Sort((r1, r2) => r1.Name.CompareTo(r2.Name));
                Console.WriteLine("Recipes List": );
                foreach(var recipes in recipes)
                {
                    Console.WriteLine(recipes);
                }
                Console.WriteLine();
            }

            public void DisplayRecipesDetails(string recipesName)
            {
                Recipes recipe = recipes.Find(r => r.Name == recipesName);
                      if(recipes!= null)
                {
                    recipes.DisplayRecipe();
                }
                else
                {
                    Console.WriteLine("Recipe Is Not Found");
                }

            }



            public void Add(Recipes recipe)
            {
                recipes.Add(recipe);
            }

        }


        class Recipe
        {
            private Ingredient[] ingredients;
            private string[] steps;
            private double scaleFactor = 1.0;

            public void AddIngredients(int count)
            {
                ingredients = new Ingredient[count];
                for (int i = 0; i < count; i++)
                {
                    Console.Write("Enter ingredient name: "); // This adds the ingredients of your choice
                    string name = Console.ReadLine();

                    Console.Write("Enter Quantity: "); // Can type the quantity
                    double quantity = double.Parse(Console.ReadLine());

                    Console.Write("Enter unit of Measurement: "); // This line adds the unit of measurement that you want to enter
                    string unit = Console.ReadLine();

                    ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };

                }
            }
            class Steps
            {
                public string Description { get; set; } // Decsribe in detail each of the steps 
            }
            public void AddSteps(int count)
            {
                steps = new string[count];
                for (int i = 0; i < count; i++)
                {
                    Console.Write("Enter steps" + (i + 1) + ":");
                    Console.Write("Description: ");
                    steps[i] = Console.ReadLine();
                    string stepDescription = Console.ReadLine();

                }
            }
            public void DisplayRecipe() //displays display of recipe
            {
                Console.WriteLine("Ingredients: ");
                foreach (Ingredient ingredients in ingredients)
                {
                    Console.WriteLine(ingredients.Quantity * scaleFactor + "" + ingredients.Unit + "of" + ingredients.Name);
                }

                Console.WriteLine("Steps: ");
                for (int i = 0; i < steps.Length; i++)
                {
                    Console.WriteLine(steps[i] + (i + 1) + ":");
                }
            }

            public void ScaleRecipe()
            {
                scaleFactor = 1;
                foreach (Ingredient ingredient in ingredients)
                {
                    ingredient.Quantity = ingredient.OriginalQuantity;
                }
            }

            public void ClearRecipe() //Clears the whole recipe
            {
                ingredients = null;
                steps = null;
                scaleFactor = 1;
            }

        }



        class Program
        {
            static void Main(string[] args)
            {
                Recipe recipe = new Recipe();

                Console.ForegroundColor = ConsoleColor.White;// This sets the color of your choice
                Console.WriteLine("------------------");
                Console.WriteLine("MENU");
                Console.WriteLine("------------------");
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("1. Enter Ingredients"); //Displays the menu and which number you want to pick
                    Console.WriteLine("2. Enter Steps");
                    Console.WriteLine("3. Display Recipe");
                    Console.WriteLine("4. Scale Recipe");
                    Console.WriteLine("5. Reset Scale");
                    Console.WriteLine("6. Clear Recipe");
                    Console.WriteLine("7. Exit");
                    Console.WriteLine("---------------------");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (choice)
                    {

                        case 1:
                            Console.Write("Enter number of ingredients: ");
                            int ingredientCount = int.Parse(Console.ReadLine());
                            recipe.AddIngredients(ingredientCount);
                            Console.WriteLine();
                            break;

                        case 2:
                            Console.Write("Enter the number of steps:");
                            int stepCount = int.Parse(Console.ReadLine());
                            recipe.AddSteps(stepCount);
                            Console.WriteLine();
                            break;

                        case 3:
                            Console.Write("Display the recipe:");
                            int displayCount = int.Parse(Console.ReadLine());
                            recipe.Equals(displayCount);
                            Console.WriteLine();
                            break;

                        case 4:
                            Console.Write("Scale Recope");
                            int scaleRecipe = int.Parse(Console.ReadLine());
                            recipe.Equals(scaleRecipe);
                            Console.WriteLine();
                            break;

                        case 5:
                            Console.Write("Reset Scale");
                            int ResetScale = int.Parse(Console.ReadLine());
                            recipe.Equals(ResetScale);
                            Console.WriteLine();
                            break;
                        case 6:
                            Console.Write("Clear Recipe");
                            int ClearRecipe = int.Parse(Console.ReadLine());
                            recipe.ClearRecipe();
                            break;
                        case 7:
                            Console.Write("Exit");
                            int Exit = int.Parse(Console.ReadLine());
                            recipe.Equals(Exit);
                            Console.WriteLine();
                            break;
                    }
                }
            }
        }
    }
}

                
                   
            
        

