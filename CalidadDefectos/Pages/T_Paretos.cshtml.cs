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
    public class T_ParetosModel : PageModel
    {
        private readonly GraphServiceClient _graphServiceClient;
        private readonly CalidadDefectos.Data.CalidadDefectosContext _context;
        public T_ParetosModel(CalidadDefectos.Data.CalidadDefectosContext context, GraphServiceClient graphServiceClient)
        {
            _context = context;
            _graphServiceClient = graphServiceClient; ;
        }
        public IList<EnrollmentDeteccionGroups> Formulario_Model { get; set; } = default!;
        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDeteccionGroups> data = from d in _context.Formulario_Model
                                                         group d by d.Pareto
                                                         into dateGroup
                                                         select new EnrollmentDeteccionGroups()
                                                         {
                                                             Paretos = dateGroup.Key,
                                                             ParetCount = dateGroup.Count()
                                                         };

            Formulario_Model = await data.ToListAsync();
        }
    }
}
