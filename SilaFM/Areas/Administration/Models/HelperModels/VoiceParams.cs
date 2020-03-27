using System.ComponentModel.DataAnnotations;

namespace Pras.Web.Areas.Administration.Models.HelperModels
{
    public class VoiceParams
    {
        public VoiceParams()
        {
            LowHighTone = 50;
            ConfidentVoice = 50;
            RichVoice = 50;
            EnergeticVoice = 50;
            BusinessVoice = 50;
        }
        [Range(1, 100, ErrorMessage = "Значение должно быть от 1 до 100")]
        public int LowHighTone { get; set; }
        [Range(1, 100, ErrorMessage = "Значение должно быть от 1 до 100")]
        public int ConfidentVoice { get; set; }
        [Range(1, 100, ErrorMessage = "Значение должно быть от 1 до 100")]
        public int RichVoice { get; set; }
        [Range(1, 100, ErrorMessage = "Значение должно быть от 1 до 100")]
        public int EnergeticVoice { get; set; }
        [Range(1, 100, ErrorMessage = "Значение должно быть от 1 до 100")]
        public int BusinessVoice { get; set; }
    }
}
