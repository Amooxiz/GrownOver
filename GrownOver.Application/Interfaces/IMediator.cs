using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.Interfaces
{
    public interface IMediator
    {
        public dynamic SendPost(string sender, params dynamic[] values);
        public dynamic SendGet(string sender, params dynamic[] values);
        public dynamic SendPatch(string sender, params dynamic[] values);
    }
}
