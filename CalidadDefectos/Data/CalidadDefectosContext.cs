using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CalidadDefectos.Models;


namespace CalidadDefectos.Data
{
    public class CalidadDefectosContext : DbContext
    {
        public CalidadDefectosContext (DbContextOptions<CalidadDefectosContext> options)
            : base(options)
        {
        }

        public DbSet<CalidadDefectos.Models.Formulario_Model> Formulario_Model { get; set; } = default!;
        public DbSet<CalidadDefectos.Models.Formulario_Model> Formulario_Model2 { get; set; } = default!;
    }
}
