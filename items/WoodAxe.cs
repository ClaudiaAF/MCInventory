using System;

namespace MCInventory
{
    class WoodAxe: Block, Crafted
    {
        private Recipe recipe;

        public WoodAxe(int newCount): base(newCount)
        {
            blockType = "WoodAxe tool";
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("woodaxe has been placed");
        }

        public void SetRecipes(Recipe newRecipe)
        {
            recipe = newRecipe;
        }

        public Recipe GetRecipe()
        {
            return recipe;
        }
    }
}