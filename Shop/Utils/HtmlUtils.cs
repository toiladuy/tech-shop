using HtmlAgilityPack;

namespace Shop.Utils
{
    public class HtmlUtils
    {
        public static string HtmlToText(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode.InnerText;
        }
    }
}
