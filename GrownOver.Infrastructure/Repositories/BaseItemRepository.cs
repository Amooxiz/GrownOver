using GrownOver.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Infrastructure.Repositories
{
    public class BaseItemRepository
    {
        private readonly GrownOverDbContext _context;

        public BaseItemRepository(GrownOverDbContext context)
        {
            _context = context;
        }
    }
}
