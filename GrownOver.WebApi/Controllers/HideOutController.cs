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
        private readonly IHideOutService _hideOutService;

        public HideOutController(IHideOutService hideOutService)
        {
            _hideOutService = hideOutService;
        }

        [HttpGet("{hideoutid}/{itemid}/{type}/{customname}")]
        public dynamic AddItem(int hideoutid, int itemid, string type, string customname)
        {
            return _hideOutService.AddItem(hideoutid, itemid, type, customname);
        }

        [HttpDelete("{hideoutid}/{itemid}/{type}")]
        public dynamic RemoveItem(int hideoutid, int itemid, string type)
        {
            return _hideOutService.RemoveItem(hideoutid, itemid, type);
        }

        [HttpGet("{hideoutid}")]
        public ItemsVM GetItemsByHideoutId(int hideoutid)
        {
            return _hideOutService.GetItemsByHideoutId(hideoutid);
        }
    }
}
