using System;
using System.Collections.Generic;
using finalProject.Models;
using finalProject.Repositories;

namespace finalProject.Services
{
    public class ProfilesService
    {
        private readonly ProfilesRepository _repo;

        public ProfilesService(ProfilesRepository repo)
        {
            _repo = repo;
        }
    }
}