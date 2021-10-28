using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystems.Shared.BpResponse
{
    public class BpPageResult<T>
    {
        public int TotalCount { get; set; }
        public T Items { get; set; }
    }
}
