using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Domain.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int FloorId { get; set; }
        [ForeignKey("FloorId")]
        public virtual Floor Floor { get; set; }
        public virtual ICollection<Subscription> Subscription { get; set; }

    }
}
