namespace EducationSystems.Shared.BpResponse
{
    public class BpJson<T>
    {
        public T Result { get; set; }
        public BpError Error { get; set; }
        public bool Success { get; set; }
        public string TargetUrl { get; set; }
        public bool UnauthorizedRequest { get; set; }
        public bool IsAbp { get; set; }
    }
}
