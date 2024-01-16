using LawSuit.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Application.Service.Interface
{
    public interface IComplaintAppService
    {
        Task CreateComplaint(ComplaintDto complaintDto);
        Task UpdateComplaint(ComplaintDto complaintDto);
        Task<ComplaintDto> GetComplaintById(int id);
        Task<List<ComplaintDto>> GetAllComplaints();
        Task UpdateComplaintStatus(ComplaintStatusDto complaintStatusDto);
    }
}
