using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pras.Shared.Enums;
using Pras.Web.Models.HelperModels;

namespace Pras.Web.Models
{
    public class FullSpeakerViewModel : SpeakerViewModel
    {
        public string Nationality { get; set; }
        public VoiceAge VoiceAge { get; set; }
        public string Image { get; set; }
        public string DemoAdvertising { get; set; }
        public string DemoVoiceOver { get; set; }
        public string VoiceDescription { get; set; }

        public string WorkingHours { get; set; }
        public List<int> ListHours => !String.IsNullOrEmpty(WorkingHours) ? JsonConvert.DeserializeObject<List<int>>(WorkingHours) : new List<int>();

        public string WorkingDays { get; set; }
        public List<int> ListDays => !String.IsNullOrEmpty(WorkingDays) ? JsonConvert.DeserializeObject<List<int>>(WorkingDays) : new List<int>();

        public string Params { get; set; }
        public VoiceParams VoiceParams => !String.IsNullOrEmpty(Params) ? JsonConvert.DeserializeObject<VoiceParams>(Params) : new VoiceParams();

        public string Videos { get; set; }
        public List<FileItem> ListVideos => String.IsNullOrEmpty(Videos) ? new List<FileItem>() : JsonConvert.DeserializeObject<List<FileItem>>(Videos);

        public string Hours
        {
            get
            {
                var sorted = ListHours.OrderBy(p => p).ToList();
                var result = new List<List<int>>();
                var arr = new List<int>();
                for (int i = 0; i < sorted.Count; i++ )
                {
                    if (i == 0 || (sorted[i] - 1 == sorted[i - 1]))
                    {
                        arr.Add(sorted[i]);
                    }
                    else
                    {
                        result.Add(arr);
                        arr = new List<int>{ sorted[i] };
                    }
                }
                result.Add(arr);

                var str = string.Join(",<br/>", result.Select(p => $"{p.Min()}:00 - {p.Max()}:00"));
                return str;
            }
        }
    }
}
