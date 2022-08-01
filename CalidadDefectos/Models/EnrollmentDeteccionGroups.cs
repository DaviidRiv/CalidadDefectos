using System;
using System.ComponentModel.DataAnnotations;

namespace CalidadDefectos.Models
{
    public class EnrollmentDeteccionGroups
    {
        public string Deteccion { get; set; } = string.Empty;
        public int DetCount { get; set; }

        public string Jobs { get; set; } = string.Empty;
        public int JobCount { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        public string Paretos { get; set; } = string.Empty;
        public int ParetCount { get; set; }
        public string Meses { get; set; } = string.Empty;
    }
}
