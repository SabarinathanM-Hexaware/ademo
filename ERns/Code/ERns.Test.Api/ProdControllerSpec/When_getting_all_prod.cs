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
    public class When_getting_all_prod : UsingProdControllerSpec
    {
        private ActionResult<IEnumerable<Prod>> _result;

        private IEnumerable<Prod> _all_prod;
        private Prod _prod;

        public override void Context()
        {
            base.Context();

            _prod = new Prod{
                name = "name"
            };

            _all_prod = new List<Prod> { _prod};
            _prodService.GetAll().Returns(_all_prod);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _prodService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Prod>>();

            List<Prod> resultList = resultListObject as List<Prod>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_prod);
        }
    }
}
