using System.ComponentModel.DataAnnotations;

namespace RegistroTecnico.Models
{

    public class Tecnicos
    {
        [Key]
        public int TecniCold { get; set; }
        public string? Nombre { get; set; }
        public double SueldoHora { get; set; }
    }
}