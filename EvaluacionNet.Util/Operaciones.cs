using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionNet.Util
{
    public class Operaciones
    {
        public static int SumarMultiplosDeTresYCinco(int limite)
        {
            int sum = 0;
            for (int i = 0; i < limite; i++)
            {
                if (i%3==0||i%5==0)
                {
                    sum = sum + i;
                }
            }
            return sum;
        }
    }
}
