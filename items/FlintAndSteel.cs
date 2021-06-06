using System;

namespace MCInventory
{
    class FlintAndSteel: Block, Crafted, Flammable
    {

        private Recipe recipe;
        public FlintAndSteel(): base()
        {
            blockType = "FlintAndSteel Block";
        }
        public FlintAndSteel(int newCount): base(newCount)
        {
            blockType = "FlintAndSteel block"; 
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("FlintAndSteel block has been placed");
        }

        public void Burn()
        {
            Count--;
            Console.WriteLine("FlintAndSteel is burning");
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