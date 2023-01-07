using GrownOver.Application.Interfaces;
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

        [HttpGet("{hideoutid}/{itemid}/{type}")]
        public void AddItem(int hideoutid, int itemid, string type)
        {
            _hideOutService.AddItem(hideoutid, itemid, type);
        }

        [HttpDelete("{hideoutid}/{itemid}/{type}")]
        public dynamic RemoveItem(int hideoutid, int itemid, string type)
        {
            return _hideOutService.RemoveItem(hideoutid, itemid, type);
        }
    }
}
