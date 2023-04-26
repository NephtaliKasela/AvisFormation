using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ReRouting
    {
        [Key]
        public string OldUrl { get; set; }
        public string NewUrl { get; set; }
    }
}
