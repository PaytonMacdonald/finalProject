using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using finalProject.Models;
using Dapper;

namespace finalProject.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}