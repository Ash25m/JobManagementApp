using Microsoft.AspNetCore.Mvc;
using TeknorixJobApi.DTOs;
using TeknorixJobApi.Models;

namespace TeknorixJobApi.Service
{
    public interface IJobService
    {
        Task<Job> CreateJob(CreateJobDto job);
        Task<Job> UpdateJob(int id, CreateJobDto updatedJob);
        Task<(List<Job>,int)> ListJobs(JobFilterDto jobFilter);
        Task<Job> GetJobById(int id);
    }
}
