using AutoMapper;
using LawSuit.Application.Service.Interface;
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
    public class UserAppSerrvice : IUserAppSerrvice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserAppSerrvice(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateUserAsync(UserDto user)
        {
            var newUser = _mapper.Map<User>(user);

            await _unitOfWork.User.CreateAsync(newUser);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<UserDto> GetUserDetailsByIdAsync(int userId)
        {
            UserDto userDto = new UserDto();

            var user = (await _unitOfWork.User.GetByIdAsync(userId));

            return _mapper.Map(user, userDto);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = await _unitOfWork.User.GetByIdAsync(userDto.UserId);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            _mapper.Map(userDto, user);

            await _unitOfWork.User.UpdateAsync(user);

            await _unitOfWork.CompleteAsync();
        }
    }
}
