using System;

namespace MCInventory
{
    class Cobblestone: Block, Flammable
    {
        public Cobblestone(int newCount): base(newCount)
        {
            blockType = "Cobblestone block";
            classType = this;
            blockImage = "img/cobblestoneBlock_Image.png";
        }

        public override void Place()
        {
            Count--;
        }

        public void Burn()
        {
            Count--;
        }

    }
}