using System.ComponentModel.DataAnnotations;

namespace Pras.Web.Areas.Administration.Models.HelperModels
{
    public class VoiceParams
    {
        public VoiceParams()
        {
            LowHighTone = 0;
            ConfidentVoice = 0;
            RichVoice = 0;
            EnergeticVoice = 0;
            BusinessVoice = 0;
        }
        [Range(-10, 10, ErrorMessage = "Значение должно быть от -10 до 10")]
        public int LowHighTone { get; set; }
        [Range(-10, 10, ErrorMessage = "Значение должно быть от -10 до 10")]
        public int ConfidentVoice { get; set; }
        [Range(-10, 10, ErrorMessage = "Значение должно быть от -10 до 10")]
        public int RichVoice { get; set; }
        [Range(-10, 10, ErrorMessage = "Значение должно быть от -10 до 10")]
        public int EnergeticVoice { get; set; }
        [Range(-10, 10, ErrorMessage = "Значение должно быть от -10 до 10")]
        public int BusinessVoice { get; set; }
    }
}
