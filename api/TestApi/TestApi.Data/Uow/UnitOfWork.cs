using System;
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
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IProjectRepository Projects { get; private set; }
        public IActionRepository Actions { get; private set; }
    }
}
