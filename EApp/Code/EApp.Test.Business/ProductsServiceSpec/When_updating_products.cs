using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using EApp.Entities.Entities;


namespace EApp.Test.Business.ProductsServiceSpec
{
    public class When_updating_products : UsingProductsServiceSpec
    {
        private Products _result;
        private Products _products;

        public override void Context()
        {
            base.Context();

            _products = new Products
            {
                name = "name"
            };

            _productsRepository.Update(_products.Id, _products).Returns(_products);
            
        }
        public override void Because()
        {
            _result = subject.Update(_products.Id, _products);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _productsRepository.Received(1).Update(_products.Id, _products);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Products>();

            _result.ShouldBe(_products);
        }
    }
}
