using GrownOver.Application.Interfaces;
using GrownOver.Application.ViewModels;
using GrownOver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Infrastructure.Services
{
    public class HideOutService : IHideOutService
    {
        private readonly IHideOutRepository _hideOutRepository;

        public HideOutService(IHideOutRepository hideOutRepository)
        {
            _hideOutRepository = hideOutRepository;
        }

        public dynamic AddItem(int hideOutId, int itemId, string type, string customName)
        {
            BaseItem item = _hideOutRepository.AddItem(hideOutId, itemId, type, customName);

            switch (item.Type)
            {
                case "weapon":
                    Weapon weapon = (Weapon)item;
                    return new WeaponVM()
                    {
                        Damage = weapon.Damage,
                        Description = weapon.Description,
                        Loot = weapon.Loot,
                        CustomName = customName,
                        Name = weapon.Name,
                        Price = weapon.Price,
                        Type = weapon.Type,
                        Weight = weapon.Weight,
                        Id = weapon.Id
                    };
                case "armor":
                    Armor armor = (Armor)item;
                    return new ArmorVM()
                    {
                        Resistance = armor.Resistance,
                        Description = armor.Description,
                        Loot = armor.Loot,
                        CustomName = customName,
                        Name = armor.Name,
                        Price = armor.Price,
                        Type = armor.Type,
                        Weight = armor.Weight,
                        Id = armor.Id
                    };
                case "food":
                    Food food = (Food)item;
                    return new FoodVM()
                    {
                        Energy = food.Energy,
                        Description = food.Description,
                        Loot = food.Loot,
                        CustomName = customName,
                        Name = food.Name,
                        Price = food.Price,
                        Type = food.Type,
                        Weight = food.Weight,
                        Id = food.Id
                    };
                case "material":
                    Material material = (Material)item;
                    return new MaterialVM()
                    {
                        Quality = material.Quality,
                        Description = material.Description,
                        Loot = material.Loot,
                        CustomName = customName,
                        Name = material.Name,
                        Price = material.Price,
                        Type = material.Type,
                        Weight = material.Weight,
                        Id = material.Id
                    };
                default:
                    throw new Exception("Wrong type");
            }
        }

        public dynamic RemoveItem(int hideoutId, int itemId, string type)
        {
            BaseItem item = _hideOutRepository.RemoveItem(hideoutId, itemId, type);

            switch (item.Type)
            {
                case "weapon":
                    Weapon weapon = (Weapon)item;
                    return new WeaponVM()
                    {
                        Damage = weapon.Damage,
                        Description = weapon.Description,
                        Loot = weapon.Loot,
                        CustomName = weapon.Name,
                        Name = weapon.Name,
                        Price = weapon.Price,
                        Type = weapon.Type,
                        Weight = weapon.Weight,
                        Id = weapon.Id
                    };
                case "armor":
                    Armor armor = (Armor)item;
                    return new ArmorVM()
                    {
                        Resistance = armor.Resistance,
                        Description = armor.Description,
                        Loot = armor.Loot,
                        CustomName = armor.Name,
                        Name = armor.Name,
                        Price = armor.Price,
                        Type = armor.Type,
                        Weight = armor.Weight,
                        Id = armor.Id
                    };
                case "food":
                    Food food = (Food)item;
                    return new FoodVM()
                    {
                        Energy = food.Energy,
                        Description = food.Description,
                        Loot = food.Loot,
                        CustomName = food.Name,
                        Name = food.Name,
                        Price = food.Price,
                        Type = food.Type,
                        Weight = food.Weight,
                        Id = food.Id
                    };
                case "material":
                    Material material = (Material)item;
                    return new MaterialVM()
                    {
                        Quality = material.Quality,
                        Description = material.Description,
                        Loot = material.Loot,
                        CustomName = material.Name,
                        Name = material.Name,
                        Price = material.Price,
                        Type = material.Type,
                        Weight = material.Weight,
                        Id = material.Id
                    };
                default:
                    throw new Exception("Wrong type");
            }
        }

        public ItemsVM GetItemsByHideoutId(int hideoutId)
        {
            return _hideOutRepository.GetItemsByHideoutId(hideoutId);
        }
    }
}
