using System.Threading.Tasks;
using TestApi.Domain;

namespace TestApi.Logic
{
    public interface IActionLogic
    {
        Task<Action> GetById(int actionId);
    }
}
