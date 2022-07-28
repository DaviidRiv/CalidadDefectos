using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CalidadDefectos.Data;
using CalidadDefectos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Web;
using System.Net;
using Microsoft.Graph;

namespace CalidadDefectos.Pages.Datos
{
    [AuthorizeForScopes(ScopeKeySection = "MicrosoftGraph:Scopes")]
    public class IndexModel : PageModel
    {
        //private readonly GraphServiceClient _graphServiceClient;
        private readonly CalidadDefectos.Data.CalidadDefectosContext _context;

        public IndexModel(CalidadDefectos.Data.CalidadDefectosContext context)
        {
            _context = context;
        }

        public IList<Formulario_Model> Formulario_Model { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public String? SearchString2 { get; set; }
        public SelectList? Estaciones { get; set; } 
        [BindProperty(SupportsGet = true)]
        public string? ListaEstaciones { get; set; } 

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of ESTACION.
            IQueryable<string> genreQuery = from m in _context.Formulario_Model
                                            orderby m.Estacion
                                            select m.Estacion;
            var datos = from m in _context.Formulario_Model
                        select m;

            if (_context.Formulario_Model != null)
            {
                Formulario_Model = await _context.Formulario_Model.ToListAsync();
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                datos = datos.Where(s => s.Serial.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SearchString2))
            {
                datos = datos.Where(s => s.ReleaseDate.ToString().Contains(SearchString2));
            }
            if (!string.IsNullOrEmpty(ListaEstaciones))
            {
                datos = datos.Where(x => x.Estacion == ListaEstaciones);
            }
            Estaciones = new SelectList(await genreQuery.Distinct().ToListAsync());
            Formulario_Model = await datos.ToListAsync();
        }
    }
}
