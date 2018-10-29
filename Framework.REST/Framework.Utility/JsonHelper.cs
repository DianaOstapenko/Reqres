using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Framework.Utility
{
    public class JsonHelper
    {
        public void PopulateJson(string value, object target)
        {
            JsonConvert.PopulateObject(value, target);
        }
    }
}