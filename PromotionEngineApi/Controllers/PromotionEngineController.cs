using System.Collections.Generic;
using System.Linq;
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
                                    decimal comboTotal = 0;
                                    if (otherOfferProducts.Any())
                                    {
                                        var noOfBaseApplicableOffers = item.Quantity / applicableOffer.Quantity;
                                        var minAllowedOffer = noOfBaseApplicableOffers;
                                        var flag = false;
                                        foreach (var otherOfferProd in otherOfferProducts)
                                        {
                                            var otherSelectedProducts = selectedProducts.FirstOrDefault(s => s.ProductId == otherOfferProd.ProductId && s.Quantity >= otherOfferProd.Quantity);
                                            if (otherSelectedProducts == null) { flag = false; break; }
                                            else
                                            {
                                                var noOfApplicableOffers = otherSelectedProducts.Quantity / otherOfferProd.Quantity;
                                                var remainingQuantity = otherSelectedProducts.Quantity % otherOfferProd.Quantity;

                                                if (minAllowedOffer > noOfApplicableOffers)
                                                {
                                                    minAllowedOffer = noOfApplicableOffers;


                                                }
                                                remainingQuantity = otherSelectedProducts.Quantity >= otherOfferProd.Quantity * minAllowedOffer ?
                                                        otherSelectedProducts.Quantity - otherOfferProd.Quantity * minAllowedOffer
                                                        : otherSelectedProducts.Quantity;
                                                //var remainingQuantity = otherSelectedProducts.Quantity % otherOfferProd.Quantity;
                                                var productDetail = products.Find(s => s.ProductId == otherOfferProd.ProductId);
                                                var cost = remainingQuantity * productDetail.ProductPrice;
                                                comboTotal += cost;
                                                flag = true;
                                            }


                                        }
                                        if (flag)
                                        {
                                            // var noOfApplicableOffers = item.Quantity / applicableOffer.Quantity;
                                            //var remainingQuantity = item.Quantity % applicableOffer.Quantity;
                                            var remainingQuantity = item.Quantity >= applicableOffer.Quantity * minAllowedOffer ?
                                                         item.Quantity - applicableOffer.Quantity * minAllowedOffer
                                                         : item.Quantity;
                                            var productDetail = products.Find(s => s.ProductId == item.ProductId);
                                            var cost = (minAllowedOffer * availableOffer.OfferPrice) + (remainingQuantity * productDetail.ProductPrice);
                                            comboTotal += cost;
                                            total += comboTotal;
                                            var processedItem = otherOfferProducts.Select(s => s.ProductId);
                                           

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