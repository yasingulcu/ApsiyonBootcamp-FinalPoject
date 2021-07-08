using Apsiyon.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Infrastructure.Context
{
    public class ApsiyonDbContext : IdentityDbContext<User>
    {
        public ApsiyonDbContext(DbContextOptions<ApsiyonDbContext> options) : base(options)
        {
        }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
