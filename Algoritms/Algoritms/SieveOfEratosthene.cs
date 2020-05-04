using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms
{
    public class SieveOfEratosthene
    {
        public static IEnumerable<int> Siev (int max)
        {
            bool[] composete = new bool[max + 1];
            for (int p = 2; p <= max; p++)
            {
                if(composete[p])
                    continue;
                yield return p;
                for (int i = p * p; i <= max; i+=p)
                {
                    composete[i] = true;
                }
            }

            
        }
    }
}
