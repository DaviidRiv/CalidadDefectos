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
    public class I_UserModel : PageModel
    {
        private readonly GraphServiceClient _graphServiceClient;
        private readonly ILogger<I_UserModel> _logger;

        public I_UserModel(ILogger<I_UserModel> logger, GraphServiceClient graphServiceClient)
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
