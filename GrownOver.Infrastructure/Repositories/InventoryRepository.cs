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
            var inv = Task.Run(() => _context.Inventories
            .Include(p => p.food)
            .Include(p => p.armor)
            .Include(p => p.material)
            .Include(p => p.weapon)
            .FirstOrDefault(x => x.Id == id));

            return await inv;

        }

        public void RemoveItem(int inventoryId, string type)
        {
            var inv = _context.Inventories
            .Include(p => p.food)
            .Include(p => p.armor)
            .Include(p => p.material)
            .Include(p => p.weapon)
            .FirstOrDefault(x => x.Id == inventoryId);

            switch (type)
            {
                case "weapon":
                    inv.weapon = null;
                    break;
                case "armor":
                    inv.armor = null;
                    break;
                case "food":
                    inv.food = null;
                    break;
                case "material":
                    inv.material = null;
                    break;
                default:
                    break;
            }

            _context.SaveChanges();
        }

        public void AddItem(int inventoryId, int itemId, string type)
        {
            var inv = _context.Inventories
            .Include(p => p.food)
            .Include(p => p.armor)
            .Include(p => p.material)
            .Include(p => p.weapon)
            .FirstOrDefault(x => x.Id == inventoryId);

            dynamic? baseItem;
            switch (type)
            {
                case "weapon":
                    baseItem = _context.Weapons.Find(itemId);
                    inv.weapon = baseItem;
                    break;
                case "armor":
                    baseItem = _context.Armors.Find(itemId);
                    inv.armor = baseItem;
                    break;
                case "food":
                    baseItem = _context.Foods.Find(itemId);
                    inv.food = baseItem;
                    break;
                case "material":
                    baseItem = _context.Materials.Find(itemId);
                    inv.material = baseItem;
                    break;
                default:
                    break;
            }

            _context.SaveChanges();
        }
    }
}
