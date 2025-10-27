namespace Core
{
    public class ServiceResults<TDto> : BaseServiceResult where TDto : class, new()
    {
        public ServiceResults()
        {
            Data = new List<TDto>();
        }
        public IEnumerable<TDto> Data { get; set; }
    }

}
