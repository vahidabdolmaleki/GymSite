namespace Core
{
    // ServiceResult.cs
    public class ServiceResult<TDto> : BaseServiceResult
    {
        public TDto? Data { get; set; }
        
    }

}
