﻿using DuckTracker.Repositories.ADO;
using DuckTracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuckTracker.Repositories
{
    public static class RepositoryFactory
    {
        public static IMamaRepository CreateMamaRepo()
        {
            return new MamaRepositoryADO();
        }
    }
}