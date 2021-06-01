using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using finalProject.Models;
using Dapper;

namespace finalProject.Repositories
{
    public class ProfilesRepository
    {
        private readonly IDbConnection _db;
        public ProfilesRepository(IDbConnection db)
        {
            _db = db;
        }
        // ////////////////////////////////////////////////////////// //
        internal Profile GetById(string id)
        {
            string sql = "SELECT * FROM accounts WHERE id = @id";
            return _db.QueryFirstOrDefault<Profile>(sql, new { id });
        }
        // ////////////////////////////////////////////////////////// //
    }
}