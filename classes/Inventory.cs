using System;
using System.Collections;

namespace MCInventory
{
    class Inventory
    {
        public static ArrayList items = new ArrayList();

        public Inventory()
        {

            ArrayList data = Database.ReadBlocks();
            foreach (Tuple<string,int> curTuple in data)
            {
                Block newBlock;
                switch (curTuple.Item1)
                {
                    case "Wood block":
                        newBlock = new WoodBlock(curTuple.Item2);
                        break;
                    case "Stick material":
                        newBlock = new Stick(curTuple.Item2);
                        break;
                    case "WoodAxe Tool":
                        newBlock = new WoodAxe(curTuple.Item2);
                        break;
                    default:
                        newBlock = null;
                        break;
                }
                items.Add(newBlock);
            }
            

            // items.Add(new Coal(10));
            // items.Add(new GlassBlock(1));
            // items.Add(new IronBlock(8));
            // items.Add(new IronIngot(5));
            // items.Add(new SandBlock(4));
            // items.Add(new StoneBlock(6));
            // items.Add(new WoodBlock(10));   
            // items.Add(new Stick(0));
            // items.Add(new WoodAxe(8));  
            // items.Add(new GlassBottle(2));    
            // items.Add(new WoodSword(1));    
            // items.Add(new WoodPlank(10));   
            // items.Add(new Shield(1));  
            // items.Add(new Flint(2));  
            // items.Add(new StoneShovel(2));
            // items.Add(new Wool(4)); 
            // items.Add(new String(7));
            // items.Add(new Bed(1));
        }

        public ArrayList Items
        {
            get 
            {
                return items;
            }
        }

        public static int GetCount(string index)
        {
            foreach (Block curItem in items)
            {
                if (curItem.BlockType == index)
                    return curItem.Count;
            }

            return -1;
        }
    }
}