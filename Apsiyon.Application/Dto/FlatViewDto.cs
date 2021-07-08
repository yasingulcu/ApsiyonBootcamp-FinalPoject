using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Application.Dto
{
    public class FlatViewDto
    {
        public int Id { get; set; }
        public virtual ICollection<UserViewDto> Users { get; set; }
        public virtual ICollection<SubscriptionViewDto> Subscriptions { get; set; }
    }
}
