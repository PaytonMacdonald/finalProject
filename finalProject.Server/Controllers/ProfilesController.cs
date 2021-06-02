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
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _service;
        private readonly AccountService _acctService;
        private readonly KeepsService _kService;
        private readonly VaultsService _vService;
        public ProfilesController(ProfilesService service, AccountService acctService, KeepsService kService, VaultsService vService)
        {
            _service = service;
            _acctService = acctService;
            _kService = kService;
            _vService = vService;
        }
        // ////////////////////////////////////////////////////////// //
        [HttpGet("{id}")]
        public ActionResult<Profile> GetById(string id)
        {
            try
            {
                Profile found = _service.GetById(id);
                return Ok(found);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // ////////////////////////////////////////////////////////// //
        [HttpGet("{id}/keeps")]
        public ActionResult<List<Keep>> GetKeepsByProfileId(string id)
        {
            try
            {
                List<Keep> keeps = _kService.GetKeepsByProfileId(id);
                return Ok(keeps);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // ////////////////////////////////////////////////////////// //
        [HttpGet("{id}/vaults")]
        public async Task<ActionResult<IEnumerable<Vault>>> GetVaultsByProfileId(string id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                IEnumerable<Vault> vaults = _vService.GetVaultsByProfileId(id, userInfo);
                return Ok(vaults);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // ////////////////////////////////////////////////////////// //
    }
}