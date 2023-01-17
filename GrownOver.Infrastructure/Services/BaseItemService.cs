using GrownOver.Application.Interfaces;
using GrownOver.Application.ViewModels;
using GrownOver.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Infrastructure.Services
{
    public class BaseItemService : IBaseItemService
    {
        private readonly IBaseItemRepository _baseItemRepository;
        private readonly IItemFactory _itemFactory;

        public BaseItemService(IBaseItemRepository baseItemRepository, IItemFactory itemFactory)
        {
            _baseItemRepository = baseItemRepository;
            _itemFactory = itemFactory;
        }

        public ItemsVM GetAllItems()
        {
            return _baseItemRepository.GetAllItems();
        }

        public dynamic AddItem(string? Name, int Price, string? Description, int Weight, int Loot, int Value, string Type)
        {
            BaseItem item = _itemFactory.CreateItem(Type, Name, Price, Description, Weight, Loot, Value);

            switch (Type)
            {
                case "weapon":
                    _baseItemRepository.AddWeapon((Weapon)item);
                    break;
                case "armor":
                    _baseItemRepository.AddArmor((Armor)item);
                    break;
                case "food":
                    _baseItemRepository.AddFood((Food)item);
                    break;
                case "material":
                    _baseItemRepository.AddMaterial((Material)item);
                    break;
                default:
                    throw new Exception("Wrong type");
            }

            switch (Type)
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

        public dynamic GetItem(int id, string type)
        {
            return _baseItemRepository.GetItem(id, type);
        }
    }
}
