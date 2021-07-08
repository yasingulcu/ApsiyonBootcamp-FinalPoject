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
    public class FlatService : IFlatService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public FlatService(IUnitofWork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }

        public async Task Add(FlatViewDto entity)
        {
            await _unitofWork.Flat.Add(_mapper.Map<Flat>(entity));
            await _unitofWork.SaveChangesAsync();
        }

        public void Delete(FlatViewDto entity)
        {
            _unitofWork.Flat.Delete(_mapper.Map<Flat>(entity));
        }

        public void DeleteRange(List<FlatViewDto> entities)
        {
            _unitofWork.Flat.DeleteRange(_mapper.Map<List<Flat>>(entities));
        }

        public async Task<List<FlatViewDto>> Get(Expression<Func<FlatViewDto, bool>> filter)
        {
            var dtoFilter = _mapper.Map<Expression<Func<Flat, bool>>>(filter);
            var result = await _unitofWork.Flat.Get(dtoFilter);
            return _mapper.Map<List<FlatViewDto>>(result);
        }

        public async Task<List<FlatViewDto>> GetAll()
        {
            var result = await _unitofWork.Flat.GetAll();
            return _mapper.Map<List<FlatViewDto>>(result);
        }

        public void Update(FlatViewDto entity)
        {
            _unitofWork.Flat.Update(_mapper.Map<Flat>(entity));
            _unitofWork.SaveChangesAsync();
        }
    }
}
