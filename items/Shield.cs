using System;

namespace MCInventory
{
    class Shield: Block
    {
        private Recipe recipe;
       public Shield(int newCount): base(newCount)
        {
            blockType = "Shield tool";
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Shield has been placed");
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