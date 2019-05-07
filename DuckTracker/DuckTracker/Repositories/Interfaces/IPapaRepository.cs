using DuckTracker.Models.Query;
using DuckTracker.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckTracker.Repositories.Interfaces
{
    public interface IPapaRepository
    {
        int Create(PapaDog mama);
        PapaDogQuery GetById(int id);
        IEnumerable<PapaDogQuery> GetAll();
        int Update(PapaDog mama);
        void Delete(int id);
    }
}
