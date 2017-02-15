using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentiment_KeyPhrases_LanguageDetection
{
    public class ResponseDocument
    {
        public double score { get; set; }
        public string id { get; set; }
        public string[] keyPhrases { get; set; }

    }
    public class ResponseRootObject
    {
        public List<ResponseDocument> documents { get; set; }
        public List<Error> errors { get; set; }
    }
    public class Error
    {
        public string id { get; set; }
        public string message { get; set; }
    }

    
}
