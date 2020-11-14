using System;
using System.Collections.Generic;

namespace TestApi.Domain
{
    public class Project
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public ProgressStatus ProgressStatus { get; set; }
        public IEnumerable<Action> Actions { get; set; }
    }
}
