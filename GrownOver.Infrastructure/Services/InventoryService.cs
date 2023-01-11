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
                    Durability = inventory.weapon.Durability,
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
                    Durability = inventory.armor.Durability,
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

            if (inventory.weapon != null)
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
            return _inventoryRepository.RemoveItem(inventoryId, type);
        }

        public void AddItem(int inventoryId, int itemId, string type)
        {
            _inventoryRepository.AddItem(inventoryId, itemId, type);
        }
    }
}
