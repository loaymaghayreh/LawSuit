using LawSuit.Domain.Dto;
using LawSuit.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Application.Service.Interface
{
    public interface IUserAppSerrvice
    {
        Task CreateUserAsync(UserDto user);
        Task UpdateUserAsync(UserDto user);
        Task<UserDto> GetUserDetailsByIdAsync(int userId);
    }
}
