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
    public class ApartmentService : IApartmentService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public ApartmentService(IUnitofWork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task Add(ApartmentViewDto entity)
        {
            await _unitofWork.Apartment.Add(_mapper.Map<Apartment>(entity));
            await _unitofWork.SaveChangesAsync();
        }

        public void Delete(ApartmentViewDto entity)
        {
            _unitofWork.Apartment.Delete(_mapper.Map<Apartment>(entity));
        }

        public void DeleteRange(List<ApartmentViewDto> entities)
        {
            _unitofWork.Apartment.DeleteRange(_mapper.Map<List<Apartment>>(entities));
        }

        public async Task<List<ApartmentViewDto>> Get(Expression<Func<ApartmentViewDto, bool>> filter)
        {
            var dtoFilter = _mapper.Map<Expression<Func<Apartment, bool>>>(filter);
            var result = await _unitofWork.Apartment.Get(dtoFilter);
            return _mapper.Map<List<ApartmentViewDto>>(result);
        }

        public async Task<List<ApartmentViewDto>> GetAll()
        {
            var result = await _unitofWork.Flat.GetAll();
            return _mapper.Map<List<ApartmentViewDto>>(result);
        }

        public void Update(ApartmentViewDto entity)
        {
            _unitofWork.Apartment.Update(_mapper.Map<Apartment>(entity));
            _unitofWork.SaveChangesAsync();
        }
    }
}
