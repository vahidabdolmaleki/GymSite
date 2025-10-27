namespace Core
{
    // ServiceResults.cs
    public class ServiceResults<TDto> : BaseServiceResult
    {
        public IEnumerable<TDto>? Data { get; set; }
    }



}
