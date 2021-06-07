using System;

namespace MCInventory
{
    class Flint: Block, Crafted
    {

        private Recipe recipe;
        public Flint(): base()
        {
            blockType = "Flint material";
        }
        public Flint(int newCount): base(newCount)
        {
            blockType = "Flint material"; 
            classType = this;
            blockImage = "img/flintTool_Image.png";
        }

        public override void Place()
        {
            Count--;
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