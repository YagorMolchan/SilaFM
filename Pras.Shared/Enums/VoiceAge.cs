using System.ComponentModel;

namespace Pras.Shared.Enums
{
    public enum VoiceAge
    {
        [Description("до 16")]
        Less16,
        [Description("до 20")]
        Less20,
        [Description("до 30")]
        Less30,
        [Description("до 40")]
        Less40,
        [Description("до 55")]
        Less55,
        [Description("пожилой")]
        OldAged
    }
}