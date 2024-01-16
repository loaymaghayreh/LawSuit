using LawSuit.Application.Service.Interface;
using LawSuit.Domain.Dto;
using LawSuit.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LawSuit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IComplaintAppService _complaintAppService;
        public AdminController(IComplaintAppService complaintAppService)
        {
            _complaintAppService = complaintAppService;
        }
        [HttpGet("GetAllCompliants")]
        public async Task<List<ComplaintDto>> GetAllCompliants()
        {
            return await _complaintAppService.GetAllComplaints();
        }
        [HttpGet("GetComplaintById/{id}")]
        public async Task<ComplaintDto> GetComplaintById(int id)
        {
            return await _complaintAppService.GetComplaintById(id);
        }
        [HttpPut("UpdateComplaintStatus")]
        public async Task UpdateComplaintStatus([FromQuery] ComplaintStatusDto complaintStatusDto)
        {
            await _complaintAppService.UpdateComplaintStatus(complaintStatusDto);
        }
    }
}
