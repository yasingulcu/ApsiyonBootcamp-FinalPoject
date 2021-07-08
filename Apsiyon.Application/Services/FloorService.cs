using Apsiyon.Application.Dto;
using Apsiyon.Application.Interfaces;
using Apsiyon.Infrastructure;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Apsiyon.Domain.Models;

namespace Apsiyon.Application.Services
{
    public class FloorService : IFloorService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public FloorService(IUnitofWork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task Add(FloorViewDto entity)
        {
            await _unitofWork.Floor.Add(_mapper.Map<Floor>(entity));
            await _unitofWork.SaveChangesAsync();
        }

        public void Delete(FloorViewDto entity)
        {
            _unitofWork.Floor.Delete(_mapper.Map<Floor>(entity));
        }

        public void DeleteRange(List<FloorViewDto> entities)
        {
            _unitofWork.Floor.DeleteRange(_mapper.Map<List<Floor>>(entities));
        }

        public async Task<List<FloorViewDto>> Get(Expression<Func<FloorViewDto, bool>> filter)
        {
            var dtoFilter = _mapper.Map<Expression<Func<Floor, bool>>>(filter);
            var result = await _unitofWork.Floor.Get(dtoFilter);
            return _mapper.Map<List<FloorViewDto>>(result);
        }

        public async Task<List<FloorViewDto>> GetAll()
        {
            var result = await _unitofWork.Flat.GetAll();
            return _mapper.Map<List<FloorViewDto>>(result);
        }

        public void Update(FloorViewDto entity)
        {
            _unitofWork.Floor.Update(_mapper.Map<Floor>(entity));
            _unitofWork.SaveChangesAsync();
        }
    }
}
