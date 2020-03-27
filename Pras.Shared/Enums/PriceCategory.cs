using System.ComponentModel;

namespace Pras.Shared.Enums
{
    public enum PriceCategory
    {
        [Description("Бюджет")]
        Budget,
        [Description("Эконом")]
        Economy,
        [Description("Средняя")]
        Average,
        [Description("Элит")]
        Elite,
        [Description("Премиум")]
        Premium,
    }
}