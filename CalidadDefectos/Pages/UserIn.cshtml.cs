using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using Newtonsoft.Json;
namespace CalidadDefectos.Pages
{
    [AuthorizeForScopes(ScopeKeySection = "MicrosoftGraph:Scopes")]
    public class UserInModel : PageModel
    {
        private readonly GraphServiceClient _graphServiceClient;
        private readonly ILogger<UserInModel> _logger;

        public UserInModel(ILogger<UserInModel> logger, GraphServiceClient graphServiceClient)
        {
            _logger = logger;
            _graphServiceClient = graphServiceClient;
        }
        public async Task OnGet()
        {
            var user = await _graphServiceClient.Me.Request().GetAsync(); ;
            ViewData["GraphApiResult"] = user.DisplayName; ;
            ViewData["GraphApiResult2"] = user.Mail; ;
        }
    }
}
