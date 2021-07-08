using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Application.Dto
{
    public class ApartmentViewDto
    {
        public int Id { get; set; }
        public string ApartmentName { get; set; }
        public virtual ICollection<FloorViewDto> Floors { get; set; }
    }
}
