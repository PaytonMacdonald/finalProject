using System;
using System.Collections.Generic;
using finalProject.Models;
using finalProject.Repositories;

namespace finalProject.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        private readonly VaultsRepository _vRepo;

        public KeepsService(KeepsRepository repo, VaultsRepository vRepo)
        {
            _repo = repo;
            _vRepo = vRepo;
        }
        // ////////////////////////////////////////////////////////// //
        internal Keep Create(Keep k)
        {
            return _repo.Create(k);
        }
        // ////////////////////////////////////////////////////////// //
        internal List<Keep> GetAll()
        {
            return _repo.GetAll();
        }
        // ////////////////////////////////////////////////////////// //
        internal List<Keep> GetKeepsByProfileId(string id)
        {
            return _repo.GetKeepsByProfileId(id);
        }
        // ////////////////////////////////////////////////////////// //
        internal List<VaultKeepViewModel> GetKeepsByVaultId(int id, Account userInfo)
        {
            Vault vault = _vRepo.GetById(id);
            if (vault.IsPrivate == false || vault.CreatorId == userInfo.Id)
            {
                if (vault == null)
                {
                    throw new Exception("Invalid Vault Id");
                }
                return _repo.GetKeepsByVaultId(id);
            }
            throw new Exception("You Don't Have Access to This Vault");
        }
        // ////////////////////////////////////////////////////////// //
        internal Keep GetById(int id)
        {
            Keep keep = _repo.GetById(id);
            if (keep == null)
            {
                throw new Exception("Invalid Keep Id");
            }
            return keep;
        }
        // ////////////////////////////////////////////////////////// //
        internal Keep Update(Keep k, string id)
        {
            Keep keep = _repo.GetById(k.Id);
            if (keep == null)
            {
                throw new Exception("Invalid Id");
            }
            if (keep.CreatorId != id)
            {
                throw new Exception("Cannot delete, you do not own this keep");
            }
            return _repo.Update(k);
        }
        // ////////////////////////////////////////////////////////// //
        internal void Delete(int id, string userId)
        {
            Keep keep = _repo.GetById(id);

            if (keep == null)
            {
                throw new Exception("Invalid Id");
            }
            if (keep.CreatorId != userId)
            {
                throw new Exception("Cannot delete, you do not own this keep");
            }
            _repo.Delete(id);
        }
        // ////////////////////////////////////////////////////////// //
    }
}