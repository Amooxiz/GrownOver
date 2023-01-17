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
        private readonly IMediator _mediator;
        private const string sender = "inventoryController";

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<InventoryVM> GetInventory([FromRoute] int id)
        {
            return await _mediator.SendGet(sender, id);
        }

        [HttpDelete("{inventoryid}/{type}")]
        public async Task<dynamic> RemoveItem(int inventoryid, string type)
        {
            return await _mediator.SendDelete(sender, inventoryid, type);
        }

        [HttpGet("{inventoryid}/{itemid}/{type}")]
        public async Task<dynamic> AddItem(int inventoryid, int itemid, string type)
        {
            return await _mediator.SendGet(sender, inventoryid, itemid, type);
        }
    }
}
