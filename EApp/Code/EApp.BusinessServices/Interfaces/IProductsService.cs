using EApp.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EApp.BusinessServices.Interfaces
{
    public interface IProductsService
    {      
        IEnumerable<Products> GetAll();
        Products Get(string id);
        Products Save(Products classification);
        Products Update(string id, Products classification);
        bool Delete(string id);

    }
}
