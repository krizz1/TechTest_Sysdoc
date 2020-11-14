using System;
using System.Collections.Generic;
using System.Text;

namespace TestApi.Data.Repositories
{
    public class ProjectRepository : Repository<Models.Project>, IProjectRepository
    {
        public ProjectRepository(SysdocContext context) : base(context)
        {

        }
    }
}
