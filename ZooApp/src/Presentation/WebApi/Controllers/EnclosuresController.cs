using System;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using ZooApp.Domain.Entities;
using ZooApp.Domain.Repositories;

namespace ZooApp.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnclosuresController : ControllerBase
    {
        private readonly IEnclosureRepository _repo;

        public EnclosuresController(IEnclosureRepository repo) => _repo = repo;

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(Guid id) => Ok(_repo.GetById(id));

        [HttpPost]
        public IActionResult Create([FromBody] Enclosure enclosure)
        {
            _repo.Add(enclosure);
            return CreatedAtAction(nameof(Get), new { id = enclosure.Id }, enclosure);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _repo.Remove(id);
            return NoContent();
        }
    }
}
