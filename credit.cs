using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace CodeSamples
{
    class CreditSample
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            Main().Wait();
        }
        static async Task Main()
        {
            string payload = "client_username={yourUsername}&client_password={yourPassword}&client_token=token&processing_type=CREDIT&expiration_month=10&expiration_year=2022&account_number={yourTestCardNumber}&cvv2=123&currency=USD&initial_amount=99.99";

            Dictionary<string, string> formData = new Dictionary<string, string>();

            string[] fields = payload.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string pair in fields)
            {
                try {
                    string[] keyValue = pair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    formData.Add(keyValue[0], keyValue[1]);
                } catch (Exception e) {
                    Console.Error.WriteLine("Invalid data pair: " + pair);
                    Console.Error.WriteLine(e.ToString());
                }
            }

            if (formData.Count < 1)
            {
                Console.Error.WriteLine("No Data!");
            } else {

                //!! Important make sure to use TLS 1.2 first before trying other version
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                FormUrlEncodedContent data = new FormUrlEncodedContent(formData);

                var response = await client.PostAsync(new Uri("https://gatewaystaging.payscout.com/api/process"), data);

                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode) {
                    Console.WriteLine("Transaction request sent successfully: " + responseString);
                } else {
                    Console.Error.WriteLine("Error while sending transaction request: " + response.StatusCode + responseString);
                }

            }
        }
    }
}
 
