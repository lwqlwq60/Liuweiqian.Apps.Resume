namespace Liuweiqian.Apps.Resume.Utils
{
    using System.Text.RegularExpressions;
    public static class Formatter
    {
        public static bool MatchWebUrl(string urlStr)
        {
            string httpFormat = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            Match http = Regex.Match(urlStr, httpFormat);
            string httpsFormat = @"https://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            Match https = Regex.Match(urlStr, httpsFormat);
            return http.Success | https.Success;
        }
    }
}
