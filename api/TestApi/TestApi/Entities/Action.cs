using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestApi.Entities.Enums;

namespace TestApi.Entities
{
    public class Action
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public RagStatus RagStatus { get; set; }
        public ProgressStatus ProgressStatus { get; set; }
    }
}