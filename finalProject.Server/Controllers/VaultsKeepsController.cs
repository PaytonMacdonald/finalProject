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
    public class VaultsKeepsController
    {
        private readonly VaultsKeepsService _service;
        private readonly AccountService _acctService;
        public VaultsKeepsController(VaultsKeepsService service, AccountService acctService)
        {
            _service = service;
            _acctService = acctService;
        }
    }
}