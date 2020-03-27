using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Pras.Web.Models.Forms
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            SpeakerFormModel = SpeakerFormModel ?? new SpeakerOrderFormModel();
            ScenarioFormModel = ScenarioFormModel ?? new ScenarioOrderFormModel();
            AudioFormModel = AudioFormModel ?? new AudioOrderFormModel();
            VideoFormModel = VideoFormModel ?? new VideoOrderFormModel();
            MusicFormModel = MusicFormModel ?? new MusicOrderFormModel();
        }
        public SpeakerOrderFormModel SpeakerFormModel { get; set; }
        public ScenarioOrderFormModel ScenarioFormModel { get; set; }
        public AudioOrderFormModel AudioFormModel { get; set; }
        public VideoOrderFormModel VideoFormModel { get; set; }
        public MusicOrderFormModel MusicFormModel { get; set; }
    }
}
