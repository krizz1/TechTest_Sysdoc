using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Data.Models;

namespace TestApi.Data.Repositories
{
    public class ProjectActionRepository : Repository<ProjectAction>, IProjectActionRepository
    {
        public ProjectActionRepository(SysdocContext context) : base(context)
        {
           
        }
    }
}
