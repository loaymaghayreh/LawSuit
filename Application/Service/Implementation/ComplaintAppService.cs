using AutoMapper;
using LawSuit.Application.Service.Interface;
using LawSuit.Domain;
using LawSuit.Domain.Dto;
using LawSuit.Domain.Interface;
using LawSuit.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Application.Service.Implementation
{
    public class ComplaintAppService : IComplaintAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDemandRepository _demandRepository;  
        public ComplaintAppService(IUnitOfWork unitOfWork, IMapper mapper, IDemandRepository demandRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _demandRepository = demandRepository;
        }

        public async Task CreateComplaint(ComplaintDto complaintDto)
        {
            var newComplaint = _mapper.Map<Complaint>(complaintDto);

            newComplaint.StatusId = (int)EnumComplaint.Pinding;
            newComplaint.Status = EnumComplaint.Pinding.ToString();

            await _unitOfWork.Complaint.CreateAsync(newComplaint);

            await _unitOfWork.Demand.AddRangeAsync(newComplaint.Demand); 

            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateComplaint(ComplaintDto complaintDto)
        {
            var complaint = await _unitOfWork.Complaint.GetByIdAsync(complaintDto.ComplaintId);

            if (complaint == null)
            {
                throw new KeyNotFoundException("Complaint not found.");
            }

            var newDemands = _mapper.Map<Complaint>(complaintDto);

            await _unitOfWork.Complaint.UpdateAsync(newDemands);

            await _demandRepository.UpdateDemandByComplaintId(complaintDto.Demand);

            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateComplaintStatus(ComplaintStatusDto complaintStatusDto)
        {
            var complaint = await _unitOfWork.Complaint.GetByIdAsync(complaintStatusDto.ComplaintId);

            if (complaint == null)
            {
                throw new KeyNotFoundException("Complaint not found.");
            }

            if (complaintStatusDto.StatusId == (int)EnumComplaint.Approve)
            {
                complaint.StatusId = complaintStatusDto.StatusId;
                complaint.Status = EnumComplaint.Approve.ToString();
            }
            else if (complaintStatusDto.StatusId == (int)EnumComplaint.Reject)
            {
                complaint.StatusId = complaintStatusDto.StatusId;
                complaint.Status = EnumComplaint.Reject.ToString();
            }

            await _unitOfWork.Complaint.UpdateAsync(complaint);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<ComplaintDto>> GetAllComplaints()
        {
            List<ComplaintDto> complaintDto = new List<ComplaintDto>();

            var complaints = (await _unitOfWork.Complaint.GetAllAsync()).ToList();

            return _mapper.Map(complaints, complaintDto);
        }

        public async Task<ComplaintDto> GetComplaintById(int id)
        {
            ComplaintDto complaintDto = new ComplaintDto();

            var complaint = (await _unitOfWork.Complaint.GetByIdAsync(id));

            return _mapper.Map(complaint, complaintDto);
        }


    }
}
