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
        private readonly IMediator _mediator;
        private const string sender = "baseItemController";

        public BaseItemController(IBaseItemService baseItemService, IMediator mediator)
        {
            _baseItemService = baseItemService;
            _mediator = mediator;
        }

        [HttpGet]
        public ItemsVM GetAllItems()
        {
            //return _baseItemService.GetAllItems();
            return _mediator.SendGet(sender);
        }

        //[HttpPost]
        //public void AddWeapon([FromBody] PushWeaponRequest pushWeaponRequest)
        //{
        //    _baseItemService.AddWeapon(pushWeaponRequest.Name, pushWeaponRequest.Price, pushWeaponRequest.Description, pushWeaponRequest.Weight,
        //        pushWeaponRequest.Damage, pushWeaponRequest.Loot);
        //}

        //[HttpPost]
        //public void AddArmor([FromBody] PushArmorRequest pushArmorRequest)
        //{
        //    _baseItemService.AddArmor(pushArmorRequest.Name, pushArmorRequest.Price, pushArmorRequest.Description, pushArmorRequest.Weight, pushArmorRequest.Resistance, pushArmorRequest.Loot);
        //}

        //[HttpPost]
        //public void AddMaterial([FromBody] PushMaterialRequest pushMaterialRequest)
        //{
        //    _baseItemService.AddMaterial(pushMaterialRequest.Name, pushMaterialRequest.Price, pushMaterialRequest.Description, pushMaterialRequest.Weight,
        //        pushMaterialRequest.Quality, pushMaterialRequest.Loot);
        //}

        //[HttpPost]
        //public void AddFood([FromBody] PushFoodRequest pushFoodRequest)
        //{
        //    _baseItemService.AddFood(pushFoodRequest.Name, pushFoodRequest.Price, pushFoodRequest.Description, pushFoodRequest.Weight,
        //        pushFoodRequest.Energy, pushFoodRequest.Loot);
        //}

        [HttpPost]
        public dynamic AddItem([FromBody] PushItemRequest pushItemRequest)
        {
            //_baseItemService.AddItem(pushItemRequest.Name, pushItemRequest.Price, pushItemRequest.Description,
            //    pushItemRequest.Weight, pushItemRequest.Loot, pushItemRequest.Value, pushItemRequest.Type);

            return _mediator.SendPost(sender, pushItemRequest);
        }

        [HttpGet("{id}/{type}")]
        public dynamic GetItem(int id, string type)
        {
            //return _baseItemService.GetItem(id, type);
            return _mediator.SendGet(sender, id, type);
        }
    }
}
