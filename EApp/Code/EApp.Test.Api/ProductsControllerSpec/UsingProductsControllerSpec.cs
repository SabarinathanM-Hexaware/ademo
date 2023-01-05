using NSubstitute;
using EApp.Test.Framework;
using EApp.Api.Controllers;
using EApp.Business.Interfaces;


namespace EApp.Test.Api.ProductsControllerSpec
{
    public abstract class UsingProductsControllerSpec : SpecFor<ProductsController>
    {
        protected IProductsService _productsService;

        public override void Context()
        {
            _productsService = Substitute.For<IProductsService>();
            subject = new ProductsController(_productsService);

        }

    }
}
