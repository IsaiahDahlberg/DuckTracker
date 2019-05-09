using DuckTracker.Models.CreateModels;
using DuckTracker.Models.Query;
using DuckTracker.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckTracker.Repositories.Interfaces
{
    public interface IMamaRepository
    {
        int Create(CreateMamaDogModel mama);
        MamaDogQuery GetById(int id);
        IEnumerable<MamaDogQuery> GetAll();
        int Update(MamaDog mama);
        void Delete(int id);
    }
}
