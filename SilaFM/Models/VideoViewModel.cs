using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pras.Shared.Enums;

namespace Pras.Web.Models
{
    public class VideoViewModel
    {
        public VideoTypes Type { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Path { get; set; }
    }
}
