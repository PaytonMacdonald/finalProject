using System;
using System.Collections.Generic;
using finalProject.Models;
using finalProject.Repositories;

namespace finalProject.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;

        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
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




        // FIXME \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\
        internal List<VaultKeepViewModel> GetKeepsByProfileId(string id)
        {
            return _repo.GetKeepsByProfileId(id);
        }
        // FIXME \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\





        // FIXME \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\
        internal List<VaultKeepViewModel> GetKeepsByVaultId(int id)
        {
            return _repo.GetKeepsByVaultId(id);
        }
        // FIXME \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\





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

        // NOTE JAKE's WAY
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

        // NOTE MARK's WAY
        // internal Car Update(int id, Car update)
        // {
        //     Car original = GetById(update.Id);
        //     original.CreatorId = update.CreatorId.Length > 0 ? update.CreatorId : original.CreatorId;
        //     original.Name = update.Name.Length > 0 ? update.Name : original.Name;
        //     original.Description = update.Description.Length > 0 ? update.Description : original.Description;
        //     original.Img = update.Img.Length > 0 ? update.Img : original.Description;
        //     original.Views = update.Views > 0 ? update.Views : original.Views;
        //     original.Shares = update.Shares > 0 ? update.Shares : original.Shares;
        //     original.Keeps = update.Keeps > 0 ? update.Keeps : original.Keeps;
        //     // original.Creator = update.Creator.Length > 0 ? update.Creator : original.Creator;
        //     // original.published = update.published != null ? update.published : original.published; // NOTE BOOL
        //     if (_repo.Update(id, original))
        //     {
        //         return original;
        //     }
        //     throw new Exception("Something Went Wrong???");
        // }

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