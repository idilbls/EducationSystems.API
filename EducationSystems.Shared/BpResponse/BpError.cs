using System;

namespace EducationSystems.Shared.BpResponse
{
    public class BpError : Exception
    {
        public int Code { get; set; }
        public string Messages { get; set; }
        public string Details { get; set; }
        public string ValidationErros { get; set; }
    }
}
