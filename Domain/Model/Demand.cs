using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Domain.Model
{
    public class Demand
    {
        public int DemandId { get; set; }
        public int ComplaintId { get; set; }
        public string DemandTextEn { get; set; }
        public string DemandTextAr { get; set; }
    }
}
