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
            return total;
        }                 
    }
}