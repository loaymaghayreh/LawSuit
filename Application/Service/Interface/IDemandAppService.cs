using LawSuit.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Application.Service.Interface
{
    public interface IDemandAppService
    {
        Task CreateDemand(List<DemandsDto> demandsDto);
    }
}
