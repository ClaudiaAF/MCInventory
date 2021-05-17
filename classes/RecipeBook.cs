using System;
using System.Collections;

namespace MCInventory
{
    class RecipeBook
    {
        private static ArrayList recipes = new ArrayList();

        public static void Populate()
        {
            //axe recipe
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