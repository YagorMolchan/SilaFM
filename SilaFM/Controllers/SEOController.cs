using System;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Pras.BLL.Services.Interfaces;
using Pras.Shared.Enums;

namespace Pras.Web.Controllers
{
    public class SEOController : Controller
    {
        private string sitename;
        private string host;

        public SEOController()
        {
            sitename = "http://silafm.ru";
            host = "silafm.ru";
        }

        //Get: robots.txt
        [Route("robots.txt")]
        [ResponseCache(NoStore = true)]//No caching
        public string Robots()
        {
            string robots = String.Format(
                @"
User-agent: Googlebot
Allow: /
Disallow: /Scripts/
Disallow: /admin/
Host: {0}
 
User-agent: Yandex
Allow: /
Disallow: /Scripts/
Disallow: /admin/
Host: {0}
 
User-agent: *
Allow: /
Disallow: /Scripts/
Disallow: /admin/
Host: {0}
 
Sitemap: http://{0}/sitemap.xml", host);
            Response.ContentType = "text/plain";
            return robots;
        }

        //GET: sitemap.xml
        [Route("sitemap.xml")]
        [ResponseCache(NoStore = true)]//No caching
        public ContentResult Sitemap([FromServices] ISettingsService settingsService, 
                                    [FromServices] INewsService newsService, 
                                    [FromServices] ISpeakersService speakersService, 
                                    [FromServices] IInformationService informationService, 
                                    [FromServices] IVideoService videoService)
        {
            //generate SiteMap
            var memoryStream = new MemoryStream();
            using (TextWriter textWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8))
            {
                XmlTextWriter writer = new XmlTextWriter(textWriter);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("urlset");
                writer.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");

                var prefix = sitename;
                //Home
                var date = settingsService.Find().Created;
                writer = printElement(writer,
                    prefix + Url.Action("Index", "Home"),
                    "always", "1", date);
                //Contacts
                writer = printElement(writer,
                    prefix + Url.Action("Contact", "Home"),
                    "always", "0.7", date);
                //SpeakersChild
                date = speakersService.Find(SpeakerTypes.Child).Max(p => p.Created);
                writer = printElement(writer,
                    prefix + Url.Action("SpeakersChild", "Home"),
                    "always", "0.5", date);
                //SpeakersRu
                date = speakersService.Find(SpeakerCountries.Russia).Max(p => p.Created);
                writer = printElement(writer,
                    prefix + Url.Action("SpeakersRu", "Home"),
                    "always", "0.5", date);
                //SpeakersUk
                date = speakersService.Find(SpeakerCountries.Ukraine).Max(p => p.Created);
                writer = printElement(writer,
                    prefix + Url.Action("SpeakersUk", "Home"),
                    "always", "0.5", date);
                //SpeakersFor
                date = speakersService.Find(SpeakerCountries.Other).Max(p => p.Created);
                writer = printElement(writer,
                    prefix + Url.Action("SpeakersFor", "Home"),
                    "always", "0.5", date);
                //SpeakersParodists
                date = speakersService.Find(SpeakerTypes.Parodist).Max(p => p.Created);
                writer = printElement(writer,
                    prefix + Url.Action("SpeakersParodists", "Home"),
                    "always", "0.5", date);
                //SpeakersVocalists
                date = speakersService.Find(SpeakerTypes.Vocalist).Max(p => p.Created);
                writer = printElement(writer,
                    prefix + Url.Action("SpeakersVocalists", "Home"),
                    "always", "0.5", date);
                //SpeakersVip
                date = speakersService.FindVip().Max(p => p.Created);
                writer = printElement(writer,
                    prefix + Url.Action("SpeakersVip", "Home"),
                    "always", "0.5", date);
                //Scenario
                date = informationService.Find(InformationTypes.Scenario).Created;
                writer = printElement(writer,
                    prefix + Url.Action("Scenario", "Home"),
                    "always", "0.5", date);
                //Audio
                date = informationService.Find(InformationTypes.Audio).Created;
                writer = printElement(writer,
                    prefix + Url.Action("Audio", "Home"),
                    "always", "0.5", date);
                //Video
                date = informationService.Find(InformationTypes.Video).Created;
                writer = printElement(writer,
                    prefix + Url.Action("Video", "Home"),
                    "always", "0.5", date);
                //Games
                date = informationService.Find(InformationTypes.Games).Created;
                writer = printElement(writer,
                    prefix + Url.Action("Games", "Home"),
                    "always", "0.5", date);
                //Music
                date = informationService.Find(InformationTypes.Music).Created;
                writer = printElement(writer,
                    prefix + Url.Action("Music", "Home"),
                    "always", "0.5", date);
                //Payment
                date = informationService.Find(InformationTypes.Payment).Created;
                writer = printElement(writer,
                    prefix + Url.Action("Payment", "Home"),
                    "always", "0.5", date);
                //VideoCreating
                date = videoService.Find().Max(p => p.Created);
                writer = printElement(writer,
                    prefix + Url.Action("VideoCreating", "Home"),
                    "always", "0.5", date);
                //Order
                writer = printElement(writer,
                    prefix + Url.Action("Order", "Home"),
                    "always", "0.5", null);
                //Chronomer
                writer = printElement(writer,
                    prefix + Url.Action("Chronomer", "Home"),
                    "always", "0.5", null);
                //Pages
                writer = printElement(writer,
                    prefix + Url.Action("Pages", "Home"),
                    "always", "0.5", null);

                //News
                var news = newsService.Find();
                foreach (var item in news)
                {
                    writer = printElement(writer,
                            prefix + Url.Action("NewsInner", "Home", new { url = item.Url }),
                            "always", "0.5", item.Created);
                }
                writer.WriteEndElement();
            }
            return Content(System.Text.Encoding.UTF8.GetString(memoryStream.ToArray()), "application/xml");
        }

        private XmlTextWriter printElement(XmlTextWriter writer, string loc, string changeref, string priority, DateTime? lastmod = null)
        {
            var date = lastmod ?? new DateTime(2017, 02, 11);
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", loc);
            writer.WriteElementString("lastmod", date.ToString("yyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture));
            writer.WriteElementString("changefreq", changeref);
            writer.WriteElementString("priority", priority);
            writer.WriteEndElement();

            return writer;
        }
    }
}