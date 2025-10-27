namespace Core
{
    public class ServiceResult<TDto> : BaseServiceResult where TDto : class, new()
    {
        public ServiceResult()
        {
            Data = new TDto();
        }
        public TDto Data { get; set; }
    }

}
