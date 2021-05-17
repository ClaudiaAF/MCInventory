using System;

namespace MCInventory
{
    class GlassBlock: Block
    {
        public GlassBlock(): base()
        {
            blockType = "Glass Block";
        }
        public GlassBlock(int newCount): base(newCount)
        {
            blockType = "Glass block"; 
            classType = this;
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("glass block has been placed");
        }
    }
}