using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Application.Dto
{
    public class FloorViewDto
    {
        public int Id { get; set; }
        public string FloorName { get; set; }
        public int ApartmentId { get; set; }
        public virtual ApartmentViewDto Apartment { get; set; }
        public virtual ICollection<FlatViewDto> Flats { get; set; }
    }
}
