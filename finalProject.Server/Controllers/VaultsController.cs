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
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _service;
        private readonly AccountService _acctService;
        public VaultsController(VaultsService service, AccountService acctService)
        {
            _service = service;
            _acctService = acctService;
        }
    }
}