using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Domain.Dto
{
    public class AdministratorDto
    {
        public int AdministratorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
