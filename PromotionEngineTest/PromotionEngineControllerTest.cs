using System;
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
        [Fact]
        public void SingleProductPromotionApply()
        {
            var _controller = new PromotionEngineController();
            var selectedProducts = SingleProductPromotionData();
            var result = _controller.ApplyPromotionOffer(selectedProducts);
            Assert.Equal(370, result);
        }

        private List<Products> SingleProductPromotionData()
        {
            var list = new List<Products>
            {
                new Products {ProductId=1, ProductName="A", Quantity=5},
                new Products {ProductId=2, ProductName="B", Quantity=5},
                new Products {ProductId=3, ProductName="C", Quantity=1},
            };
            return list;
        }

        [Fact]
        public void ComboProductPromotionApply()
        {
            var _controller = new PromotionEngineController();
            var selectedProducts = ComboProductPromotionData();
            var result = _controller.ApplyPromotionOffer(selectedProducts);
            Assert.Equal(280, result);
        }

        private List<Products> ComboProductPromotionData()
        {
            var list = new List<Products>
            {
                new Products {ProductId=1, ProductName="A", Quantity=3},
                new Products {ProductId=2, ProductName="B", Quantity=5},
                new Products {ProductId=3, ProductName="C", Quantity=1},
                new Products {ProductId=4, ProductName="D", Quantity=1},
            };
            return list;
        }

        [Fact]
        public void MultiComboProductPromotionApply()
        {
            var _controller = new PromotionEngineController();
            var selectedProducts = MultiComboProductPromotionData();
            var result = _controller.ApplyPromotionOffer(selectedProducts);
            Assert.Equal(310, result);
        }

        private List<Products> MultiComboProductPromotionData()
        {
            var list = new List<Products>
            {
                new Products {ProductId=1, ProductName="A", Quantity=3},
                new Products {ProductId=2, ProductName="B", Quantity=5},
                new Products {ProductId=3, ProductName="C", Quantity=2},
                new Products {ProductId=4, ProductName="D", Quantity=2},
            };
            return list;
        }
    }
}
