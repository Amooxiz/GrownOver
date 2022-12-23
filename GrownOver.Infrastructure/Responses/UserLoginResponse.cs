using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Infrastructure.Responses
{
    internal class UserLoginResponse : SignInResult
    {
        public new bool Succeeded { get; set; }
        public string Id { get; set; }
        public new bool IsNotAllowed { get; set; }
        public new bool RequiresTwoFactor { get; set; }
        public new bool IsLockedOut { get; set; }
    }
}
