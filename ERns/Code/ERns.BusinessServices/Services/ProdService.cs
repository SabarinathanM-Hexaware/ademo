using ERns.BusinessServices.Interfaces;
using ERns.Data.Interfaces;
using ERns.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERns.BusinessServices.Services
{
    public class ProdService : IProdService
    {
        IProdRepository _ProdRepository;

        public ProdService(IProdRepository ProdRepository)
        {
           this._ProdRepository = ProdRepository;
        }
        public IEnumerable<Prod> GetAll()
        {
            return _ProdRepository.GetAll();
        }

        public Prod Get(string id)
        {
            return _ProdRepository.Get(id);
        }

        public Prod Save(Prod Prod)
        {
            _ProdRepository.Save(Prod);
            return Prod;
        }

        public Prod Update(string id, Prod Prod)
        {
            return _ProdRepository.Update(id, Prod);
        }

        public bool Delete(string id)
        {
            return _ProdRepository.Delete(id);
        }

    }
}
