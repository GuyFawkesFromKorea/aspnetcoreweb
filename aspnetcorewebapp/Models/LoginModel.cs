using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorewebapp.Models
{

    public class LoginModel
    {
        [BindRequired]
        public string Id { get; set; }

        [BindRequired]
        public string Pw { get; set; }

        [BindRequired]
        public string ReturnUrl { get; set; }
    }
}
