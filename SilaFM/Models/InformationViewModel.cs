using Pras.Shared.Enums;

namespace Pras.Web.Models
{
    public class InformationViewModel
    {
        public InformationTypes Type { get; set; }
        public string Title { get; set; }
        public virtual string Text { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }
}
