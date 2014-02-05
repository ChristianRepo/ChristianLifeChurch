using System.Globalization;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ChristianLifeChurch.BackOffice
{
    public static class JsonSettings
    {
        public static void RegisterSettings()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings =
            new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Unspecified,
                Culture = CultureInfo.GetCultureInfo("ru-RU"),
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    }
}