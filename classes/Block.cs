using System;

namespace MCInventory
{
    abstract class Block
    {
        private int count;
        protected string blockType;
        protected string blockImage;
        protected static Block classType;

        public int Count 
        {
            get 
            {
                return count;
            }
            set
            {
                if (value < 0)
                    count = -value;
                else
                    count = value;

                Database.UpdateBlockCount(blockType, count);

            }
        }

        public string BlockType
        {
            get
            {
                return blockType;
            }
        }

        public string BlockImage
        {
            get
            {
                return blockImage;
            }
        }

        public Block()
        {
            count = 0;
        }

        public Block(int newCount)
        {
            count = newCount;

        }

        public abstract void Place();

        public static Block Get()
        {
            return classType;
        }
    }
}