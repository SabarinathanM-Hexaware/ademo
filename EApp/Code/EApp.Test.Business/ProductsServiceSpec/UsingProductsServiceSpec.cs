using NSubstitute;
using EApp.Test.Framework;
using EApp.Business.Services;
using EApp.Data.Interfaces;

namespace EApp.Test.Business.ProductsServiceSpec
{
    public abstract class UsingProductsServiceSpec : SpecFor<ProductsService>
    {
        protected IProductsRepository _productsRepository;

        public override void Context()
        {
            _productsRepository = Substitute.For<IProductsRepository>();
            subject = new ProductsService(_productsRepository);

        }

    }
}
