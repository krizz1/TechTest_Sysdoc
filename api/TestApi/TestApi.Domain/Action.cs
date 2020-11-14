using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApi.Domain
{
    public class Action
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public RagStatus RagStatus { get; set; }
        public ProgressStatus ProgressStatus { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public int ProjectCount
        {
            get
            {
                return Projects?.Count() ?? 0;
            }
        }
    }
}
