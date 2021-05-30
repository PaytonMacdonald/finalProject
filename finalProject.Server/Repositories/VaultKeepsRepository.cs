using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using finalProject.Models;
using Dapper;

namespace finalProject.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;
        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }
        // ////////////////////////////////////////////////////////// //
        internal VaultKeep GetById(int id)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE id = @id";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
        }
        // ////////////////////////////////////////////////////////// //
        public VaultKeep Create(VaultKeep gm)
        {
            string sql = @"
            INSERT INTO 
                vaultkeeps(creatorId, vaultId, keepId)
            VALUES(@CreatorId, @VaultId, @KeepId);
            SELECT LAST_INSERT_ID();
            ";
            gm.Id = _db.ExecuteScalar<int>(sql, gm);
            return gm;
        }
        // ////////////////////////////////////////////////////////// //
        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
        // ////////////////////////////////////////////////////////// //

    }
}