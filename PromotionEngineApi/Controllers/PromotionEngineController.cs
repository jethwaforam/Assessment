using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PromotionEngineApi.Model;

namespace PromotionEngineApi.Controllers
{
    [Produces("application/json")]
    [Route("api/PromotionEngine")]
    public class PromotionEngineController : Controller
    {
        public decimal ApplyPromotionOffer(List<Products> selectedProducts)
        {                        
            return 0;
        }                 
    }
}