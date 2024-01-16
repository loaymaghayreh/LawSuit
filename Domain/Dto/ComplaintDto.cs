using LawSuit.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Domain.Dto
{
    public class ComplaintDto
    {
        public int ComplaintId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string ComplaintTextEn { get; set; }
        [Required]
        public string ComplaintTextAr { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public List<DemandsDto> Demand { get; set; }
        public Attachment Attachment { get; set; }
    }
}
