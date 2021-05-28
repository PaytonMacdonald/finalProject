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
    public class KeepsController
    {
        private readonly KeepsService _service;
        private readonly AccountService _acctService;
        public KeepsController(KeepsService service, AccountService acctService)
        {
            _service = service;
            _acctService = acctService;
        }
    }
}