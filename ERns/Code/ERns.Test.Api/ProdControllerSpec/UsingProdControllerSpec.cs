using NSubstitute;
using ERns.Test.Framework;
using ERns.Api.Controllers;
using ERns.Business.Interfaces;


namespace ERns.Test.Api.ProdControllerSpec
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
