using Microsoft.EntityFrameworkCore;
using TeknorixJobApi.Data;
using TeknorixJobApi.DTOs;
using TeknorixJobApi.Models;

namespace TeknorixJobApi.Service
{
    public class JobService : IJobService
    {
        private readonly DataContext _context;

        public JobService(DataContext context)
        {
            _context = context;
        }
        public async Task<Job> CreateJob(CreateJobDto job)
        {
            var newJob = new Job
            {
                Title=job.Title,
                Description=job.Description,
                LocationId=job.LocationId,
                DepartmentId=job.DepartmentId,
                ClosingDate=job.ClosingDate,
                Code= $"JOB-{Guid.NewGuid().ToString().Substring(0, 4)}"
            };

            _context.Jobs.Add(newJob);
            await _context.SaveChangesAsync();
            return newJob;
        }

        public async Task<Job> GetJobById(int id)
        {
            var job = await _context.Jobs.Include(x => x.Location).Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
            if (job == null)
                return null;

            return job;
        
        }

        public async Task<(List<Job>, int)> ListJobs(JobFilterDto jobFilter)
        {
            var jobs = await _context.Jobs.ToListAsync();
            int jobCount;

            if (!string.IsNullOrEmpty(jobFilter.Q))
            {
                jobs = jobs.Where(x => x.Title.ToUpper().Contains(jobFilter.Q.ToUpper())).ToList();
            }

            if (jobFilter.LocationId is not null)
            {
                jobs = jobs.Where(x => x.LocationId == jobFilter.LocationId).ToList();
            }

            if (jobFilter.DepartmentId is not null)
            {
                jobs = jobs.Where(x => x.DepartmentId == jobFilter.DepartmentId).ToList();
            }

            jobCount = jobs.Count;

            jobs = jobs.Skip((jobFilter.PageNo - 1) * jobFilter.PageSize).Take(jobFilter.PageSize).ToList();

            return (jobs,jobCount);
        }

        public async Task<Job> UpdateJob(int id, CreateJobDto updatedJob)
        {
            var jobToBeUpdated = _context.Jobs.FirstOrDefault(x => x.Id == id);

            if (jobToBeUpdated is null)
            {
                return null;
            }

            jobToBeUpdated.Title = updatedJob.Title;
            jobToBeUpdated.Description = updatedJob.Description;
            jobToBeUpdated.LocationId = updatedJob.LocationId;
            jobToBeUpdated.DepartmentId = updatedJob.DepartmentId;
            jobToBeUpdated.ClosingDate = updatedJob.ClosingDate;

            await _context.SaveChangesAsync();

            return jobToBeUpdated;
        }
    }
}
