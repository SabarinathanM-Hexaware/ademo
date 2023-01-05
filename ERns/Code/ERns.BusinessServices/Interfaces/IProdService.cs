using ERns.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERns.BusinessServices.Interfaces
{
    public interface IProdService
    {      
        IEnumerable<Prod> GetAll();
        Prod Get(string id);
        Prod Save(Prod classification);
        Prod Update(string id, Prod classification);
        bool Delete(string id);

    }
}
