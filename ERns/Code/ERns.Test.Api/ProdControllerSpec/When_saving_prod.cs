using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using ERns.Entities.Entities;

namespace ERns.Test.Api.ProdControllerSpec
{
    public class When_saving_prod : UsingProdControllerSpec
    {
        private ActionResult<Prod> _result;

        private Prod _prod;

        public override void Context()
        {
            base.Context();

            _prod = new Prod
            {
                name = "name"
            };

            _prodService.Save(_prod).Returns(_prod);
        }
        public override void Because()
        {
            _result = subject.Save(_prod);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _prodService.Received(1).Save(_prod);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Prod>();

            var resultList = (Prod)resultListObject;

            resultList.ShouldBe(_prod);
        }
    }
}
