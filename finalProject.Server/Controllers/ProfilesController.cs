using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using finalProject.Models;
using finalProject.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace finalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController
    {
        private readonly ProfilesService _service;
        private readonly AccountService _acctService;
        public ProfilesController(ProfilesService service, AccountService acctService)
        {
            _service = service;
            _acctService = acctService;
        }
    }
}