using System.ComponentModel;

namespace Pras.Shared.Enums
{
    public enum SpeakerTypes
    {
        [Description("Детские голоса")]
        Child,
        [Description("Женские Голоса")]
        Female,
        [Description("Мужские Голоса")]
        Male,
        [Description("Пародисты и актеры")]
        Parodist,
        [Description("Вокалисты")]
        Vocalist
    }
}
