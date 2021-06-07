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
                    case "WoodAxe tool":
                        newBlock = new WoodAxe(curTuple.Item2);
                        break;
                    case "String material":
                        newBlock = new String(curTuple.Item2);
                        break;
                    case "Flint material":
                        newBlock = new Flint(curTuple.Item2);
                        break;
                    case "Bow tool":
                        newBlock = new Bow(curTuple.Item2);
                        break;
                    case "Wool material":
                        newBlock = new Wool(curTuple.Item2);
                        break;
                    case "Bed block":
                        newBlock = new Bed(curTuple.Item2);
                        break;
                    case "Glass block":
                        newBlock = new GlassBlock(curTuple.Item2);
                        break;
                    case "Glass bottle block":
                        newBlock = new GlassBottle(curTuple.Item2);
                        break;
                    case "Stone shovel tool":
                        newBlock = new StoneShovel(curTuple.Item2);
                        break;
                    case "Cobblestone block":
                        newBlock = new Cobblestone(curTuple.Item2);
                        break;
                    default:
                        newBlock = null;
                        break;
                }
                items.Add(newBlock);
            }
        }

        public ArrayList Items
        {
            get 
            {
                return items;
            }
        }

        public static Block GetClass(string index)
        {
            foreach (Block curItem in items)
            {
                if (curItem.BlockType == index )
                    return curItem;
            }
            return null;
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