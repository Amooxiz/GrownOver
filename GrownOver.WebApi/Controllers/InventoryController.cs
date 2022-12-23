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
    }
}
