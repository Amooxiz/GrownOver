using GrownOver.Application.Interfaces;
using GrownOver.Application.ViewModels;
using GrownOver.Domain.Models;
using GrownOver.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Infrastructure.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<InventoryVM> GetInventoryById(int id)
        {
            var inventory = await _inventoryRepository.GetInventoryById(id);

            InventoryVM vm = new InventoryVM()
            {
                Id = inventory.Id,
            };

            if (inventory.weapon != null)
            {
                vm.weaponVM = new WeaponVM()
                {
                    Id = inventory.WeaponId,
                    Name = inventory.weapon.Name,
                    Description = inventory.weapon.Description,
                    Weight = inventory.weapon.Weight,
                    Damage = inventory.weapon.Damage,
                    Price = inventory.weapon.Price,
                    Loot = inventory.weapon.Loot,
                    Type = inventory.weapon.Type,
                };
            }

            if (inventory.armor != null)
            {
                vm.armorVM = new ArmorVM()
                {
                    Id = inventory.ArmorId,
                    Name = inventory.armor.Name,
                    Description = inventory.armor.Description,
                    Weight = inventory.armor.Weight,
                    Price = inventory.armor.Price,
                    Resistance = inventory.armor.Resistance,
                    Loot = inventory.armor.Loot,
                    Type = inventory.armor.Type
                };
            }

            if (inventory.food != null)
            {
                vm.foodVM = new FoodVM()
                {
                    Id = inventory.FoodId,
                    Name = inventory.food.Name,
                    Description = inventory.food.Description,
                    Weight = inventory.food.Weight,
                    Price = inventory.food.Price,
                    Energy = inventory.food.Energy,
                    Loot = inventory.food.Loot,
                    Type = inventory.food.Type,
                };
            }

            if (inventory.material != null)
            {
                vm.materialVM = new MaterialVM()
                {
                    Id = inventory.MaterialId,
                    Name = inventory.material.Name,
                    Description = inventory.material.Description,
                    Weight = inventory.material.Weight,
                    Price = inventory.material.Price,
                    Quality = inventory.material.Quality,
                    Loot = inventory.material.Loot,
                    Type = inventory.material.Type
                };
            }

            return vm;
        }

        public dynamic RemoveItem(int inventoryId, string type)
        {
            BaseItem item = _inventoryRepository.RemoveItem(inventoryId, type);

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

        public dynamic AddItem(int inventoryId, int itemId, string type)
        {
            BaseItem item = _inventoryRepository.AddItem(inventoryId, itemId, type);

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
    }
}
