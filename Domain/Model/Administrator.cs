using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Domain.Model
{
    public class Administrator 
    {
        public int AdministratorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$", ErrorMessage = "Password must be at least 8 characters long and include lowercase and uppercase letters, a number, and a special character")]
        public string Password { get; set; }
    }
}
