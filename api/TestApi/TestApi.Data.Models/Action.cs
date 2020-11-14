using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApi.Data.Models
{
    public class Action
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public RagStatus RagStatus { get; set; }
        public ProgressStatus ProgressStatus { get; set; }
        public ICollection<ProjectAction> ProjectActions { get; set; }
    }
}