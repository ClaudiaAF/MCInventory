using System;

namespace MCInventory
{
    abstract class Weapons
    {
        private int count;
        protected string weponType;

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

        public string WeaponType
        {
            get
            {
                return weponType;
            }
        }

        public Weapons()
        {
            count = 0;
        }

        public Weapons(int newCount)
        {
            count = newCount;

        }

        public abstract void Place();
    }
}