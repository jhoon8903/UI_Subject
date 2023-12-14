using System;
using System.Collections.Generic;
using System.Linq;
using _01.Scripts.Data;
using _01.Scripts.Interfaces;

namespace _01.Scripts.Loader
{
    [Serializable]
    public class JobDataLoader : ILoader<string, JobData>
    {
        public List<JobData> jobs = new();

        public Dictionary<string, JobData> CreateData()
        {
            return jobs.ToDictionary(job => job.JobClass.ToString());
        }

        void ILoader<string, JobData>.MapData(string[] row)
        {
            jobs.Add(new JobData
            {
                JobClass = (JobClass)Enum.Parse(typeof(JobClass), row[0]),
                Desc = row[1]
            });
        }
    }
}