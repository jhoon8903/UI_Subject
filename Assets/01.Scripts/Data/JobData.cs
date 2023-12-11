using System;

namespace _01.Scripts.Data
{
    public enum JobClass
    {
        Captain, Bosun, Mate
    }
    
    [Serializable]
    public class JobData
    {

        #region Property
        public JobClass JobClass
        {
            get => _jobClass;
            set => _jobClass = value;
        }

        public string Desc
        {
            get => _desc;
            set => _desc = value;
        }
        #endregion

        #region Field
        private JobClass _jobClass;
        private string _desc;
        #endregion
    }                         
}