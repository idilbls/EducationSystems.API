using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystems.Shared.DTOs
{
    public class LocalAddressRequest
    {
        public int UserId { get; set; }
        public string LocalAddress { get; set; }
    }
}
