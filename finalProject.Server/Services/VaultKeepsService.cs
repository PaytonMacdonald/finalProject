using System;
using System.Collections.Generic;
using finalProject.Models;
using finalProject.Repositories;

namespace finalProject.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }
        // ////////////////////////////////////////////////////////// //
        internal VaultKeep Create(VaultKeep vk)
        {
            return _repo.Create(vk);
        }
        // ////////////////////////////////////////////////////////// //
        public void Delete(int groupId, string userId)
        {
            VaultKeep vaultKeep = _repo.GetById(groupId);

            if (vaultKeep == null)
            {
                throw new Exception("Invalid Id");
            }
            if (vaultKeep.CreatorId != userId)
            {
                throw new Exception("Cannot delete, you do not own this");
            }
            _repo.Delete(groupId);
        }
        // ////////////////////////////////////////////////////////// //

    }
}