using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionEngineApi.Helper;
using PromotionEngineApi.Model;

namespace PromotionEngineApi.Controllers
{
    [Produces("application/json")]
    [Route("api/PromotionEngine")]
    public class PromotionEngineController : Controller
    {
        public decimal ApplyPromotionOffer(List<Products> selectedProducts)
        {
            decimal total = 0;
            var products = ProductMaster.GetProducts();
            var productOffers = PromotionOfferMaster.GetProductOffers();
            foreach (var item in selectedProducts)
            {
               
                    var availableOffers = productOffers.Where(s => s.BaseProductId == item.ProductId);
                    if (availableOffers.Any())
                    {
                       
                    }
                    else
                    {
                        var productDetail = products.FirstOrDefault(s => s.ProductId == item.ProductId);
                        if (productDetail != null)
                        {
                            var cost = item.Quantity * productDetail.ProductPrice;
                            total += cost;

                        }
                    }
                
            }
            return total;
        }                 
    }
}