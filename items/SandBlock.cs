using System;

namespace MCInventory
{
    class SandBlock: Block
    {
        public SandBlock(int newCount): base(newCount)
        {
            blockType = "Sand block";
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("sand block has been placed");
        }

        public Block Melt()
        {
            Count--;
            Console.WriteLine("sand is being melted");
            return new GlassBlock(1);
        }
    }
}