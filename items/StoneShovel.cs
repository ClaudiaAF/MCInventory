using System;

namespace MCInventory
{
    class StoneShovel: Block, Crafted
    {

        private Recipe recipe;
        public StoneShovel(int newCount): base(newCount)
        {
            blockType = "Stone shovel tool";      
            blockImage = "img/stoneShovelTool_Image.png";      
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