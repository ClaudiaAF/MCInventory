using System;
using System.IO;
using System.Text;

namespace MCInventory
{
    class Coal: Block, Flammable
    {
        public Coal(int newCount): base(newCount)
        {
            blockType = "Coal resource";
            classType = this;
        }

        public override void Place()
        {
            Count --;
            Console.WriteLine("Coal has been placed");
        }

        public void Burn()
        {
            Console.WriteLine("Coal is burning");
        }
    }
}