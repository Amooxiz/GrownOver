using GrownOver.Application.Interfaces;
using GrownOver.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrownOver.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]/[action]")]
    public class HideOutController : ControllerBase
    {
        private readonly IMediator _mediator;
        private const string sender = "hideOutController";

        public HideOutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{hideoutid}/{itemid}/{type}/{customname}")]
        public dynamic AddItem(int hideoutid, int itemid, string type, string customname)
        {
            return _mediator.SendGet(sender, hideoutid, itemid, type, customname);
        }

        [HttpDelete("{hideoutid}/{itemid}/{type}")]
        public dynamic RemoveItem(int hideoutid, int itemid, string type)
        {
            return _mediator.SendDelete(sender, hideoutid, itemid, type);
        }

        [HttpGet("{hideoutid}")]
        public ItemsVM GetItemsByHideoutId(int hideoutid)
        {
            return _mediator.SendGet(sender, hideoutid);
        }
    }
}
