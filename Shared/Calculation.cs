using MyAxiaMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.Shared
{
    public static class Calculation
    {
        public static decimal Total(List<Article> articles)
        {
            decimal sum = 0;
            foreach (var item in articles)
            {
                if(item.price > 0)
                {
                    sum = sum + item.price;
                }
            }
            return sum;
        }
        public static decimal AddTaxes(decimal total, decimal taxe)
        {
            decimal withTaxes = 0;
            withTaxes = total + total * taxe;
            return withTaxes;
        }
    }
}
