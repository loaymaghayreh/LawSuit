using AutoMapper;
using LawSuit.Domain.Dto;
using LawSuit.Domain.Interface;
using LawSuit.Domain.Model;
using LawSuit.Infrastructure.LawSuitDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Infrastructure.Repository
{
    public class DemandRepository : BaseRepository<Demand> , IDemandRepository
    {
        private readonly IMapper _mapper;
        public DemandRepository(AppDbContext context,IMapper mapper) :base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task UpdateDemandByComplaintId(List<DemandsDto> demandsDto)
        {

            if (demandsDto == null || !demandsDto.Any())
            {
                return;
            }

            var complaintId = demandsDto.First().ComplaintId;
            var existingDemands = await _context.Set<Demand>()
                                        .Where(d => d.ComplaintId == complaintId)
                                        .ToListAsync();

            var updatedDemands = _mapper.Map<List<Demand>>(demandsDto);

            foreach (var updatedDemand in updatedDemands)
            {
                var existingDemand = existingDemands.FirstOrDefault(d => d.DemandId == updatedDemand.DemandId);
                if (existingDemand != null)
                {
                    _context.Entry(existingDemand).CurrentValues.SetValues(updatedDemand);
                }
            }

            await _context.SaveChangesAsync();
        }
        public async Task<DemandsDto> GetDemandsByComplaintId(int complaintId)
        {
            IQueryable<Demand> query = _context.Set<Demand>().Where(d => d.ComplaintId == complaintId);

            var demand = await query.FirstOrDefaultAsync();

            return _mapper.Map<DemandsDto>(demand);           
        }
    }
}
