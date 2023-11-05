//using RestSharp;
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


namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var client = new RestClient("https://iapi.myfci.com:8075/graphql");
            ////client.Timeout = -1;

            //var request = new RestRequest("", Method.POST);
            //request.AddHeader("Authorization", "Bearer eN38lsDqKm5kPB1XZosiL-XXss4CgQCOJd4e9Hp-BQY");
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", "{\"query\":\"    mutation{ \\r\\n    insertLoanCharge\\r\\n    (\\r\\n        charges:\\r\\n    { \\r\\n      loanNumber:\\\"9160038726\\\",\\r\\n      investorAccountNumber:\\\"1905509\\\",\\r\\n      chargeDate:\\\"08/22/2022\\\",\\r\\n      chargeAmount:1,\\r\\n      paidBy:\\\"Borrower\\\",\\r\\n      invoiceNumber:\\\"SR2044367-Legal fees-8111-06062022-18-20220606\\\",\\r\\n      comments:\\\"Test\\\",\\r\\n      doc1:\\\"https://file-examples-com.github.io/uploads/2017/02/file-sample_500kB\\\",\\r\\n      doc2:\\\"URL\\\",\\r\\n      doc3:\\\"URL\\\"\\r\\n    }\\r\\n    )}\\r\\n  \",\"variables\":{}}",
            //           ParameterType.RequestBody);
            //RestResponse response = (RestResponse)client.Execute(request);
            //// Console.WriteLine(response.Content);
            //MessageBox.Show(response.Content.ToString());
            //MessageBox.Show(response.ResponseStatus.ToString());
            //MessageBox.Show(response.StatusCode.ToString());
            //MessageBox.Show(response.StatusDescription);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string url;
            string urlParameters="";
            url = "https://192.168.11.15/NotificationService/api/LoansAPI/SendNotification/04-26-2023/-1";

            CallAPI(url, urlParameters);
        }


        public  void CallAPI(string url, string urlParameters)
        {

            HttpClientHandler clientHandler = new HttpClientHandler();
            // clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            clientHandler.UseDefaultCredentials = true;
            clientHandler.ClientCertificateOptions = ClientCertificateOption.Automatic;


            HttpClient client = new HttpClient(clientHandler);
            client.BaseAddress = new Uri(url);
            


            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));



            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
        
            }
            else
            {
 
            }
            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //decimal amount = 1234567.34545M;
            //string formattedAmount = amount.ToString("#,##");
            decimal amount = 1234567.89m;
            string formattedAmount = amount.ToString("C", CultureInfo.GetCultureInfo("en-US"));
            
            MessageBox.Show(formattedAmount);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
