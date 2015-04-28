using System.Net;
using System.Text;

namespace Rabbit.FirApi.Utility
{
    internal static class WebClientHelper
    {
        public static WebClient GetWebClient()
        {
            return new WebClient
            {
                Encoding = Encoding.UTF8
            };
        }
    }
}