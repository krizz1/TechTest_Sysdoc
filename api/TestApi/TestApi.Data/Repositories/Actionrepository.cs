using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Data.Models;

namespace TestApi.Data.Repositories
{
    public class ActionRepository : Repository<Action>, IActionRepository
    {
        public ActionRepository(SysdocContext context) : base(context)
        {
           
        }

        public async Task<IEnumerable<Action>> GetByProjectId(int projectId)
        {
            return await context.Actions.SelectMany(x => x.ProjectActions.Where(y => y.ProjectId == projectId)).Select(x=>x.Action).ToListAsync();
        }
    }
}
