using Apsiyon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Infrastructure
{
    public interface IUnitofWork
    {
        IFlatRepository Flat { get; }
        
        IFloorRepository Floor { get; }
        IApartmentRepository Apartment { get; }
        ISubscriptionRepository Subscription { get; }
        IUserRepository User { get; }

        Task<int> SaveChangesAsync();
    }
}
