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
        private readonly IMediator _mediator;
        private const string sender = "inventoryController";

        public InventoryController(IInventoryService inventoryService, IMediator mediator)
        {
            _inventoryService = inventoryService;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<InventoryVM> GetInventory([FromRoute] int id)
        {
            //return await _inventoryService.GetInventoryById(id);
            return await _mediator.SendGet(sender, id);
        }

        [HttpDelete("{inventoryid}/{type}")]
        public dynamic RemoveItem(int inventoryid, string type)
        {
            return _inventoryService.RemoveItem(inventoryid, type);
        }

        [HttpGet("{inventoryid}/{itemid}/{type}")]
        public async Task<dynamic> AddItem(int inventoryid, int itemid, string type)
        {
            //_inventoryService.AddItem(inventoryid, itemid, type);
            return await _mediator.SendGet(sender, inventoryid, itemid, type);
        }
    }
}
