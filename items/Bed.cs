using System;
using System.IO;
using System.Text;

namespace MCInventory
{
    class Bed: Block, Crafted
    {
        private Recipe recipe;
        public Bed(int newCount): base(newCount)
        {
            blockType = "Bed block";
            classType = this;
            blockImage = "img/bedBlock_Image.png";
        }

        public override void Place()
        {
            Count --;
            Console.WriteLine("Bed has been placed");
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