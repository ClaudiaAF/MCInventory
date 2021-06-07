using System;
using System.IO;
using System.Text;

namespace MCInventory
{
    class Wool: Block, Flammable
    {
        private Recipe recipe;
        public Wool(int newCount): base(newCount)
        {
            blockType = "Wool material";
            classType = this;
            blockImage = "img/woolMaterial_Image.png";
        }

        public override void Place()
        {
            Count --;
            Console.WriteLine("Wool has been placed");
        }

        public void Burn()
        {
            Console.WriteLine("Wool is burning");
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