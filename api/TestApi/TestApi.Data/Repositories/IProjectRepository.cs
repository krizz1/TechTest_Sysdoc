using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Data.Models;

namespace TestApi.Data.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<IEnumerable<Project>> GetByActionId(int actionId);
    }
}
