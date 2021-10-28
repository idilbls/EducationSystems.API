namespace EducationSystems.Shared.BpResponse
{
    public class BpPageResult<T>
    {
        public int TotalCount { get; set; }
        public T Items { get; set; }
    }
}
