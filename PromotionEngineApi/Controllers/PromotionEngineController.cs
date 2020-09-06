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
                        foreach (var availableOffer in availableOffers)
                        {
                            if (availableOffer.Products.Count > 1)
                            {
                                var applicableOffer = availableOffer.Products.FirstOrDefault(s => s.ProductId == item.ProductId &&
                                s.Quantity <= item.Quantity);
                                if (applicableOffer != null)
                                {
                                    var selectedProductIds = selectedProducts.Select(s => s.ProductId);
                                    var otherOfferProducts = availableOffer.Products.Where(s => s.ProductId != item.ProductId &&
                                     selectedProductIds.Contains(s.ProductId));
                                   
                                    if (otherOfferProducts.Any())
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
                            }
                            else
                            {
                                var applicableOffer = availableOffer.Products.FirstOrDefault(s => s.Quantity <= item.Quantity);
                                if (applicableOffer != null)
                                {
                                    var noOfApplicableOffers = item.Quantity / applicableOffer.Quantity;
                                    var remainingQuantity = item.Quantity % applicableOffer.Quantity;
                                    var productDetail = products.Find(s => s.ProductId == item.ProductId);
                                    var cost = (noOfApplicableOffers * availableOffer.OfferPrice) + (remainingQuantity * productDetail.ProductPrice);
                                    total += cost;

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
                            
                        }

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