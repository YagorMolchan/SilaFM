using System.ComponentModel;

namespace Pras.Shared.Enums
{
    public enum VoiceAge
    {
        [Description("детский, до 16 лет")]
        Less16,
        [Description("молодежный, 18-25 лет")]
        Less25,
        [Description("молодой, 30-40 лет")]
        Less40,
        [Description("взрослый, 40-55 лет")]
        Less55,
        [Description("возрастной, 55-65 лет")]
        Less65,
        [Description("пожилой")]
        OldAged
    }
}