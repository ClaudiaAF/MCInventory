using System;

namespace MCInventory
{
    class WoodSword: Block, Craft
    {
        private Recipe recipe;
       public WoodSword(int newCount): base(newCount)
        {
            blockType = "Sword tool";
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Wood block has been placed");
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