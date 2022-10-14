using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHW1
{
    internal static class MiniCafeService
    {
        public static float  total_price = 0 ;
        public static float hot_dog_check(string quantity)
        {
            quantity = quantity.Trim();
            float quantity_int;
            bool check = float.TryParse(quantity,out quantity_int );
            if (check)
            {
                float total = (float)(quantity_int * 1.5);
                return total;
            }
            else return 0;
        }
        public static float hamburger_check(string quantity)
        {
            quantity = quantity.Trim();
            float quantity_int;
            bool check = float.TryParse(quantity, out quantity_int);
            if (check)
            {
                float total = (float)(quantity_int * 2.5);
                return total;
            }
            else return 0;
        }
        public static float fries_check(string quantity)
        {
            quantity = quantity.Trim();
            float quantity_int;
            bool check = float.TryParse(quantity, out quantity_int);
            if (check)
            {
                float total = (float)(quantity_int * 2);
                return total;
            }
            else return 0;
        }
        public static float cocacola_check(string quantity)
        {
            quantity = quantity.Trim();
            float quantity_int;
            bool check = float.TryParse(quantity, out quantity_int);
            if (check)
            {
                float total = (float)(quantity_int * 1);
                return total;
            }
            else return 0;
        }
    }
}
