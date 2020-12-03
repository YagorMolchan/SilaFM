using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pras.Shared.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SocialsType
    {
        Facebook,
        Instagram,
        LinkedIn,
        Skype,
        Telegram,
        Viber,
        Vk,
        WhatsApp,
    }
}