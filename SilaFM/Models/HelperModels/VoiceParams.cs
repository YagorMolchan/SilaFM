namespace Pras.Web.Models.HelperModels
{
    public class VoiceParams
    {
        public VoiceParams()
        {
            LowHighTone = 1;
            ConfidentVoice = 1;
            RichVoice = 1;
            EnergeticVoice = 1;
            BusinessVoice = 1;
        }
        public int LowHighTone { get; set; }
        public int ConfidentVoice { get; set; }
        public int RichVoice { get; set; }
        public int EnergeticVoice { get; set; }
        public int BusinessVoice { get; set; }
    }
}
