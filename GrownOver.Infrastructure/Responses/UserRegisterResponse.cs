using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Infrastructure.Responses
{
    internal class UserRegisterResponse : IdentityResult
    {
        public bool Succeeded { get; set; }
        public string Id { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }

    }
}
