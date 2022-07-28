using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CalidadDefectos.Data;
using CalidadDefectos.Models;

namespace CalidadDefectos.Pages.Datos
{
    public class EditModel : PageModel
    {
        private readonly CalidadDefectos.Data.CalidadDefectosContext _context;

        public EditModel(CalidadDefectos.Data.CalidadDefectosContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Formulario_Model Formulario_Model { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Formulario_Model == null)
            {
                return NotFound();
            }

            var formulario_model =  await _context.Formulario_Model.FirstOrDefaultAsync(m => m.ID_Form == id);
            if (formulario_model == null)
            {
                return NotFound();
            }
            Formulario_Model = formulario_model;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Formulario_Model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Formulario_ModelExists(Formulario_Model.ID_Form))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Formulario_ModelExists(int id)
        {
          return (_context.Formulario_Model?.Any(e => e.ID_Form == id)).GetValueOrDefault();
        }
    }
}
