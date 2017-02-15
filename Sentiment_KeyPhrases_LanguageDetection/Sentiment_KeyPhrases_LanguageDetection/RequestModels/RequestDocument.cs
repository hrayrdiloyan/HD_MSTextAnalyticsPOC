using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentiment_KeyPhrases_LanguageDetection
{
    public class RequestDocument
    {
        public string language { get; set; }
        public string id { get; set; }
        public string text { get; set; }
    }
    public class RequestRootObject
    {
        public List<RequestDocument> documents { get; set; }
    }
}
