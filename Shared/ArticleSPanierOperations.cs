using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.Shared
{
    public static class ArticleSPanierOperations
    {
        public static List<int> ArticleFromPanierResolver(string articles)
        {
            List<int> retrn = new List<int>();
            if (!string.IsNullOrEmpty(articles))
            {
                foreach (var item in articles.Split("_").AsEnumerable())
                {
                    retrn.Add(int.Parse(item));
                }
            }
            return retrn;


        }

        public static string ArticlesIdConcatination(string articles,int NeWarticlesId)
        {

            return articles + "_" + NeWarticlesId;
            

        }
    }
}
