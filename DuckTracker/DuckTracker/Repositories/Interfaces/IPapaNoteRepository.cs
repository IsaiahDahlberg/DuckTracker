using DuckTracker.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckTracker.Repositories.Interfaces
{
    public interface IPapaNoteRepository
    {
        int Create(PapaDogNote note);
        IEnumerable<PapaDogNote> GetRecent();
        PapaDogNote GetById(int id);
        IEnumerable<PapaDogNote> GetByPapaDogId(int mamaId);
        int Update(PapaDogNote note);
        void Delete(int id);
    }
}
