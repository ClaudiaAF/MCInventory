using System;

namespace MCInventory
{
    class Bow: Block, Crafted
    {
        private Recipe recipe;

        public Bow(int newCount): base(newCount)
        {
            blockType = "Bow tool";
            classType = this;
            blockImage = "img/bowTool_Image.png";
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Bow tool has been placed");
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