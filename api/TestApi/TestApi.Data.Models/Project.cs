using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApi.Data.Models
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public ProgressStatus ProgressStatus { get; set; }
        public ICollection<ProjectAction> ProjectActions { get; set; }
    }
}