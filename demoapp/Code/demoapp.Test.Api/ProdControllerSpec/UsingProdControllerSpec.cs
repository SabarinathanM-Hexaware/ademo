using NSubstitute;
using demoapp.Test.Framework;
using demoapp.Api.Controllers;
using demoapp.Business.Interfaces;


namespace demoapp.Test.Api.ProdControllerSpec
{
    public abstract class UsingProdControllerSpec : SpecFor<ProdController>
    {
        protected IProdService _prodService;

        public override void Context()
        {
            _prodService = Substitute.For<IProdService>();
            subject = new ProdController(_prodService);

        }

    }
}
