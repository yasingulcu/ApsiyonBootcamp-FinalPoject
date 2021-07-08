using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Domain.Models
{
   
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdentificationNumber { get; set; }

        public int FlatId { get; set; }
        [ForeignKey("FlatId")]
        public virtual Flat Flat { get; set; }
        
    }
}
