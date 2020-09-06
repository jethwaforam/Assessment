using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromotionEngineApi.Model;

namespace PromotionEngineApi.Helper
{
    public static class ProductMaster
    {
        public static List<Products> GetProducts()
        {
            var list = new List<Products>
            {
                new Products {ProductId=1, ProductName="A", Quantity=1, ProductPrice=50},
                new Products {ProductId=2, ProductName="B", Quantity=1, ProductPrice=30},
                new Products {ProductId=3, ProductName="C", Quantity=1, ProductPrice=20},
                new Products {ProductId=4, ProductName="D", Quantity=1, ProductPrice=15}

            };
            return list;
        }
    }
}
