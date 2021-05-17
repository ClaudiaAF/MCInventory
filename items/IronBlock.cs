using System;

namespace MCInventory
{
    class IronBlock: Block, Furnace
    {
        public IronBlock(): base()
        {
            blockType = "Iron Block";
        }
        public IronBlock(int newCount): base(newCount)
        {
            blockType = "Iron block"; 
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("Iron block has been placed");
        }

         public Block Melt()
        {
            Count--;
            Console.WriteLine("iron block melts into iron ingot");
            return new IronIngot(1);
        }
    }
}