using System.ComponentModel.DataAnnotations;

namespace TestApi.Data.Models
{
    public class ProjectAction
    {
        public int ProjectId { get; set; }
        public int ActionId { get; set; }
        public Project Project { get; set; }
        public Action Action { get; set; }
    }
}
