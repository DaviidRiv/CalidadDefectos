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
using CalidadDefectos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace CalidadDefectos.Pages
{
    [AuthorizeForScopes(ScopeKeySection = "MicrosoftGraph:Scopes")]
    public class T_DeteccionModel : PageModel
    {
        private readonly GraphServiceClient _graphServiceClient;
        public readonly CalidadDefectos.Data.CalidadDefectosContext _context;
        public T_DeteccionModel(CalidadDefectos.Data.CalidadDefectosContext context, GraphServiceClient graphServiceClient)
        {
            _context = context;
            _graphServiceClient = graphServiceClient; ;
        }
        public IList<EnrollmentDeteccionGroups> Formulario_Model { get; set; } = default!;
        public IList<Formulario_Model> Formulario_Model2 { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Detecciones { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? ListaDetecciones { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Formulario_Model2
                                            orderby m.Mes
                                            select m.Mes;

            var datos = from m in _context.Formulario_Model2
                        select m;
             
            IQueryable<EnrollmentDeteccionGroups> data = from d in _context.Formulario_Model
                                                         group d by d.Deteccion
                                                         into dateGroup
                                                         select new EnrollmentDeteccionGroups()
                                                         {
                                                            Deteccion = dateGroup.Key, 
                                                            DetCount = dateGroup.Count()
                                                         };
            //IQueryable<EnrollmentDeteccionGroups> data2 = from d in _context.Formulario_Model2
            //                                              group d by d.Mes
            //                                              into dateGroup
            //                                              select new EnrollmentDeteccionGroups()
            //                                              {
            //                                                  Meses = dateGroup.Key
            //                                              };
            
            if (!string.IsNullOrEmpty(SearchString))
            {
                datos = datos.Where(s => s.ReleaseDate.ToString().Contains(SearchString));
            }
            Formulario_Model = await data.ToListAsync();
            Formulario_Model2 = await datos.ToListAsync();
        }
       

    }
}
