using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CA.Business.DTOs;
using CA.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CA.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CarAdvertController : Controller
    {
        private readonly ICarAdvertService _service;

        public CarAdvertController(ICarAdvertService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Json(await _service.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Json(await _service.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CarAdvertDto value)
        {
            try
            {
                return Json(await _service.Add(value));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]CarAdvertDto value)
        {
            try
            {
                value.Id = id;
                await _service.Update(value);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}