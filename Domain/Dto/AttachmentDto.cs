using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Domain.Dto
{
    public class AttachmentDto
    {
        public int AttachmentId { get; set; }
        public int ComplaintId { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
    }
}
