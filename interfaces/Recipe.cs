using System;
using System.Collections.Generic;

namespace MCInventory
{
    class Recipe
    {
        private Block[,] inputs;
        private Craft result;

        public Recipe(Craft newResult, Block[,] newInputs)
        {
            inputs = newInputs;
            result = newResult;
            result.SetRecipes(this);
        }

        public Block[,] Inputs
        {
            get
            {
                return inputs;
            }
        }

        public Block Result
        {
            get
            {
                return (Block) result;
            }
        }

        public bool IsVisable()
        {
            var map = new Dictionary<string, int>();

            foreach (Block curBlock in inputs)
            {
                if (curBlock != null)
                {
                    int count;
                    if (map.TryGetValue(curBlock.BlockType, out count))
                    {
                        map[curBlock.BlockType] += 1;
                    }
                    else
                    {
                        map.Add(curBlock.BlockType,1);
                    }
                }
            }

            bool result = true;
            foreach (var pair in map)
            {
                if (pair.Value > Inventory.GetCount(pair.Key))
                    result = false;
            }

            return result;
        }
    }
}