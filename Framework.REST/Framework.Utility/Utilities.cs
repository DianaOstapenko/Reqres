using System;

namespace Framework.Utility
{
    public static class Tools
    {
        private static readonly JsonHelper _jsonHelper = new JsonHelper();
        //private static readonly XmlHelper _xmlHelper = new XmlHelper();
        //private static readonly PathHelper _PathHelper = new PathHelper();

        public static JsonHelper Json
        {
            get { return _jsonHelper; }
        }
        //public static XmlHelper Xml
        //{
        //    get { return _xmlHelper; }
        //}
        //public static PathHelper Path
        //{
        //    get { return _PathHelper; }
        //}
    }
}
