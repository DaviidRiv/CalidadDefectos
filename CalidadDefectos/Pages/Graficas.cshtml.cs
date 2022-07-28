using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using Newtonsoft.Json;
using CalidadDefectos.Models;
using System.Data;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CalidadDefectos.Pages
{
    [AuthorizeForScopes(ScopeKeySection = "MicrosoftGraph:Scopes")]
    public class GraficasModel : PageModel
    {
        private readonly GraphServiceClient _graphServiceClient;
        private readonly CalidadDefectos.Data.CalidadDefectosContext _context;
        public GraficasModel(CalidadDefectos.Data.CalidadDefectosContext context, GraphServiceClient graphServiceClient)
        {
            _context = context;
            _graphServiceClient = graphServiceClient; ;
        }
        public IList<EnrollmentDeteccionGroups> Formulario_Model { get; set; } = default!;
        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDeteccionGroups> data = from a in _context.Formulario_Model
                                                         group a by a.Job
                                                         into dateGroup
                                                         select new EnrollmentDeteccionGroups()
                                                         {
                                                             Jobs = dateGroup.Key,
                                                             JobCount = dateGroup.Count()
                                                         };
            Formulario_Model = await data.ToListAsync();

        }
    }
}
