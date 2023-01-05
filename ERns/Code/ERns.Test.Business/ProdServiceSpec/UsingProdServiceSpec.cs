using NSubstitute;
using ERns.Test.Framework;
using ERns.Business.Services;
using ERns.Data.Interfaces;

namespace ERns.Test.Business.ProdServiceSpec
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
