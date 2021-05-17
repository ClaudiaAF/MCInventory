using System;

namespace MCInventory
{
    class Flint: Block, Craft
    {

        private Recipe recipe;
        public Flint(): base()
        {
            blockType = "Flint Block";
        }
        public Flint(int newCount): base(newCount)
        {
            blockType = "Flint block"; 
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Flint block has been placed");
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