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
        public InventoryVM GetInventory([FromRoute] int id)
        {
            return _mediator.SendGet(sender, id);
        }

        [HttpDelete("{inventoryid}/{type}")]
        public dynamic RemoveItem(int inventoryid, string type)
        {
            return _mediator.SendDelete(sender, inventoryid, type);
        }

        [HttpGet("{inventoryid}/{itemid}/{type}")]
        public dynamic AddItem(int inventoryid, int itemid, string type)
        {
            return _mediator.SendGet(sender, inventoryid, itemid, type);
        }
    }
}
