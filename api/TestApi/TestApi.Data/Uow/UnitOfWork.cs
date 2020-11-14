using System;
using System.Threading.Tasks;
using TestApi.Data.Repositories;

namespace TestApi.Data
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly SysdocContext _context;

        public UnitOfWork(SysdocContext context)
        {
            _context = context;

            Projects = new ProjectRepository(context);
            Actions = new ActionRepository(context);
            ProjectActions = new ProjectActionRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public IProjectRepository Projects { get; private set; }
        public IActionRepository Actions { get; private set; }
        public IProjectActionRepository ProjectActions { get; private set; }
        
    }
}
