using System.ComponentModel.DataAnnotations;

namespace RegistroTecnico.Models;

    public class Tecnicos
    {
        [Key]
        public int TecniCold { get; set; }

        [Required]
        public string? Nombre { get; set; }
        [Required]
        public double SueldoHora { get; set; }
}
