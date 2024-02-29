using Dating.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating.Data.Services
{
    public class SimpleAuthService
    {

        public bool IsLoggedIn { get; set; } = false;
        public AccountProfile CurrentUser { get; set; }
    }
}
