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
    public class DemandAppService : IDemandAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DemandAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateDemand(List<DemandsDto> demandsDto)
        {
            var newDemands = _mapper.Map<List<Demand>>(demandsDto);     

            await _unitOfWork.Demand.AddRangeAsync(newDemands);

            await _unitOfWork.CompleteAsync();
        }
      
    }
}
