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
    public class FeedingSchedulesController : ControllerBase
    {
        private readonly IFeedingScheduleRepository _repo;
        private readonly IFeedingOrganizationService _feedingService;

        public FeedingSchedulesController(
            IFeedingScheduleRepository repo,
            IFeedingOrganizationService feedingService)
        {
            _repo = repo;
            _feedingService = feedingService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(Guid id) => Ok(_repo.GetById(id));

        [HttpPost]
        public IActionResult Create([FromBody] FeedingSchedule schedule)
        {
            _repo.Add(schedule);
            return CreatedAtAction(nameof(Get), new { id = schedule.Id }, schedule);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _repo.Remove(id);
            return NoContent();
        }

        [HttpPost("{id}/execute")]
        public IActionResult Execute(Guid id)
        {
            _feedingService.ExecuteFeeding(id);
            return NoContent();
        }
    }
}
