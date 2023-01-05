using EApp.Data.Interfaces;
using EApp.BusinessEntities.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace EApp.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private IGateway _gateway;
        private string _collectionName = "Products";

        public ProductsRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Products> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Products>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public Products Get(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Products>(_collectionName)
                            .Find(x => x.Id == id).Single();
            return result;
        }

        public bool Save(Products entity)
        {
            _gateway.GetMongoDB().GetCollection<Products>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Products Update(string id, Products entity)
        {
            var update = Builders<Products>.Update
                .Set(e => e.name, entity.name );

            var result = _gateway.GetMongoDB().GetCollection<Products>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Products>(_collectionName)
                         .FindOneAndDelete(e => e.Id == id);
            if(result==null) return false;             
            return true;
        }
    }
}
