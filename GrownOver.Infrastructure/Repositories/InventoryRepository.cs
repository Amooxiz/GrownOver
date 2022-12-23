using GrownOver.Application.Interfaces;
using GrownOver.Domain.Models;
using GrownOver.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly GrownOverDbContext _context;

        public InventoryRepository(GrownOverDbContext context)
        {
            _context = context;
        }

        public async Task<Inventory> GetInventoryById(int id)
        {
            var inv = _context.Inventories
                .Include(p => p.food)
                .Include(p => p.armor)
                .Include(p => p.material)
                .Include(p => p.weapon)
                .FirstOrDefault(x => x.Id == id);

            return inv;

        }
    }
}
