using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        public int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            //return -1;
            double k = 0;
            if (productType == 1)
            {
                k = 1.1;
            }
            else if (productType == 2)
            {
                k = 2.5;
            }
            else if (productType == 3)
            {
                k = 8.43;
            }
            else
            {
                k = -1;
            }

            double brak = 0;
            if (materialType == 1)
            {
                brak = 1.003;
            }
            else if (materialType == 2)
            {
                brak = 1.00012;
            }
            else
            {
                brak = -1;
            }
            double rez = 0;
            if (k==-1||brak==-1||count<=0||width<=0||length<=0)
            {
                return -1;
            }
            rez = (count * width * length * k * brak);
            rez = rez % 1 == 0 ? rez : rez - rez % 1 + 1;
            return (int)rez;
        }
    }
}
