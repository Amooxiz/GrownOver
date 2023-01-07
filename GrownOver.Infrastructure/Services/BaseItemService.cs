using GrownOver.Application.Interfaces;
using GrownOver.Application.ViewModels;
using GrownOver.Contracts.RequestsModels;
using GrownOver.Domain.Models;
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

        public BaseItemService(IBaseItemRepository baseItemRepository)
        {
            _baseItemRepository = baseItemRepository;
        }

        public ItemsVM GetAllItems()
        {
            return _baseItemRepository.GetAllItems();
        }

        public void AddWeapon(PushWeaponRequest pushWeaponRequest)
        {
            Weapon weapon = new Weapon()
            {
                Weight = pushWeaponRequest.Weight,
                Durability = pushWeaponRequest.Durability,
                Description = pushWeaponRequest.Description,
                Damage = pushWeaponRequest.Damage,
                Loot = pushWeaponRequest.Loot,
                Name = pushWeaponRequest.Name,
                Price = pushWeaponRequest.Price,
            };

            _baseItemRepository.AddWeapon(weapon);
        }

        public void AddArmor(PushArmorRequest pushArmorRequest)
        {
            Armor armor = new Armor()
            {
                Description = pushArmorRequest.Description,
                Durability = pushArmorRequest.Durability,
                Loot = pushArmorRequest.Loot,
                Name = pushArmorRequest.Name,
                Price = pushArmorRequest.Price,
                Resistance = pushArmorRequest.Resistance,
                Weight = pushArmorRequest.Weight,
            };

            _baseItemRepository.AddArmor(armor);
        }

        public void AddMaterial(PushMaterialRequest pushMaterialRequest)
        {
            Material material = new Material()
            {
                Weight = pushMaterialRequest.Weight,
                Description = pushMaterialRequest.Description,
                Loot = pushMaterialRequest.Loot,
                Name = pushMaterialRequest.Name,
                Price = pushMaterialRequest.Price,
                Quality = pushMaterialRequest.Quality,
            };

            _baseItemRepository.AddMaterial(material);
        }

        public void AddFood(PushFoodRequest pushFoodRequest)
        {
            Food food = new Food()
            {
                Weight = pushFoodRequest.Weight,
                Description = pushFoodRequest.Description,
                Energy = pushFoodRequest.Energy,
                Loot = pushFoodRequest.Loot,
                Name = pushFoodRequest.Name,
                Price = pushFoodRequest.Price
            };

            _baseItemRepository.AddFood(food);
        }

        public dynamic GetItem(int id, string type)
        {
            return _baseItemRepository.GetItem(id, type);
        }
    }
}
