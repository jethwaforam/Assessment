using System.Collections.Generic;
using PromotionEngineApi.Controllers;
using PromotionEngineApi.Model;
using Xunit;

namespace PromotionEngineTest
{
    public class PromotionEngineControllerTest
    {
        [Fact]
        public void NoPromotionOfferApply()
        {
            var _controller = new PromotionEngineController();
            var selectedProducts = NoPromotionOfferData();
            var result = _controller.ApplyPromotionOffer(selectedProducts);
            Assert.Equal(100, result);
        }
        private List<Products> NoPromotionOfferData()
        {
            var list = new List<Products>
            {
                new Products {ProductId=1, ProductName="A", Quantity=1},
                new Products {ProductId=2, ProductName="B", Quantity=1},
                new Products {ProductId=3, ProductName="C", Quantity=1},
            };
            return list;
        }
    }
}
