using System;
using System.Collections.Generic;
using System.Text;

namespace TestApi.Data.Repositories
{
    public class ActionRepository : Repository<Models.Action>, IActionRepository
    {
        public ActionRepository(SysdocContext context) : base(context)
        {

        }
    }
}
