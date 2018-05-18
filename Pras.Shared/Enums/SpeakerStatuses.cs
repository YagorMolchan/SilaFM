using System.ComponentModel;

namespace Pras.Shared.Enums
{
    public enum SpeakerStatuses
    {
        [Description("В студии")]
        InStudio,
        [Description("Оффлайн")]
        Offline,
        [Description("Под заказ")]
        Order,
        [Description("Временно не работает")]
        OutOfService
    }
}
