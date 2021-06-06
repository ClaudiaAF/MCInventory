using System;

namespace MCInventory
{
    class WoodPlank: Block, Flammable, Crafted
    {
        private Recipe recipe;

        public WoodPlank(int newCount): base(newCount)
        {
            blockType = "Wood Plank";
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Wood plank has been placed");
        }

        public void Burn()
        {
            Count--;
            Console.WriteLine("wood plank is burning");
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