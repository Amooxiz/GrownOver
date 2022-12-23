using GrownOver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.Interfaces
{
    public interface IInventoryRepository
    {
        public Task<Inventory> GetInventoryById(int id);
    }
}
