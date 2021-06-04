using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using finalProject.Models;

namespace finalProject.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;
        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }
        // ////////////////////////////////////////////////////////// //
        internal Keep Create(Keep k)
        {
            string sql = @"
                INSERT INTO 
                keeps(creatorId, name, description, img, views, shares, keeps)
                VALUES (@CreatorId, @Name, @Description, @Img, @Views, @Shares, @Keeps);
                SELECT LAST_INSERT_ID();
            ";
            k.Id = _db.ExecuteScalar<int>(sql, k);
            return k;
        }
        // ////////////////////////////////////////////////////////// //
        internal List<Keep> GetAll()
        {
            string sql = @"
            SELECT 
            k.*,
            a.* 
            FROM keeps k
            JOIN accounts a ON k.creatorId = a.id;";
            return _db.Query<Keep, Profile, Keep>(sql,
            (k, a) =>
            {
                k.Creator = a;
                return k;
            }, splitOn: "id").ToList();
        }
        // ////////////////////////////////////////////////////////// //
        internal Keep GetById(int id)
        {
            string sql = @"
            SELECT 
            k.*,
            a.* 
            FROM keeps k 
            JOIN accounts a ON k.creatorId = a.id
            WHERE k.id = @id;";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile; return keep;
            }, new { id }, splitOn: "id").FirstOrDefault();
        }
        // ////////////////////////////////////////////////////////// //
        internal List<Keep> GetKeepsByProfileId(string id)
        {
            string sql = @"
            SELECT 
            k.*,
            a.* 
            FROM keeps k
            JOIN accounts a ON k.creatorId = a.id
            WHERE k.creatorId = @id;";
            return _db.Query<Keep, Profile, Keep>(sql,
            (vk, a) =>
            {
                vk.Creator = a;
                return vk;
            }, new { id }, splitOn: "id").ToList();
        }
        // ////////////////////////////////////////////////////////// //
        internal List<VaultKeepViewModel> GetKeepsByVaultId(int id)
        {
            string sql = @"
            SELECT 
            k.*,
            vk.id AS vaultKeepId,
            a.* 
            FROM vaultkeeps vk
            JOIN keeps k ON vk.keepId = k.id
            JOIN accounts a ON k.creatorId = a.id
            WHERE vk.vaultId = @id;";
            return _db.Query<VaultKeepViewModel, Profile, VaultKeepViewModel>(sql,
            (vk, a) =>
            {
                vk.Creator = a;
                return vk;
            }, new { id }, splitOn: "id").ToList();
        }
        // ////////////////////////////////////////////////////////// //
        internal Keep Update(Keep k)
        {
            string sql = @"
            UPDATE keeps 
            SET 
                name = @Name,
                description = @Description,
                img = @Img,
                views = @Views,
                shares = @Shares,
                keeps = @Keeps
            WHERE id = @Id;
            ";
            _db.Execute(sql, k);
            return k;
        }
        // ////////////////////////////////////////////////////////// //
        internal Keep UpdateCount(Keep k)
        {
            string sql = @"
            UPDATE keeps 
            SET 
                name = @Name,
                description = @Description,
                img = @Img,
                views = @Views,
                shares = @Shares,
                keeps = @Keeps
            WHERE id = @Id;
            ";
            _db.Execute(sql, k);
            return k;
        }
        // ////////////////////////////////////////////////////////// //
        internal void Delete(int id)
        {
            string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
        // ////////////////////////////////////////////////////////// //
    }
}