using System;
using System.IO;
using System.Text;

namespace MCInventory
{
    class String: Block, Flammable
    {
        public String(int newCount): base(newCount)
        {
            blockType = "String material";
            classType = this;
            blockImage = "img/stringMaterial_Image.png";
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
        
    }
}