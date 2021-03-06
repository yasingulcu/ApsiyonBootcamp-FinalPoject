using Apsiyon.Application.Dto;
using Apsiyon.Application.Interfaces;
using Apsiyon.Domain.Models;
using Apsiyon.Infrastructure;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public UserService(IUnitofWork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task Add(UserViewDto entity)
        {
            await _unitofWork.User.Add(_mapper.Map<User>(entity));
            await _unitofWork.SaveChangesAsync();
        }

        public void Delete(UserViewDto entity)
        {
            _unitofWork.User.Delete(_mapper.Map<User>(entity));
            _unitofWork.SaveChangesAsync();
        }

        public void DeleteRange(List<UserViewDto> entities)
        {
            _unitofWork.User.DeleteRange(_mapper.Map<List<User>>(entities));
            _unitofWork.SaveChangesAsync();
        }

        public async Task<List<UserViewDto>> Get(Expression<Func<UserViewDto, bool>> filter)
        {
            var dtoFilter = _mapper.Map<Expression<Func<User, bool>>>(filter);
            var result = await _unitofWork.User.Get(dtoFilter);
            return _mapper.Map<List<UserViewDto>>(result);
        }

        public async Task<List<UserViewDto>> GetAll()
        {
            var result = await _unitofWork.User.GetAll();
            return _mapper.Map<List<UserViewDto>>(result);
        }

        public void Update(UserViewDto entity)
        {
            _unitofWork.User.Update(_mapper.Map<User>(entity));
            _unitofWork.SaveChangesAsync();
        }
    }
}
