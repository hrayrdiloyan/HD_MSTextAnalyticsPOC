using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
namespace Sentiment_KeyPhrases_LanguageDetection
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Azure portal URL.
        /// </summary>
        private const string BaseUrl = "https://westus.api.cognitive.microsoft.com/";

        /// <summary>
        /// Your account key goes here.
        /// </summary>
        private string AccountKey = "";

        /// <summary>
        /// Maximum number of languages to return in language detection API.
        /// </summary>
        private const int NumLanguages = 1;

        private string FileName = string.Empty;

        private HttpClient httpClientObj;
        public Form1()
        {
            InitializeComponent();
            httpClientObj = new HttpClient();
            httpClientObj.BaseAddress = new Uri(BaseUrl);

            httpClientObj.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            DialogResult result = dlgFileOpen.ShowDialog();
            if (result == DialogResult.OK)
            {
                FileName = dlgFileOpen.FileName;
                txtFilePath.Text = FileName;
            }

        }

        /// <summary>
        /// Perform validation
        /// </summary>
        private bool PerformValidation()
        {
            // Check that service api key is provided
            if (string.IsNullOrEmpty(txtCognitiveServicesAPIKey.Text))
            {
                MessageBox.Show("Please enter service api key...");
                return false;
            }
            AccountKey = txtCognitiveServicesAPIKey.Text;


            // Request headers.
            httpClientObj.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AccountKey);

            // Check if file is selected
            if (string.IsNullOrEmpty(FileName))
            {
                MessageBox.Show("Please choose the file...");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check the sentiment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSentiment_Click(object sender, EventArgs e)
        {
            if (!PerformValidation())
                return;

            // Prepare json payload of the documents
            RequestDocument doc = new RequestDocument();
            doc.language = "en";
            doc.id = "1001";
            // read the text from the file we specified
            doc.text = System.IO.File.ReadAllText(FileName);

            List<RequestDocument> lstDocs = new List<RequestDocument>();
            lstDocs.Add(doc);
            RequestRootObject ro = new RequestRootObject();
            ro.documents = lstDocs;

            // text to be analysed
            StringContent strPayload = new StringContent(JsonConvert.SerializeObject(ro), Encoding.UTF8, "application/json");


            // Detect sentiment:
            var uri = "text/analytics/v2.0/sentiment";
            var response = await CallEndpoint(httpClientObj, uri, await strPayload.ReadAsByteArrayAsync());
            ResponseRootObject responseAsJson = JsonConvert.DeserializeObject<ResponseRootObject>(response);
            rtbOutput.Text = string.Empty;
            rtbOutput.AppendText("Detected sentiment in 0-1 range,where 0 is negative and 1 is positive is:" + responseAsJson.documents[0].score);
        }

        private async void btnKeyPhrases_Click(object sender, EventArgs e)
        {
            if (!PerformValidation())
                return;

            // Prepare json payload of the documents
            RequestDocument doc = new RequestDocument();
            doc.language = "en";
            doc.id = "1001";
            // read the text from the file we specified
            doc.text = System.IO.File.ReadAllText(FileName);

            List<RequestDocument> lstDocs = new List<RequestDocument>();
            lstDocs.Add(doc);
            RequestRootObject ro = new RequestRootObject();
            ro.documents = lstDocs;

            // text to be analysed
            StringContent strPayload = new StringContent(JsonConvert.SerializeObject(ro), Encoding.UTF8, "application/json");


            // Detect sentiment:
            var uri = "text/analytics/v2.0/keyPhrases";
            var response = await CallEndpoint(httpClientObj, uri, await strPayload.ReadAsByteArrayAsync());
            ResponseRootObject responseAsJson = JsonConvert.DeserializeObject<ResponseRootObject>(response);
            rtbOutput.Text = string.Empty;

            rtbOutput.AppendText("Key phrases of the document are:\n" + String.Join("\n", responseAsJson.documents[0].keyPhrases.Select(p => p.ToString()).ToArray()));
        }
        private async void btnLanguageDetection_Click(object sender, EventArgs e)
        {
            if (!PerformValidation())
                return;

            // Prepare json payload of the documents
            RequestDocument doc = new RequestDocument();
            doc.language = "en";
            doc.id = "1001";
            // read the text from the file we specified
            doc.text = System.IO.File.ReadAllText(FileName);

            List<RequestDocument> lstDocs = new List<RequestDocument>();
            lstDocs.Add(doc);
            RequestRootObject ro = new RequestRootObject();
            ro.documents = lstDocs;

            // text to be analysed
            StringContent strPayload = new StringContent(JsonConvert.SerializeObject(ro), Encoding.UTF8, "application/json");
            
            // Detect language:
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["numberOfLanguagesToDetect"] = NumLanguages.ToString(CultureInfo.InvariantCulture);
            var uri = "text/analytics/v2.0/languages?" + queryString;
            var response = await CallEndpoint(httpClientObj, uri, await strPayload.ReadAsByteArrayAsync());
            ResponseRootObject responseAsJson = JsonConvert.DeserializeObject<ResponseRootObject>(response);
            rtbOutput.Text = string.Empty;

            rtbOutput.AppendText("Key phrases of the document are:\n" + String.Join("\n", responseAsJson.documents[0].keyPhrases.Select(p => p.ToString()).ToArray()));
        }
        static async Task<String> CallEndpoint(HttpClient client, string uri, byte[] byteData)
        {
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);
                return await response.Content.ReadAsStringAsync();
            }
        }

        
    }
}
