using System.ComponentModel;

namespace Pras.Shared.Enums
{
    public enum Currency
    {
        [Description("Рубли")]
        Rubles,
        [Description("Гривны")]
        Hryvnia,
        [Description("Доллары")]
        Dollars,
        [Description("Евро")]
        Euro
    }
}