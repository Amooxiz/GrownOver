using GrownOver.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Infrastructure.Services
{
    public class HideOutService : IHideOutService
    {
        private readonly IHideOutRepository _hideOutRepository;

        public HideOutService(IHideOutRepository hideOutRepository)
        {
            _hideOutRepository = hideOutRepository;
        }

        public void AddItem(int hideOutId, int itemId, string type)
        {
            _hideOutRepository.AddItem(hideOutId, itemId, type);
        }

        public dynamic RemoveItem(int hideoutId, int itemId, string type)
        {
            return _hideOutRepository.RemoveItem(hideoutId, itemId, type);
        }
    }
}
