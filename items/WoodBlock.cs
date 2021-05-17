using System;

namespace MCInventory
{
    class WoodBlock: Block, Flammable, Furnace
    {
        public WoodBlock(int newCount): base(newCount)
        {
            blockType = "Wood Block";
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Wood block has been placed");
        }

        public void Burn()
        {
            Count--;
            Console.WriteLine("wood is burning");
        }

        public Block Melt()
        {
            Count--;
            Console.WriteLine("wood melts into coal");
            return new Coal(1);
        }
    }
}