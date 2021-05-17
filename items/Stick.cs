using System;

namespace MCInventory
{
    class Stick: Block, Craft
    {
        private Recipe recipe;
        public Stick(int newCount): base(newCount)
        {
            blockType = "Stick material";
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Stick has been placed");
        }

        public Recipe GetRecipe()
        {
            return recipe;
        }

        public void SetRecipes(Recipe newRecipe)
        {
            recipe = newRecipe;
        }
       
    }
}