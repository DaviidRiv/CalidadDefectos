using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CalidadDefectos.Data;
using CalidadDefectos.Models;

namespace CalidadDefectos.Pages.Datos
{
    public class CreateModel : PageModel
    {
        private readonly CalidadDefectos.Data.CalidadDefectosContext _context;

        public CreateModel(CalidadDefectos.Data.CalidadDefectosContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Formulario_Model Formulario_Model { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Formulario_Model == null || Formulario_Model == null)
            {
                return Page();
            }

            _context.Formulario_Model.Add(Formulario_Model);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
