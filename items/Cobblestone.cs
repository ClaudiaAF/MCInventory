using System;

namespace MCInventory
{
    class Cobblestone: Block
    {
        public Cobblestone(int newCount): base(newCount)
        {
            blockType = "Cobblestone block";
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Cobbelstone has been placed");
        }
    }
}