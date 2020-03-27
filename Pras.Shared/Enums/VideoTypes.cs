using System.ComponentModel;

namespace Pras.Shared.Enums
{
    public enum VideoTypes
    {
        [Description("Озвучка видео")]
        VoiceOver,
        [Description("Дубляж")]
        Dubbing,
        [Description("Видеопрезентации")]
        Presentation,
        [Description("Мультипликации")]
        Animation,
        [Description("Док. фильмы")]
        Documentary,
        [Description("Копроративные")]
        Corporate,
    }
}
