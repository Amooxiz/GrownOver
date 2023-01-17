using GrownOver.Application.Interfaces;
using GrownOver.Contracts.RequestsModels;
using GrownOver.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Contracts
{
    public class Mediator : IMediator
    {
        private readonly IBaseItemService _itemService;
        private readonly IInventoryService _inventoryService;
        private readonly IUserService _userService;
        private readonly IHideOutService _hideOutService;

        public Mediator(IBaseItemService itemService, IInventoryService inventoryService, IUserService userService, IHideOutService hideOutService)
        {
            _itemService = itemService;
            _inventoryService = inventoryService;
            _userService = userService;
            _hideOutService = hideOutService;
        }

        public dynamic SendPost(string sender, params dynamic[] values)
        {
            switch (sender)
            {
                case "userController":
                    if (values.Length == 1)
                    {
                        if (values[0] is RegisterUserRequest)
                        {
                            RegisterUserRequest request = (RegisterUserRequest)values[0];
                            return _userService.RegisterUser(request.UserName, request.Email, request.Password);
                        }
                        else if (values[0] is LoginUserRequest)
                        {
                            LoginUserRequest request = (LoginUserRequest)values[0];
                            return _userService.SignIn(request.UserName, request.Password);
                        }
                        else
                        {
                            throw new Exception("Wrong params type");
                        }
                    }
                    else
                    {
                        throw new Exception("Wrong params count");
                    }
                    break;
                case "baseItemController":
                    if (values.Length == 1)
                    {
                        if (values[0] is PushItemRequest)
                        {
                            PushItemRequest request = (PushItemRequest)values[0];
                            return _itemService.AddItem(request.Name, request.Price, request.Description, request.Weight, request.Loot, request.Value, request.Type);
                        }
                        else
                        {
                            throw new Exception("Wrong params type");
                        }
                    }
                    else
                    {
                        throw new Exception("Wrong params count");
                    }
                default:
                    throw new Exception("Wrong sender");
                    
            }
        }

        public dynamic SendGet(string sender, params dynamic[] values)
        {
            switch (sender)
            {
                case "baseItemController":
                    if (values.Length == 0)
                    {
                        return _itemService.GetAllItems();
                    }
                    else if (values.Length == 2)
                    {
                        if (values[0] is int && values[1] is string)
                        {
                            return _itemService.GetItem((int)values[0], (string)values[1]);
                        }
                        else
                        {
                            throw new Exception("Wrong params type");
                        }
                    }
                    else
                    {
                        throw new Exception("Wrong params count");
                    }
                case "hideOutController":
                    if (values.Length == 1)
                    {
                        if (values[0] is int)
                        {
                            return _hideOutService.GetItemsByHideoutId((int)values[0]);
                        }
                        else
                        {
                            throw new Exception("Wrong params type");
                        }
                    }
                    else if (values.Length == 4)
                    {
                        if (values[0] is int && values[1] is int && values[2] is string && values[3] is string)
                        {
                            return _hideOutService.AddItem((int)values[0], (int)values[1], (string)values[2], (string)values[2]);
                        }
                        else
                        {
                            throw new Exception("Wrong params type");
                        }
                    }
                    else
                    {
                        throw new Exception("Wrong params count");
                    }
                case "inventoryController":
                    if (values.Length == 1)
                    {
                        if (values[0] is int)
                        {
                            return _inventoryService.GetInventoryById((int)values[0]);
                        }
                        else
                        {
                            throw new Exception("Wrong params type");
                        }
                    }
                    else if(values.Length == 3)
                    {
                        if (values[0] is int && values[1] is int && values[2] is string)
                        {
                            return _inventoryService.AddItem((int)values[0], (int)values[1], (string)values[2]);
                        }
                        else
                        {
                            throw new Exception("Wrong params type");
                        }
                    }
                    else
                    {
                        throw new Exception("Wrong params count");
                    }
                case "userController":
                    if (values.Length == 1)
                    {
                        if (values[0] is string)
                        {
                            return _userService.GetUser((string)values[0]);
                        }
                        else
                        {
                            throw new Exception("Wrong params type");
                        }
                    }
                    else
                    {
                        throw new Exception("Wrong params count");
                    }
                default:
                    throw new Exception("Wrong sender");

            }
        }

        public dynamic SendPatch(string sender, params dynamic[] values)
        {
            switch (sender)
            {
                case "userController":
                    if (values.Length == 2)
                    {
                        if (values[0] is JsonPatchDocument<User> && values[1] is string)
                        {
                            return _userService.UpdateUser((JsonPatchDocument<User>)values[0], (string)values[1]);
                        }
                        else
                        {
                            throw new Exception("Wrong params type");
                        }
                    }
                    else
                    {
                        throw new Exception("Wrong params count");
                    }
                default:
                    throw new Exception("Wrong sender");

            }
        }

        public dynamic SendDelete(string sender, params dynamic[] values)
        {
            switch (sender)
            {
                case "hideOutController":
                    if (values.Length == 3)
                    {
                        if (values[0] is int && values[1] is int && values[2] is string)
                        {
                            return _hideOutService.RemoveItem((int)values[0], (int)values[1], (string)values[2]);
                        }
                        else
                        {
                            throw new Exception("Wrong params type");
                        }
                    }
                    else
                    {
                        throw new Exception("Wrong params count");
                    }
                case "inventoryController":
                    if (values.Length == 2)
                    {
                        if (values[0] is int && values[1] is string)
                        {
                            return _inventoryService.RemoveItem((int)values[0], (string)values[1]);
                        }
                        else
                        {
                            throw new Exception("Wrong params type");
                        }
                    }
                    else
                    {
                        throw new Exception("Wrong params count");
                    }
                default:
                    throw new Exception("Wrong sender");

            }
        }
    }
}
