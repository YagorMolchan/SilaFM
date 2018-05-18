using System.ComponentModel;

namespace Pras.Shared.Enums
{
    public enum VideoTypes
    {
        [Description("Мультипликации")]
        Animation,
        [Description("Копроративные")]
        Corporate,
        [Description("Док. фильмы")]
        Documentary,
        [Description("Дубляж")]
        Dubbing,
        [Description("Видеопрезентации")]
        Presentation,
        [Description("Озвучка видео")]
        VoiceOver,
    }
}
