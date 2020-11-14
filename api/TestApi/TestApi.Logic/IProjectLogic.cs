using System.Threading.Tasks;
using TestApi.Domain;

namespace TestApi.Logic
{
    public interface IProjectLogic
    {
        Task<Project> GetById(int projectId);

        Task AddActionToProject(int projectId, int actionId);
    }
}
