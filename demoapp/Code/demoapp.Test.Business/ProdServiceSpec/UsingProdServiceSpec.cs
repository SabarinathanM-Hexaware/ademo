using NSubstitute;
using demoapp.Test.Framework;
using demoapp.Business.Services;
using demoapp.Data.Interfaces;

namespace demoapp.Test.Business.ProdServiceSpec
{
    public abstract class UsingProdServiceSpec : SpecFor<ProdService>
    {
        protected IProdRepository _prodRepository;

        public override void Context()
        {
            _prodRepository = Substitute.For<IProdRepository>();
            subject = new ProdService(_prodRepository);

        }

    }
}
