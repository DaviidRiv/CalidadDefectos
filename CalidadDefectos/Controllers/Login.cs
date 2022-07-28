using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

using Microsoft.AspNetCore.Mvc;
using CalidadDefectos.Models;
using System.Diagnostics;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Newtonsoft.Json;

namespace CalidadDefectos.Controllers
{
    [Authorize]
    public class Login : Controller
    {
        private readonly ILogger<Login> _logger;
        private readonly GraphServiceClient _graphServiceClient;

        public Login()
        {

        }
        
    }
}
