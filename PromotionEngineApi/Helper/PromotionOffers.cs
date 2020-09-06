using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromotionEngineApi.Model;

namespace PromotionEngineApi.Helper
{
    public static class PromotionOfferMaster
    {
        public static List<ProductOffers> GetProductOffers()
        {
            var list = new List<ProductOffers>
            {

                new ProductOffers {BaseProductId=1, OfferPrice=130,
                    Products = new List<Products>{ new Products {ProductId=1, ProductName="A", Quantity=3}} },
                new ProductOffers {BaseProductId=2, OfferPrice=45,
                    Products = new List<Products>{ new Products { ProductId = 2, ProductName = "B", Quantity = 2 } } },
                 new ProductOffers {BaseProductId=3, OfferPrice=30,
                    Products = new List<Products>{
                        new Products { ProductId = 3, ProductName = "C", Quantity = 1 },
                        new Products { ProductId = 4, ProductName = "D", Quantity = 1 }
                    }
                 },
            };
            return list;
        }
    }
}
