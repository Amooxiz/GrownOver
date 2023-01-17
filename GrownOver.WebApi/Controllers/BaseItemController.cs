using GrownOver.Application.Interfaces;
using GrownOver.Application.ViewModels;
using GrownOver.Contracts.RequestsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrownOver.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]/[action]")]
    public class BaseItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        private const string sender = "baseItemController";

        public BaseItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ItemsVM GetAllItems()
        {
            return _mediator.SendGet(sender);
        }

        [HttpPost]
        public dynamic AddItem([FromBody] PushItemRequest pushItemRequest)
        {
            return _mediator.SendPost(sender, pushItemRequest);
        }

        [HttpGet("{id}/{type}")]
        public dynamic GetItem(int id, string type)
        {
            return _mediator.SendGet(sender, id, type);
        }
    }
}
