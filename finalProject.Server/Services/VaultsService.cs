using System;
using System.Collections.Generic;
using finalProject.Models;
using finalProject.Repositories;

namespace finalProject.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;

        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }
        // ////////////////////////////////////////////////////////// //
        internal Vault Create(Vault k)
        {
            return _repo.Create(k);
        }
        // ////////////////////////////////////////////////////////// //
        internal List<Vault> GetAll()
        {
            return _repo.GetAll();
        }
        // ////////////////////////////////////////////////////////// //
        internal Vault GetById(int id)
        {
            Vault vault = _repo.GetById(id);
            if (vault == null)
            {
                throw new Exception("Invalid Vault Id");
            }
            return vault;
        }
        // ////////////////////////////////////////////////////////// //




        // FIXME \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\
        internal List<Vault> GetVaults(int id)
        {
            return _repo.GetVaults(id);
        }
        // FIXME \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\





        // ////////////////////////////////////////////////////////// //
        internal Vault Update(Vault v, string id)
        {
            Vault vault = _repo.GetById(v.Id);
            if (vault == null)
            {
                throw new Exception("Invalid Id");
            }
            if (vault.CreatorId != id)
            {
                throw new Exception("Cannot delete, you do not own this vault");
            }
            return _repo.Update(v);
        }
        // ////////////////////////////////////////////////////////// //
        internal void Delete(int id, string userId)
        {
            Vault vault = _repo.GetById(id);

            if (vault == null)
            {
                throw new Exception("Invalid Id");
            }
            if (vault.CreatorId != userId)
            {
                throw new Exception("Cannot delete, you do not own this keep");
            }
            _repo.Delete(id);
        }
        // ////////////////////////////////////////////////////////// //
    }
}