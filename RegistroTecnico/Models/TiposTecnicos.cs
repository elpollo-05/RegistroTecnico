using System.ComponentModel.DataAnnotations;

namespace RegistroTecnico.Models
{

    public class TiposTecnicos
    {
        [Key]
        public int tecniCold { get; set; }
        public string? descricion { get; set; }
    }
}