using Microsoft.EntityFrameworkCore;
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
    
        public async Task<ProjectAction> GetByIds(int projectId, int actionId) =>
            await context.ProjectAction.Where(x => x.ProjectId == projectId && x.ActionId == actionId).SingleOrDefaultAsync();
    }
}
