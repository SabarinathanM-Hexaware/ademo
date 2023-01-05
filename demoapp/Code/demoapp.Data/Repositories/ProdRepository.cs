using demoapp.Data.Interfaces;
using demoapp.BusinessEntities.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace demoapp.Data.Repositories
{
    public class ProdRepository : IProdRepository
    {
        private IGateway _gateway;
        private string _collectionName = "Prod";

        public ProdRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Prod> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Prod>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public Prod Get(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Prod>(_collectionName)
                            .Find(x => x.Id == id).Single();
            return result;
        }

        public bool Save(Prod entity)
        {
            _gateway.GetMongoDB().GetCollection<Prod>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Prod Update(string id, Prod entity)
        {
            var update = Builders<Prod>.Update
                .Set(e => e.name, entity.name );

            var result = _gateway.GetMongoDB().GetCollection<Prod>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Prod>(_collectionName)
                         .FindOneAndDelete(e => e.Id == id);
            if(result==null) return false;             
            return true;
        }
    }
}
