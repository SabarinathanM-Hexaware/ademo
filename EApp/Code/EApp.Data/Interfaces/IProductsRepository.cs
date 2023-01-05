using EApp.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EApp.Data.Interfaces
{
    public interface IProductsRepository : IGetAll<Products>,IGet<Products,string>, ISave<Products>, IUpdate<Products, string>, IDelete<string>
    {
    }
}
