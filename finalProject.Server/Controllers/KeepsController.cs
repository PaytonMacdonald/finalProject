using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using finalProject.Models;
using finalProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace finalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _service;
        public KeepsController(KeepsService service)
        {
            _service = service;
        }
        // ////////////////////////////////////////////////////////// //
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Keep>> Create([FromBody] Keep k)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                k.CreatorId = userInfo.Id;
                Keep newKeep = _service.Create(k);
                newKeep.Creator = userInfo;
                return Ok(newKeep);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // ////////////////////////////////////////////////////////// //
        [HttpGet]
        public ActionResult<List<Keep>> GetAll()
        {
            try
            {
                List<Keep> keeps = _service.GetAll();
                return Ok(keeps);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // ////////////////////////////////////////////////////////// //
        [HttpGet("{id}")]
        public ActionResult<Keep> GetById(int id)
        {
            try
            {
                Keep found = _service.GetById(id);
                return Ok(found);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // ////////////////////////////////////////////////////////// //
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Keep>> Update(int id, [FromBody] Keep k)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                k.Id = id;
                Keep newKeep = _service.Update(k, userInfo.Id);
                newKeep.Creator = userInfo;
                return Ok(newKeep);
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