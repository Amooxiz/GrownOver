using GrownOver.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.Interfaces
{
    public interface IBaseItemService
    {
        public ItemsVM GetAllItems();
        public void AddWeapon(string? Name, int Price, string? Description, int Weight, int Damage, int Loot);
        public void AddArmor(string? Name, int Price, string? Description, int Weight, int Resistance, int Loot);
        public void AddMaterial(string? Name, int Price, string? Description, int Weight, int Quality, int Loot);
        public void AddFood(string? Name, int Price, string? Description, int Weight, int Energy, int Loot);
        public dynamic GetItem(int id, string type);
        public dynamic AddItem(string? Name, int Price, string? Description, int Weight, int Loot, int Value, string Type);
    }
}
