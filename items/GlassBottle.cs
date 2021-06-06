using System;

namespace MCInventory
{
    class GlassBottle: Block, Crafted
    {
        private Recipe recipe;

        public GlassBottle(int newCount): base(newCount)
        {
            blockType = "Glass Bottle";
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Glass bottle has been placed");
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