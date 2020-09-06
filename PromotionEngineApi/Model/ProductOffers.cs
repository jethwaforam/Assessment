using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineApi.Model
{
    public class ProductOffers    
    {
        public int BaseProductId { get; set; }

        public List<Products> Products { get; set; }

        public int ProductQuantity { get; set; }

        public decimal OfferPrice { get; set; }
    }
}
