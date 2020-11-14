using System.Collections.Generic;
using System.Linq;

namespace TestApi.Logic
{
    public static partial class Mapping
    { 
        public static class Action
        {
            public static Domain.Action MapOne(Data.Models.Action action) =>
                new Domain.Action()
                {
                    Id = action.Id,
                    Name = action.Name,
                    Description = action.Description,
                    ProgressStatus = Mapping.ProgressStatus.MapOne(action.ProgressStatus),
                    RagStatus = Mapping.RagStatus.MapOne(action.RagStatus)
                };

            public static IEnumerable<Domain.Action> MapMany(IEnumerable<Data.Models.Action> actions) =>
                actions.Select(x => MapOne(x));
        }
    }
}
