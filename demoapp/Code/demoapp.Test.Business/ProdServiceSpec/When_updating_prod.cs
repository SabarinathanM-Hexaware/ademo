using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using demoapp.Entities.Entities;


namespace demoapp.Test.Business.ProdServiceSpec
{
    public class When_updating_prod : UsingProdServiceSpec
    {
        private Prod _result;
        private Prod _prod;

        public override void Context()
        {
            base.Context();

            _prod = new Prod
            {
                name = "name"
            };

            _prodRepository.Update(_prod.Id, _prod).Returns(_prod);
            
        }
        public override void Because()
        {
            _result = subject.Update(_prod.Id, _prod);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _prodRepository.Received(1).Update(_prod.Id, _prod);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Prod>();

            _result.ShouldBe(_prod);
        }
    }
}
