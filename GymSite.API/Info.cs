using Microsoft.OpenApi.Models;

namespace GymSite.API
{
    internal class Info : OpenApiInfo
    {
        public string Version { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}