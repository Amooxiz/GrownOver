using GrownOver.Application.Interfaces;
using GrownOver.Application.ViewModels;
using GrownOver.Domain.Models;
using GrownOver.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Infrastructure.Repositories
{
    public class BaseItemRepository : IBaseItemRepository
    {
        private readonly GrownOverDbContext _context;

        public BaseItemRepository(GrownOverDbContext context)
        {
            _context = context;
        }

        public ItemsVM GetAllItems()
        {
            ItemsVM itemsVM = new ItemsVM()
            {
                armorVMs = new List<ArmorVM>(),
                weaponVMs = new List<WeaponVM>(),
                foodVMs = new List<FoodVM>(),
                materialVMs = new List<MaterialVM>(),
            };

            foreach (var item in _context.Armors.ToList())
            {
                ArmorVM armorVM = new ArmorVM()
                {
                    Description = item.Description,
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Resistance = item.Resistance,
                    Weight = item.Weight,
                    Loot = item.Loot,
                    Type = item.Type,
                };
                itemsVM.armorVMs.Add(armorVM);
            }

            foreach (var item in _context.Weapons.ToList())
            {
                WeaponVM weaponVM = new WeaponVM()
                {
                    Description = item.Description,
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Weight = item.Weight,
                    Damage = item.Damage,
                    Loot = item.Loot,
                    Type = item.Type
                };
                itemsVM.weaponVMs.Add(weaponVM);
            }

            foreach (var item in _context.Materials.ToList())
            {
                MaterialVM materialVM = new MaterialVM()
                {
                    Description = item.Description,
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Weight = item.Weight,
                    Quality = item.Quality,
                    Loot = item.Loot,
                    Type = item.Type
                };
                itemsVM.materialVMs.Add(materialVM);
            }

            foreach (var item in _context.Foods.ToList())
            {
                FoodVM foodVM = new FoodVM()
                {
                    Description = item.Description,
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Weight = item.Weight,
                    Energy = item.Energy,
                    Loot = item.Loot,
                    Type = item.Type
                };
                itemsVM.foodVMs.Add(foodVM);
            }

            return itemsVM;
        }

        public void AddWeapon(Weapon weapon)
        {
            _context.Weapons.Add(weapon);
            _context.SaveChanges();
        }

        public void AddArmor(Armor armor)
        {
            _context.Armors.Add(armor);
            _context.SaveChanges();
        }

        public void AddMaterial(Material material)
        {
            _context.Materials.Add(material);
            _context.SaveChanges();
        }

        public void AddFood(Food food)
        {
            _context.Foods.Add(food);
            _context.SaveChanges();
        }

        public dynamic GetItem(int id, string type)
        {
            dynamic item;
            switch (type)
            {
                case "weapon":
                    item = _context.Weapons.Find(id);
                    break;
                case "armor":
                    item = _context.Armors.Find(id);
                    break;
                case "material":
                    item = _context.Materials.Find(id);
                    break;
                case "food":
                    item = _context.Foods.Find(id);
                    break;
                default:
                    item = null;
                    break;
            }

            return item;
        }
    }
}
