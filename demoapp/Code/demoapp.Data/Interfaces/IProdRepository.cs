using demoapp.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace demoapp.Data.Interfaces
{
    public interface IProdRepository : IGetAll<Prod>,IGet<Prod,string>, ISave<Prod>, IUpdate<Prod, string>, IDelete<string>
    {
    }
}
