using GrownOver.Application.Interfaces;
using GrownOver.Application.ViewModels;
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

        public ItemsVM GetItemsByHideoutId(int hideoutId)
        {
            var items = _context.BaseItemHideouts.Where(x => x.HideoutId == hideoutId).ToList();

            ItemsVM itemsVM = new ItemsVM()
            {
                armorVMs = new List<ArmorVM>(),
                weaponVMs = new List<WeaponVM>(),
                foodVMs = new List<FoodVM>(),
                materialVMs = new List<MaterialVM>(),
            };

            foreach (var item in items)
            {
                if (_context.Armors.Any(x => x.Id == item.BaseItemId))
                {
                    var armor = _context.Armors.Find(item.BaseItemId);
                    ArmorVM armorVM = new ArmorVM()
                    {
                        Description = armor.Description,
                        Durability = armor.Durability,
                        Loot = armor.Loot,
                        Name = armor.Name,
                        Price = armor.Price,
                        Resistance = armor.Resistance,
                        Weight = armor.Weight,
                        Id = armor.Id,
                    };
                    itemsVM.armorVMs.Add(armorVM);
                }
                else if (_context.Weapons.Any(x => x.Id == item.BaseItemId))
                {
                    var weapon = _context.Weapons.Find(item.BaseItemId);
                    WeaponVM weaponVM = new WeaponVM()
                    {
                        Description = weapon.Description,
                        Durability = weapon.Durability,
                        Loot = weapon.Loot,
                        Name = weapon.Name,
                        Price = weapon.Price,
                        Weight = weapon.Weight,
                        Id = weapon.Id,
                        Damage = weapon.Damage,
                    };
                    itemsVM.weaponVMs.Add(weaponVM);
                }
                else if (_context.Materials.Any(x => x.Id == item.BaseItemId))
                {
                    var material = _context.Materials.Find(item.BaseItemId);
                    MaterialVM materialVM = new MaterialVM()
                    {
                        Description = material.Description,
                        Loot = material.Loot,
                        Name = material.Name,
                        Price = material.Price,
                        Weight = material.Weight,
                        Id = material.Id,
                        Quality = material.Quality,
                    };
                    itemsVM.materialVMs.Add(materialVM);
                }
                else if (_context.Foods.Any(x => x.Id == item.BaseItemId))
                {
                    var food = _context.Foods.Find(item.BaseItemId);
                    FoodVM foodVM = new FoodVM()
                    {
                        Description = food.Description,
                        Loot = food.Loot,
                        Name = food.Name,
                        Price = food.Price,
                        Weight = food.Weight,
                        Id = food.Id,
                    };
                    itemsVM.foodVMs.Add(foodVM);
                }
            }
            return itemsVM;
        }
    }
}
