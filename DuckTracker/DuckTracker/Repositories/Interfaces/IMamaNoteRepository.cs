using DuckTracker.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckTracker.Repositories.Interfaces
{
    public interface IMamaNoteRepository
    {
        int Create(MamaDogNote note);
        IEnumerable<MamaDogNote> GetRecent();
        MamaDogNote GetById(int id);
        IEnumerable<MamaDogNote> GetByMamaDogId(int mamaId);
        int Update(MamaDogNote note);
        void Delete(int id);
    }
}
