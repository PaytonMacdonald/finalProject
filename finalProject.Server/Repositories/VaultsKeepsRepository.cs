using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using finalProject.Models;
using Dapper;

namespace finalProject.Repositories
{
    public class VaultsKeepsRepository
    {
        private readonly IDbConnection _db;
        public VaultsKeepsRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}