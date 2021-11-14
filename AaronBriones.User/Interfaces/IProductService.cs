using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AaronBriones.User.Interfaces
{
    public interface IProductService
    {
        int[] Reverse(int[] productIds);

        int[] Remove(int position, int[] productIds);

    }
}
