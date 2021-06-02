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
        // ////////////////////////////////////////////////////////// //
        internal Vault Create(Vault v)
        {
            string sql = @"
                INSERT INTO 
                vaults (creatorId, name, description, isPrivate)
                VALUES (@CreatorId, @Name, @Description, @IsPrivate);
                SELECT LAST_INSERT_ID();
            ";
            v.Id = _db.ExecuteScalar<int>(sql, v);
            return v;
        }
        // ////////////////////////////////////////////////////////// //
        internal List<Vault> GetAll()
        {
            string sql = @"
            SELECT 
            v.*,
            a.* 
            FROM vaults v
            JOIN accounts a ON v.creatorId = a.id;";
            return _db.Query<Vault, Profile, Vault>(sql,
            (v, a) =>
            {
                v.Creator = a;
                return v;
            }, splitOn: "id").ToList();
        }
        // ////////////////////////////////////////////////////////// //
        internal Vault GetById(int id)
        {
            string sql = "SELECT * FROM vaults  WHERE id = @id";
            return _db.QueryFirstOrDefault<Vault>(sql, new { id });
        }
        // ////////////////////////////////////////////////////////// //
        internal IEnumerable<Vault> GetVaultsByProfileId(string id)
        {
            string sql = @"
            SELECT 
            v.*,
            a.* 
            FROM vaults v
            JOIN accounts a ON v.creatorId = a.id
            WHERE v.creatorId = @id;";
            return _db.Query<Vault, Profile, Vault>(sql,
            (v, a) =>
            {
                v.Creator = a;
                return v;
            }, new { id }, splitOn: "id").ToList();
        }
        // ////////////////////////////////////////////////////////// //
        internal Vault Update(Vault v)
        {
            string sql = @"
            UPDATE vaults 
            SET 
                name = @Name,
                description = @Description,
                isPrivate = @IsPrivate
            WHERE id = @Id;
            ";
            _db.Execute(sql, v);
            return v;
        }
        // ////////////////////////////////////////////////////////// //
        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
        // ////////////////////////////////////////////////////////// //
    }
}