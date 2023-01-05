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
    public class When_updating_products : UsingProductsControllerSpec
    {
        private ActionResult<Products > _result;
        private Products _products;

        public override void Context()
        {
            base.Context();

            _products = new Products
            {
                name = "name"
            };

            _productsService.Update(_products.Id, _products).Returns(_products);
            
        }
        public override void Because()
        {
            _result = subject.Update(_products.Id, _products);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _productsService.Received(1).Update(_products.Id, _products);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Products>();

            var resultList = resultListObject as Products;

            resultList.ShouldBe(_products);
        }
    }
}
