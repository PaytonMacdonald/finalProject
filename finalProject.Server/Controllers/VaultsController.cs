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
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _service;
        private readonly KeepsService _kService;
        public VaultsController(VaultsService service, KeepsService kService)
        {
            _service = service;
            _kService = kService;
        }
        // ////////////////////////////////////////////////////////// //
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Vault>> Create([FromBody] Vault v)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                v.CreatorId = userInfo.Id;
                Vault newVault = _service.Create(v);
                newVault.Creator = userInfo;
                return Ok(newVault);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // ////////////////////////////////////////////////////////// //
        [HttpGet]
        public ActionResult<List<Vault>> GetAll()
        {
            try
            {
                List<Vault> vaults = _service.GetAll();
                return Ok(vaults);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // ////////////////////////////////////////////////////////// //
        [HttpGet("{id}")]
        public ActionResult<Vault> GetById(int id)
        {
            try
            {
                Vault found = _service.GetById(id);
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
        public ActionResult<List<Keep>> GetKeeps(string id)
        {
            try
            {
                List<Keep> keeps = _kService.GetKeeps(id);
                return Ok(keeps);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // FIXME \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\





        // ////////////////////////////////////////////////////////// //
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Vault>> Update(int id, [FromBody] Vault v)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                v.Id = id;
                Vault newVault = _service.Update(v, userInfo.Id);
                newVault.Creator = userInfo;
                return Ok(newVault);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // ////////////////////////////////////////////////////////// //
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _service.Delete(id, userInfo.Id);
                return Ok("Successfully Deleted!");

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // ////////////////////////////////////////////////////////// //
    }
}