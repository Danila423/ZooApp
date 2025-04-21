using System;
using Microsoft.AspNetCore.Mvc;
using ZooApp.Domain.Entities;
using ZooApp.Domain.Repositories;
using ZooApp.Application.Interfaces;
using System.Runtime.InteropServices;

namespace ZooApp.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository _repo;
        private readonly IAnimalTransferService _transferService;

        public AnimalsController(
            IAnimalRepository repo,
            IAnimalTransferService transferService)
        {
            _repo = repo;
            _transferService = transferService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(Guid id) => Ok(_repo.GetById(id));

        [HttpPost]
        public IActionResult Create([FromBody] Animal animal)
        {
            _repo.Add(animal);
            return CreatedAtAction(nameof(Get), new { id = animal.Id }, animal);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _repo.Remove(id);
            return NoContent();
        }

        [HttpPost("{id}/transfer")]
        public IActionResult Transfer(Guid id, [FromBody] Guid toEnclosureId)
        {
            _transferService.Transfer(id, toEnclosureId);
            return NoContent();
        }
    }
}
