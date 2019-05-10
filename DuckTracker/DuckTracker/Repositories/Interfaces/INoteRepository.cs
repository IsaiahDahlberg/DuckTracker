using DuckTracker.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckTracker.Repositories.Interfaces
{
    public interface INoteRepository
    {
        IEnumerable<NoteQuery> GetAll();
    }
}
