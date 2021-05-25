using System;
using System.Collections;

namespace MCInventory
{
    class RecipeBook
    {
        private static ArrayList recipes = new ArrayList();

        public static void Populate()
        {

            ArrayList records = Database.ReadRecipes();

            // foreach (Tuple<string.string[,]> curTuple in records)
            // {
            //     Recipe curRecipe = new Recipe((Crafted) Inventory.GetClass(cuTuple.Item1), new Block[3,3]
            //         {{Inventory.GetClass(curTuple.Item2[0,0]),Inventory.GetClass(curTuple.Item2[0,1])},
            //         {Inventory.GetClass(curTuple.Item2[0,2]),Inventory.GetClass(curTuple.Item2[1,0])},
            //         {Inventory.GetClass(curTuple.Item2[1,1]),Inventory.GetClass(curTuple.Item2[1,2])},
            //         {Inventory.GetClass(curTuple.Item2[2,0]), Inventory.GetClass(curTuple.Item2[2,1])},
            //         {Inventory.GetClass(curTuple.Item2[2,2])}});

            //     recipes.Add(curRecipe);
            // }

            public static ArrayList Recipes
            {
                get{
                    return recipes
                }
            }

            public static void AddRecipe(Recipe recipe)
            {
                string blockType = recipe.Result.BlockType;

                bool newRecipe = true;
                foreach (Recipe curRecipe in recipes)
                {
                    if (curRecipe.Result.BlockType == blockType)
                        newRecipe = false;
                }

                if (newRecipe)
                {
                    recipes.Add(recipe);
                    Database.AddRecipe(recipe);

                }
            }



            axe recipe
            Recipe axeRecipe = new Recipe((Craft) WoodAxe.Get(), new Block[3,3] {{WoodBlock.Get(), WoodBlock.Get(), null}, 
                                                                {WoodBlock.Get(), Stick.Get(), null},
                                                                {null, Stick.Get(), null}});
            recipes.Add(axeRecipe);

            //glass bottle recipe
            Recipe glassBottleRecipe = new Recipe((Craft) GlassBottle.Get(), new Block[2,2] {{GlassBlock.Get(), null}, 
                                                                {GlassBlock.Get(), null}});
            recipes.Add(glassBottleRecipe);

            //wood plank recipe
            Recipe woodPlankRecipe = new Recipe((Craft) WoodPlank.Get(), new Block[1,1] {{WoodBlock.Get()}});
            recipes.Add(woodPlankRecipe);

            //wood sword recipe
            Recipe woodSwordRecipe = new Recipe((Craft) WoodSword.Get(), new Block[3,3] {{WoodBlock.Get(), WoodBlock.Get(), null}, 
                                                                {WoodBlock.Get(), Stick.Get(), null},
                                                                {null, Stick.Get(), null}});
            recipes.Add(woodSwordRecipe);

            //shield recipe
            Recipe shieldRecipe = new Recipe((Craft) Shield.Get(), new Block[3,3] {{WoodPlank.Get(), WoodPlank.Get(), null}, 
                                                                {WoodPlank.Get(), WoodPlank.Get(), null},
                                                                {null, IronIngot.Get(), null}});
            recipes.Add(shieldRecipe);

            //flint and steel recipe
            Recipe flintAndSteelRecipe = new Recipe((Craft) FlintAndSteel.Get(), new Block[2,2] {{IronIngot.Get(), null}, 
                                                                {Flint.Get(), null}});
            recipes.Add(flintAndSteelRecipe);

            //stone shovel recipe
            Recipe stoneShovelRecipe = new Recipe((Craft) StoneShovel.Get(), new Block[3,3] {{StoneBlock.Get(), StoneBlock.Get(), null}, 
                                                                {Stick.Get(), Stick.Get(), null},
                                                                {null, Stick.Get(), null}});
            recipes.Add(stoneShovelRecipe);

            //wool recipe
            Recipe woolRecipe = new Recipe((Craft) Wool.Get(), new Block[2,3] {{String.Get(), String.Get(), null}, 
                                                                {String.Get(), String.Get(), null}});
            recipes.Add(woolRecipe);

            //bed recipe
            Recipe bedRecipe = new Recipe((Craft) Bed.Get(), new Block[3,3] {{Wool.Get(), Wool.Get(), null}, 
                                                                {Wool.Get(), WoodPlank.Get(), null},
                                                                {WoodPlank.Get(), WoodPlank.Get(), null}});
            recipes.Add(bedRecipe);

        }

        public static ArrayList Recipes
        {
            get{
                return recipes;
            }
        }
    }
}