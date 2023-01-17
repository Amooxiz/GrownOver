using GrownOver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.Interfaces
{
    public interface IItemFactory
    {
        public BaseItem CreateItem(string type, string? Name, int Price, string? Description, int Weight, int Loot, int value);
    }
}
