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
        public async Task<dynamic> AddItem(int hideoutid, int itemid, string type, string customname)
        {
            return await _mediator.SendGet(sender, hideoutid, itemid, type, customname);
        }

        [HttpDelete("{hideoutid}/{itemid}/{type}")]
        public async Task<dynamic> RemoveItem(int hideoutid, int itemid, string type)
        {
            return await _mediator.SendDelete(sender, hideoutid, itemid, type);
        }

        [HttpGet("{hideoutid}")]
        public async Task<ItemsVM> GetItemsByHideoutId(int hideoutid)
        {
            return await _mediator.SendGet(sender, hideoutid);
        }
    }
}
