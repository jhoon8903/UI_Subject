using System;
using System.Collections.Generic;
using System.Linq;
using _01.Scripts.Data;
using _01.Scripts.Interfaces;

namespace _01.Scripts.Loader
{
    [Serializable]
    public class JobDataLoader : ILoader<JobClass, JobData>
    {
        public List<JobData> jobs = new();

        public Dictionary<JobClass, JobData> CreateData()
        {
            return jobs.ToDictionary(job => job.JobClass);
        }
    }
}