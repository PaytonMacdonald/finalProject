using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using finalProject.Models;
using Dapper;

namespace finalProject.Services
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;
        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}