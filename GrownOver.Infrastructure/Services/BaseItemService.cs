using GrownOver.Application.Interfaces;
using GrownOver.Application.ViewModels;
using GrownOver.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                     return _baseItemRepository.AddWeapon((Weapon)item);
                    break;
                case "armor":
                     return _baseItemRepository.AddArmor((Armor)item);
                    break;
                case "food":
                     return _baseItemRepository.AddFood((Food)item);
                    break;
                case "material":
                    return _baseItemRepository.AddMaterial((Material)item);
                    break;
                default:
                    return null;
                    break;
            }
        }

        public void AddWeapon(string? Name, int Price, string? Description, int Weight, int Damage, int Loot)
        {
            

            //_baseItemRepository.AddWeapon(weapon);
        }

        public void AddArmor(string? Name, int Price, string? Description, int Weight, int Resistance, int Loot)
        {
            Armor armor = new Armor()
            {
                Description = Description,
                Loot = Loot,
                Name = Name,
                Price = Price,
                Resistance = Resistance,
                Weight = Weight,
                Type = "armor"
            };

            _baseItemRepository.AddArmor(armor);
        }

        public void AddMaterial(string? Name, int Price, string? Description, int Weight, int Quality, int Loot)
        {
            Material material = new Material()
            {
                Weight = Weight,
                Description = Description,
                Loot = Loot,
                Name = Name,
                Price = Price,
                Quality = Quality,
                Type = "material"
            };

            _baseItemRepository.AddMaterial(material);
        }

        public void AddFood(string? Name, int Price, string? Description, int Weight, int Energy, int Loot)
        {
            Food food = new Food()
            {
                Weight = Weight,
                Description = Description,
                Energy = Energy,
                Loot = Loot,
                Name = Name,
                Price = Price,
                Type = "food"
            };

            _baseItemRepository.AddFood(food);
        }

        public dynamic GetItem(int id, string type)
        {
            return _baseItemRepository.GetItem(id, type);
        }
    }
}
