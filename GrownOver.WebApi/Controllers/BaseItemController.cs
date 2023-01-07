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
        private readonly IBaseItemService _baseItemService;

        public BaseItemController(IBaseItemService baseItemService)
        {
            _baseItemService = baseItemService;
        }

        [HttpGet]
        public ItemsVM GetAllItems()
        {
            return _baseItemService.GetAllItems();
        }

        [HttpPost]
        public void AddWeapon([FromBody] PushWeaponRequest pushWeaponRequest)
        {
            _baseItemService.AddWeapon(pushWeaponRequest);
        }

        [HttpPost]
        public void AddArmor([FromBody] PushArmorRequest pushArmorRequest)
        {
            _baseItemService.AddArmor(pushArmorRequest);
        }

        [HttpPost]
        public void AddMaterial([FromBody] PushMaterialRequest pushMaterialRequest)
        {
            _baseItemService.AddMaterial(pushMaterialRequest);
        }

        [HttpPost]
        public void AddFood([FromBody] PushFoodRequest pushFoodRequest)
        {
            _baseItemService.AddFood(pushFoodRequest);
        }

        [HttpGet("{id}/{type}")]
        public dynamic GetItem(int id, string type)
        {
            return _baseItemService.GetItem(id, type);
        }
    }
}
