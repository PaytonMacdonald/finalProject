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
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _service;
        public VaultKeepsController(VaultKeepsService service)
        {
            _service = service;
        }
        // ////////////////////////////////////////////////////////// //





        // ////////////////////////////////////////////////////////// //
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep vk)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                vk.CreatorId = userInfo.Id;
                VaultKeep newVaultKeep = _service.Create(vk);
                // newVaultKeep.Creator = userInfo; NOTE what do I even do here???
                return Ok(newVaultKeep);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // ////////////////////////////////////////////////////////// //
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<VaultKeep>> Delete(int id)
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