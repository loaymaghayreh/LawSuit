using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Domain.Model
{
    public class Attachment
    {
        public int AttachmentId { get; set; }
        public int ComplaintId { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
    }
}
