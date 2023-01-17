using GrownOver.Application.Interfaces;
using GrownOver.Domain.Models;
using GrownOver.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
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

        public Inventory GetInventoryById(int id)
        {
            var inv = _context.Inventories
            .Include(p => p.food)
            .Include(p => p.armor)
            .Include(p => p.material)
            .Include(p => p.weapon)
            .FirstOrDefault(x => x.Id == id);

            return inv;

        }

        public dynamic RemoveItem(int inventoryId, string type)
        {
            var inv = _context.Inventories
            .Include(p => p.food)
            .Include(p => p.armor)
            .Include(p => p.material)
            .Include(p => p.weapon)
            .FirstOrDefault(x => x.Id == inventoryId);

            dynamic tempItem;

            switch (type)
            {
                case "weapon":
                    tempItem = inv.weapon;
                    inv.weapon = null;
                    break;
                case "armor":
                    tempItem = inv.armor;
                    inv.armor = null;
                    break;
                case "food":
                    tempItem = inv.food;
                    inv.food = null;
                    break;
                case "material":
                    tempItem = inv.material;
                    inv.material = null;
                    break;
                default:
                    tempItem = null;
                    break;
            }

            _context.SaveChanges();
            return tempItem;
        }

        public dynamic AddItem(int inventoryId, int itemId, string type)
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
                    baseItem = null;
                    break;
            }

            _context.SaveChanges();
            return baseItem;
        }
    }
}
