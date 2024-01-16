using LawSuit.Application.Service.Interface;
using LawSuit.Domain.Dto;
using LawSuit.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Domain.Interface
{
    public interface IDemandRepository : IBaseRepository<Demand>
    {
        Task UpdateDemandByComplaintId(List<DemandsDto> demandsDto);
        Task<DemandsDto> GetDemandsByComplaintId(int complaintId);
    }
}
