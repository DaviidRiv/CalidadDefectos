using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CalidadDefectos.Models
{
    public class Formulario_Model
    {
        [Key]
        [Display(Name = "ID")]
        public int ID_Form { get; set; }
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Semana { get; set; } = string.Empty;
        public string Mes { get; set; } = string.Empty;
        [Display(Name = "Año")]
        public string Anio { get; set; } = string.Empty;
        [Display(Name = "M/Y")]
        public string MesAnio { get; set; } = string.Empty;
        public string Serial { get; set; } = string.Empty;
        public string Job { get; set; } = string.Empty;
        public string Ensamble { get; set; } = string.Empty;
        [Display(Name = "Tamaño")]
        public string Tamanio { get; set; } = string.Empty;
        public string Deteccion { get; set; } = string.Empty;
        [Display(Name = "Pareto Primer Nivel")]
        public string Pareto { get; set; } = string.Empty;
        [Display(Name = "Pareto Segundo Nivel")]
        public string ParetoSN { get; set; } = string.Empty;
        public string Componente { get; set; } = string.Empty;
        public string Elemento { get; set; } = string.Empty;
        public string Remaches { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Estacion { get; set; } = string.Empty;
        public string Comentarios { get; set; } = string.Empty;
    }
}
