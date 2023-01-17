using GrownOver.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.Interfaces
{
    public interface IInventoryService
    {
        public Task<InventoryVM> GetInventoryById(int id);
        public dynamic RemoveItem(int inventoryId, string type);
        public dynamic AddItem(int inventoryId, int itemId, string type);
    }
}
