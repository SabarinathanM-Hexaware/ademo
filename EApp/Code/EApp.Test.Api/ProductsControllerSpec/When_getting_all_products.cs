using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using EApp.Entities.Entities;

namespace EApp.Test.Api.ProductsControllerSpec
{
    public class When_getting_all_products : UsingProductsControllerSpec
    {
        private ActionResult<IEnumerable<Products>> _result;

        private IEnumerable<Products> _all_products;
        private Products _products;

        public override void Context()
        {
            base.Context();

            _products = new Products{
                name = "name"
            };

            _all_products = new List<Products> { _products};
            _productsService.GetAll().Returns(_all_products);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _productsService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Products>>();

            List<Products> resultList = resultListObject as List<Products>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_products);
        }
    }
}
