using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Domain.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }
        public virtual ICollection<Flat> Flats { get; set; }
    }
}
