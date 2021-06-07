using System;

namespace MCInventory
{
    class GlassBottle: Block, Crafted
    {
        private Recipe recipe;

        public GlassBottle(int newCount): base(newCount)
        {
            blockType = "Glass bottle block";
            classType = this;
            blockImage = "img/glassBottleBlock_Image.png";
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