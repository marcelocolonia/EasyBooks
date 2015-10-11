using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace EasyBooks.DAL
{
    public static class JsonHelper
    {
        public static void CreateJson<T>(object obj)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);

            var filepath = HostingEnvironment.MapPath(@"~/App_Data/" + typeof(T).Name + ".json");

            File.WriteAllText(filepath, json);
        }

        public static List<T> FetchDataFromJson<T>()
        {
            var filepath = HostingEnvironment.MapPath(@"~/App_Data/" + typeof(T).Name + ".json");

            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(filepath)).ToList();
        }
    }
}
