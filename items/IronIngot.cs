using System;

namespace MCInventory
{
    class IronIngot: Block, Craft
    {

        private Recipe recipe;
        public IronIngot(): base()
        {
            blockType = "Glass Block";
        }
        public IronIngot(int newCount): base(newCount)
        {
            blockType = "Glass block"; 
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("glass block has been placed");
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