using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Domain.Model
{
    public class Complaint
    {
        public int ComplaintId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ComplaintTextEn { get; set; }
        public string ComplaintTextAr { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public List<Demand> Demand { get; set; }
        public List<Attachment> Attachment { get; set; }
    }
}
