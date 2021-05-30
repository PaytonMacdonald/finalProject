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
            string sql = "SELECT * FROM keeps WHERE id = @id";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
        }
        // ////////////////////////////////////////////////////////// //





        // FIXME \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\
        // I have no idea what I'm doing on this one??????????
        internal List<Keep> GetKeeps(int id)
        {
            string sql = @"
            SELECT 
            k.*,
            a.* 
            FROM keeps k
            JOIN accounts a ON k.creatorId = a.id;";

            // what do I even do on this part???
            return _db.Query<Keep, Profile, Keep>(sql,
            (k, a) =>
            {
                k.Creator = a;
                return k;
            }, splitOn: "id").ToList();
        }
        // FIXME \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\





        // ////////////////////////////////////////////////////////// //
        internal Keep Update(Keep k)
        {
            string sql = @"
            UPDATE keeps 
            SET 
                name = @Name,
                description = @Description
                img = @Img
                views = @Views
                shares = @Shares
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