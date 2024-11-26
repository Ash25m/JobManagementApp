using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeknorixJobApi.Data;
using TeknorixJobApi.DTOs;
using TeknorixJobApi.Models;
using TeknorixJobApi.Service;

namespace TeknorixJobApi.Controllers
{
    [ApiController]
    [Route("api/v1/jobs")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] CreateJobDto job)
        {
            var createdJob=await _jobService.CreateJob(job);
            //return Ok(createdJob);
            var locationUrl = $"http://{Request.Host}/api/v1/jobs/{createdJob.Id}";
            return StatusCode(201, locationUrl);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateJob(int id, [FromBody] CreateJobDto updatedJob)
        {
            var updateJob = await _jobService.UpdateJob(id, updatedJob);
            if (updateJob is null)
                return NotFound();

            return Ok(updateJob);
        }


        [HttpPost("list")]

        public async Task<IActionResult> ListJobs([FromBody] JobFilterDto jobFilter)
        {
            var filteredJobs=await _jobService.ListJobs(jobFilter);
            return Ok(new { total =filteredJobs.Item2, data = filteredJobs.Item1 });
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetJobById(int id)
        {
            var jobById= await _jobService.GetJobById(id);
            if (jobById is null)
                return NotFound();

            return Ok(jobById);
        }

    }
}
