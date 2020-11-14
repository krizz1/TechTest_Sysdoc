using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Data.Models;

namespace TestApi.Data.Repositories
{
    public interface IActionRepository : IRepository<Action>
    {
        Task<IEnumerable<Action>> GetByProjectId(int projectId);
    }
}
