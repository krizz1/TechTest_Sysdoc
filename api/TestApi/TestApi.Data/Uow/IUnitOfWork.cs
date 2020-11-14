using System.Threading.Tasks;
using TestApi.Data.Repositories;

namespace TestApi.Data
{
    public interface IUnitOfWork
    {
        Task SaveChanges();

        public IProjectRepository Projects { get; }
        public IActionRepository Actions { get; }
        public IProjectActionRepository ProjectActions { get; }
    }
}
