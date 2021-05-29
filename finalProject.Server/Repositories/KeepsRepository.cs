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
        public IEnumerable<Keep> GetAll()
        {
            string sql = @"
            SELECT
            k.*,
            a.*
            FROM keeps k
            JOIN accounts a ON k.creatorId = a.id;";
            return _db.Query<Keep, Account, Keep>(sql, (keep, account) =>
            {
                keep.Creator = account;
                return keep;
            }, splitOn: "id");
        }
        public Keep GetById(int id)
        {
            string sql = @"
              SELECT 
                c.*,
                a.* 
              FROM keeps c
              JOIN accounts a ON c.creatorId = a.id
              WHERE id = @id;";
            return _db.Query<Keep, Account, Keep>(sql, (keep, account) =>
            {
                keep.Creator = account;
                return keep;
            }
            , new { id }, splitOn: "id").FirstOrDefault();
        }
        public Keep Create(Keep newKeep)
        {
            string sql = @"
            INSERT INTO keeps
            (creatorId, name, description, img, views, shares, keeps)
            VALUES
            (@CreatorId, @Name, @Description, @Img, @Views, @Shares, @Keeps);
            SELECT LAST_INSERT_ID()";
            newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
            return newKeep;
        }
    }
}