using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;

namespace AvisFormation.Models
{
    public class LaisserUnAvisViewModel
    {
        [StringLength(5, ErrorMessage ="The length must be less than six")]
        public string Commentaire { get; set; }
        [Required]
        public string Nom{ get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        public string IdFormation { get; set; }
        public string NomFormation { get; set; }
    }
}
