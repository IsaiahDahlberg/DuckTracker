using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuckTracker.Repositories.ADO
{
    public static class Settings
    {
        private static string _connection = @"Server = localhost; Database=DogTracker; Integrated Security = True;";
        public static string GetConnectionString()
        {
            return _connection;
        }
    }
}