using System.ComponentModel;

namespace Pras.Shared.Enums
{
    public enum AudioTypes
    {
        [Description("Игровые и постановочные")]
        Game,
        [Description("Информационно-музыкальные")]
        Information,
        [Description("Имидживая аудиореклама")]
        Brand,
        [Description("Рекламные песни, пропевки и музыкальные логотипы")]
        PromotionalSongs,
        [Description("Оформление радиоэфира, джинглы, отбивки, анонсы")]
        Jingles,
        [Description("Голосовые приветствия, голосовое меню, запись IVR")]
        VoiceMenu
    }
}
