using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AaronBriones.User.Services
{
    public class ProductService : Interfaces.IProductService
    {
        public int[] Remove(int position, int[] productIds)
        {
            int[] t = new int[productIds.Length - 1];
            int currentIndex = 0;
            for (int i = 0; i < productIds.Length; i++)
            {
                if (i + 1 == position) continue;
                t[currentIndex] = productIds[i];
                currentIndex++;
            }
            return t;
        }

        public int[] Reverse(int[] productIds)
        {

            int[] t = new int[productIds.Length];
            int currentIndex = 0;
            for(int i = productIds.Length - 1; i >= 0; i--)
            {
                t[currentIndex] = productIds[i];
                currentIndex++;
            }

            return t;

        }
    }
}
