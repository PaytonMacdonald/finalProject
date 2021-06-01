using System;
using System.Collections.Generic;
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
        internal Vault GetById(int id, string creatorId)
        {
            Vault vault = _repo.GetById(id);
            // Account userInfo.Id == accountId
            // if (vault.IsPrivate == true && creatorId != accountId)
            // {
            //     throw new Exception("This Vault is Private");
            // }
            // else
            // {
            // }
            if (vault == null)
            {
                throw new Exception("Invalid Vault Id");
            }

            return vault;
        }
        // ////////////////////////////////////////////////////////// //




        // FIXME \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\
        internal List<Vault> GetVaultsByProfileId(string id)
        {
            return _repo.GetVaultsByProfileId(id);
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