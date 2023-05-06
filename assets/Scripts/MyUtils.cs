using System;
using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public static class MyUtils
    {
        private static readonly Random Rng = new Random();  
        
        public static void Shuffle<T>(this IList<T> list)  
        {  
            var n = list.Count;  
            while (n > 1) {  
                n--;  
                var k = Rng.Next(n + 1);  
                (list[k], list[n]) = (list[n], list[k]);
            }  
        }
        
        public static int Pow(this int bas, int exp)
        {
            return Enumerable
                .Repeat(bas, exp)
                .Aggregate(1, (a, b) => a * b);
        }
    }
}