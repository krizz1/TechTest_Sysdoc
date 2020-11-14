using System.Collections.Generic;
using System.Linq;

namespace TestApi.Logic
{
    public static partial class Mapping
    { 
        public static class Project
        {
            public static Domain.Project MapOne(Data.Models.Project project) =>
                new Domain.Project()
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    ProgressStatus = Mapping.ProgressStatus.MapOne(project.ProgressStatus)
                };

            public static IEnumerable<Domain.Project> MapMany(IEnumerable<Data.Models.Project> projects) =>
                projects.Select(x => MapOne(x));
        }
    }
}
