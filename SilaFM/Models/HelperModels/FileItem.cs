using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Pras.Web.Models.HelperModels
{
    public class FileItem
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public string EmbedPath
        {
            get
            {
                if (Path == null)
                    return Path;

                var regExp = new Regex(@"^.*(youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=|&v=)([^#&?]*).*");
                var groups = regExp.Match(Path).Groups;
                var id = groups[2].Value;
                return !string.IsNullOrEmpty(id) ? $"//www.youtube.com/embed/{id}" : Path;
            }
        }
    }
}
