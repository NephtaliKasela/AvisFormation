using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Avis
    {
        public int Id { get; set; }
        [StringLength(500)]
        public string Commentaire { get; set; }
        [Required]
        public double Note { get; set; }
        [Required]
        public string NomUtilisateur { get; set; }
        public int FormationId { get; set; }
        public Formation Formation { get; set; }
    }
}
