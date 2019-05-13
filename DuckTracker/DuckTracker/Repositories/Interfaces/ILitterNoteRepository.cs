using DuckTracker.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckTracker.Repositories.Interfaces
{
    public interface ILitterNoteRepository
    {
        int Create(LitterNote note);
        IEnumerable<LitterNote> GetRecent();
        LitterNote GetById(int id);
        IEnumerable<LitterNote> GetByLitterId(int litterId);
        int Update(LitterNote note);
        void Delete(int id);
    }
}
