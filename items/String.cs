using System;
using System.IO;
using System.Text;

namespace MCInventory
{
    class String: Block, Flammable, Craft
    {
        private Recipe recipe;
        public String(int newCount): base(newCount)
        {
            blockType = "String resource";
            classType = this;
        }

        public override void Place()
        {
            Count --;
            Console.WriteLine("String has been placed");
        }

        public void Burn()
        {
            Console.WriteLine("String is burning");
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