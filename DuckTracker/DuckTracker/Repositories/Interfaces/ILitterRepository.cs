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
    public interface ILitterRepository
    {
        int Create(CreateLitterModel litter);
        IEnumerable<LitterQuery> GetAll();
        LitterQuery GetById(int id);
        IEnumerable<LitterQuery> GetByMamaId(int mamaId);
        IEnumerable<LitterQuery> GetByPapaId(int papaId);
        int Update(Litter litter);
        void Delete(int id);
    }
}
