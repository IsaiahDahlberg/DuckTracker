using DuckTracker.Models.Query;
using DuckTracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuckTracker.Repositories.ADO
{
    public class NoteRepositoryADO : INoteRepository
    {
        public IEnumerable<NoteQuery> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}