using System;

namespace MCInventory
{
    class GlassBlock: Block
    {
        public GlassBlock(): base()
        {
            blockType = "Glass block";
           
        }
        public GlassBlock(int newCount): base(newCount)
        {
            blockType = "Glass block"; 
            classType = this;
            blockImage = "img/glassBlock_Image.png";
        }

        public override void Place()
        {
            Count--;
            Console.WriteLine("glass block has been placed");
        }
    }
}