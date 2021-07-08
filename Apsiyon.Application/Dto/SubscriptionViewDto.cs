using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Application.Dto
{
    public class SubscriptionViewDto
    {
        public int Id { get; set; }
        public int FlatId { get; set; }
        public virtual FlatViewDto Flat { get; set; }
        public float Amount { get; set; }
        public DateTime DateTime { get; set; }
        public bool Status { get; set; }
    }
}
