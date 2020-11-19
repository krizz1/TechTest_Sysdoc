using System.Threading.Tasks;
using TestApi.Data.Models;

namespace TestApi.Data.Repositories
{
    public interface IProjectActionRepository : IRepository<ProjectAction>
    {
        Task<ProjectAction> GetByIds(int projectId, int actionId);
    }
}
