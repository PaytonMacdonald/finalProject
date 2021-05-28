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
    }
}