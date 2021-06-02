using System;
using System.Collections.Generic;
using System.Linq;
using finalProject.Models;
using finalProject.Repositories;

namespace finalProject.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        private readonly AccountsRepository _acctRepo;

        public VaultsService(VaultsRepository repo, AccountsRepository acctRepo)
        {
            _repo = repo;
            _acctRepo = acctRepo;
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
        internal Vault GetById(int id, Account userInfo)
        {
            Vault vault = _repo.GetById(id);
            if (vault.IsPrivate == false || vault.CreatorId == userInfo.Id)
            {
                if (vault == null)
                {
                    throw new Exception("Invalid Vault Id");
                }
                return vault;
            }
            throw new Exception("You Don't Have Access to This Vault");
        }
        // ////////////////////////////////////////////////////////// //
        internal IEnumerable<Vault> GetVaultsByProfileId(string id, Account userInfo)
        {
            IEnumerable<Vault> vaults = _repo.GetVaultsByProfileId(id);
            return vaults.ToList().FindAll(v => v.IsPrivate == false);
        }
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