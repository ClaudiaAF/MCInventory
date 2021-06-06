using System;

namespace MCInventory
{
    class StoneBlock: Block, Crafted
    {
        private Recipe recipe;
        public StoneBlock(int newCount): base(newCount)
        {
            blockType = "Stone Block";
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Stone block has been placed");
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