using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using demoapp.Entities.Entities;

namespace demoapp.Test.Business.ProdServiceSpec
{
    public class When_getting_all_prod : UsingProdServiceSpec
    {
        private IEnumerable<Prod> _result;

        private IEnumerable<Prod> _all_prod;
        private Prod _prod;

        public override void Context()
        {
            base.Context();

            _prod = new Prod{
                name = "name"
            };

            _all_prod = new List<Prod> { _prod};
            _prodRepository.GetAll().Returns(_all_prod);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _prodRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Prod>>();

            List<Prod> resultList = _result as List<Prod>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_prod);
        }
    }
}
