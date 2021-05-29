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
    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _service;
        public KeepsController(KeepsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Keep>> GetAll()
        {
            try
            {
                IEnumerable<Keep> keeps = _service.GetAll();
                return Ok(keeps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Keep> GetById(int id)
        {
            try
            {
                Keep found = _service.GetById(id);
                return Ok(found);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newKeep.CreatorId = userInfo.Id;
                Keep keep = _service.Create(newKeep);
                keep.Creator = userInfo;
                return Ok(keep);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}