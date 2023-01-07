using GrownOver.Application.Interfaces;
using GrownOver.Domain.Models;
using GrownOver.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Infrastructure.Repositories
{
    public class HideOutRepository : IHideOutRepository
    {
        private readonly GrownOverDbContext _context;

        public HideOutRepository(GrownOverDbContext context)
        {
            _context = context;
        }

        public void AddItem(int hideOutId, int itemId, string type)
        {
            var hideOut = _context.HideOuts.Find(hideOutId);
            dynamic? baseItem;
            switch (type)
            {
                case "weapon":
                    baseItem = (Weapon)_context.Weapons.Find(itemId);
                    break;
                case "armor":
                    baseItem = (Armor)_context.Armors.Find(itemId);
                    break;
                case "food":
                    baseItem = (Food)_context.Foods.Find(itemId);
                    break;
                case "material":
                    baseItem = (Material)_context.Materials.Find(itemId);
                    break;
                default:
                    baseItem = null;
                    break;
            }


            BaseItemHideout baseItemHideout = new BaseItemHideout()
            {
                HideOut = hideOut,
                BaseItem = baseItem
            };

            _context.BaseItemHideouts.Add(baseItemHideout);
            _context.SaveChanges();
        }

        public dynamic RemoveItem(int hideOutId, int itemId, string type)
        {
            var hideOut = _context.HideOuts.Find(hideOutId);
            dynamic? baseItem;
            switch (type)
            {
                case "weapon":
                    baseItem = (Weapon)_context.Weapons.Find(itemId);
                    break;
                case "armor":
                    baseItem = (Armor)_context.Armors.Find(itemId);
                    break;
                case "food":
                    baseItem = (Food)_context.Foods.Find(itemId);
                    break;
                case "material":
                    baseItem = (Material)_context.Materials.Find(itemId);
                    break;
                default:
                    baseItem = null;
                    break;
            }

            BaseItemHideout baseItemHideout = new BaseItemHideout()
            {
                HideOut = hideOut,
                BaseItem = baseItem
            };

            _context.BaseItemHideouts.Remove(baseItemHideout);
            _context.SaveChanges();

            return baseItem;
        }
    }
}
