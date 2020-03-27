namespace Pras.Web.Extensions
{
    public static class StringExtensions
    {
        public static string ToMultiline(this string text)
        {
            return text.Replace("\r\n", "<br/>").Replace("\n\r", "<br/>").Replace("\r", "<br/>").Replace("\n", "<br/>");
        }
    }
}
