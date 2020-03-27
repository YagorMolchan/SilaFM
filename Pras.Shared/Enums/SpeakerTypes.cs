using System.ComponentModel;

namespace Pras.Shared.Enums
{
    public enum SpeakerTypes
    {
        [Description("Детские голоса")]
        Child,
        [Description("Федеральные дикторы")]
        Federal,
        [Description("Дикторы")]
        Speaker,
        [Description("Пародисты и актеры")]
        Parodist,
        [Description("Вокалисты")]
        Vocalist
    }
}
