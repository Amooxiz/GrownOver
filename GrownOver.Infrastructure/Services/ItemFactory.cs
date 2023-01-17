using GrownOver.Application.Interfaces;
using GrownOver.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Infrastructure.Services
{
    public class ItemFactory : IItemFactory
    {
        public BaseItem CreateItem(string type, string? Name, int Price, string? Description, int Weight, int Loot, int value)
        {
            switch (type)
            {
                case "weapon":
                    return new Weapon() { Name = Name, Price = Price, Description = Description, Type = type, Weight = Weight, Loot = Loot, Damage = value };
                case "armor":
                    return new Armor() { Name = Name, Price = Price, Description = Description, Type = type, Weight = Weight, Loot = Loot, Resistance = value };
                case "food":
                    return new Food() { Name = Name, Price = Price, Description = Description, Type = type, Weight = Weight, Loot = Loot, Energy = value };
                case "material":
                    return new Material() { Name = Name, Price = Price, Description = Description, Type = type, Weight = Weight, Loot = Loot, Quality = value };
                default:
                    return null;
            }
        }
    }
}
