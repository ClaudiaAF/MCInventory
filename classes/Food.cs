using System;

namespace MCInventory
{
    abstract class Food
    {
        private int count;
        protected string foodType;

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
            }
        }

        public string FoodType
        {
            get
            {
                return foodType;
            }
        }

        public Food()
        {
            count = 0;
        }

        public Food(int newCount)
        {
            count = newCount;

        }

        public abstract void Place();
    }
}