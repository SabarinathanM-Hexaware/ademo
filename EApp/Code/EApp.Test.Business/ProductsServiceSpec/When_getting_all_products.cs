using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using EApp.Entities.Entities;

namespace EApp.Test.Business.ProductsServiceSpec
{
    public class When_getting_all_products : UsingProductsServiceSpec
    {
        private IEnumerable<Products> _result;

        private IEnumerable<Products> _all_products;
        private Products _products;

        public override void Context()
        {
            base.Context();

            _products = new Products{
                name = "name"
            };

            _all_products = new List<Products> { _products};
            _productsRepository.GetAll().Returns(_all_products);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _productsRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Products>>();

            List<Products> resultList = _result as List<Products>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_products);
        }
    }
}
