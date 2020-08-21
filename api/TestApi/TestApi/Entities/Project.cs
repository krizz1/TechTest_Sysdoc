using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestApi.Entities.Enums;

namespace TestApi.Entities
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public ProgressStatus ProgressStatus { get; set; }
    }
}