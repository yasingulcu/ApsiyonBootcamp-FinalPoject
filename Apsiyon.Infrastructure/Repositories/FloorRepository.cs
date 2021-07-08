using Apsiyon.Domain.Interfaces;
using Apsiyon.Domain.Models;
using Apsiyon.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Infrastructure.Repositories
{
    public class FloorRepository : Repository<Floor>, IFloorRepository
    {
        public FloorRepository(ApsiyonDbContext context) : base(context)
        {

        }
    }
}
