using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Data.Models;

namespace TestApi.Data.Repositories
{
    public class ProjectRepository : Repository<Models.Project>, IProjectRepository
    {
        public ProjectRepository(SysdocContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Project>> GetByActionId(int actionId)
        {
            return await context.Projects.SelectMany(x => x.ProjectActions.Where(y => y.ActionId == actionId)).Select(x => x.Project).ToListAsync();
        }
    }
}
