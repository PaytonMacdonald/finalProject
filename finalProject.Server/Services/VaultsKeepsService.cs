using System;
using System.Collections.Generic;
using finalProject.Models;
using finalProject.Repositories;

namespace finalProject.Services
{
    public class VaultsKeepsService
    {
        private readonly VaultsKeepsRepository _repo;

        public VaultsKeepsService(VaultsKeepsRepository repo)
        {
            _repo = repo;
        }
    }
}