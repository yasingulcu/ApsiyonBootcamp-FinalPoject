using Apsiyon.Domain.Interfaces;
using Apsiyon.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Infrastructure
{
    public class UnitofWork : IUnitofWork
    {
        public IFlatRepository Flat { get; }
        public IApartmentRepository Apartment { get; }
        public ISubscriptionRepository Subscription { get; }
        public IUserRepository User { get; }
        public IFloorRepository Floor { get; }

        private readonly ApsiyonDbContext _context;
        public UnitofWork(ApsiyonDbContext context, IFlatRepository flatRepository, IFloorRepository floorRepository, IApartmentRepository apartmentRepository,
            ISubscriptionRepository subscriptionRepository, IUserRepository userRepository)
        {
            Flat = flatRepository;
            Floor = floorRepository;
            Apartment = apartmentRepository;
            Subscription = subscriptionRepository;
            User = userRepository;
            _context = context;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
