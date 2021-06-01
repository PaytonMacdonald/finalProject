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





        // FIXME \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\
        [HttpGet("{id}/keeps")]
        public ActionResult<List<VaultKeepViewModel>> GetKeepsByProfileId(string id)
        {
            try
            {
                List<VaultKeepViewModel> keeps = _kService.GetKeepsByProfileId(id);
                return Ok(keeps);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // FIXME \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\





        // ////////////////////////////////////////////////////////// //





        // FIXME \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\
        [HttpGet("{id}/vaults")]
        public ActionResult<List<Vault>> GetVaultsByProfileId(string id)
        {
            try
            {
                List<Vault> vaults = _vService.GetVaultsByProfileId(id);
                return Ok(vaults);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // FIXME \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\





        // ////////////////////////////////////////////////////////// //
    }
}