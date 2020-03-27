using Pras.Shared.Enums;

namespace Pras.Web.Models
{
    public class AudioViewModel
    {
        public AudioTypes Type { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Path { get; set; }
        public bool IsNovelty { get; set; }
    }
}
