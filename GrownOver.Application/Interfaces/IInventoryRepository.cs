﻿using GrownOver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.Interfaces
{
    public interface IInventoryRepository
    {
        public Inventory GetInventoryById(int id);
        public dynamic RemoveItem(int inventoryId, string type);
        public dynamic AddItem(int inventoryId, int itemId, string type);
    }
}
