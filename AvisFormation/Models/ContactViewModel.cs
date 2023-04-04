using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace AvisFormation.Models
{
    public class ContactViewModel
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(20)]
        public string Message { get; set; }
    }
}
