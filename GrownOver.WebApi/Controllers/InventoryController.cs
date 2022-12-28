using GrownOver.Application.Interfaces;
using GrownOver.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrownOver.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]/[action]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("{id}")]
        public async Task<InventoryVM> GetInventory([FromRoute] int id)
        {
            return await _inventoryService.GetInventoryById(id);
        }

        [HttpDelete("{inventoryid}/{type}")]
        public void RemoveItem(int inventoryid, string type)
        {
            _inventoryService.RemoveItem(inventoryid, type);
        }

        [HttpGet("{inventoryid}/{itemid}/{type}")]
        public void AddItem(int inventoryid, int itemid, string type)
        {
            _inventoryService.AddItem(inventoryid, itemid, type);
        }
    }
}
