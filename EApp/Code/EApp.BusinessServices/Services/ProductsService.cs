using EApp.BusinessServices.Interfaces;
using EApp.Data.Interfaces;
using EApp.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EApp.BusinessServices.Services
{
    public class ProductsService : IProductsService
    {
        IProductsRepository _ProductsRepository;

        public ProductsService(IProductsRepository ProductsRepository)
        {
           this._ProductsRepository = ProductsRepository;
        }
        public IEnumerable<Products> GetAll()
        {
            return _ProductsRepository.GetAll();
        }

        public Products Get(string id)
        {
            return _ProductsRepository.Get(id);
        }

        public Products Save(Products Products)
        {
            _ProductsRepository.Save(Products);
            return Products;
        }

        public Products Update(string id, Products Products)
        {
            return _ProductsRepository.Update(id, Products);
        }

        public bool Delete(string id)
        {
            return _ProductsRepository.Delete(id);
        }

    }
}
