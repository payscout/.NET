using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace CodeSamples
{
    class PreauthorizationSample
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            Main().Wait();
        }
        static async Task Main()
        {
            string payload = "client_username={yourUsername}&client_password={yourPassword}&client_token=token&processing_type=PRE_AUTHORIZATION&billing_first_name=John&billing_last_name=Doe&billing_phone_number=2455464&billing_address_line_1=Innovation Street 1&billing_address_line_2=Brilliance Building%2C Apt. 22&billing_city=Palo Alto&billing_state=CA&billing_postal_code=94024&billing_country=US&billing_email_address=demo@payscout.com&ip_address=98.97.129.52&billing_date_of_birth=19801229&billing_social_security_number=000000000&expiration_month=10&expiration_year=2022&account_number={yourTestCardNumber}&cvv2=123&currency=USD&initial_amount=99.99&shipping_first_name=Amazing&shipping_last_name=Jane&shipping_email_address=demoshipping@payscout.com&shipping_cell_phone_number=74477464&shipping_phone_number=7447746400&shipping_address_line_1=Innovation Street 1&shipping_address_line_2=Brilliance Building%2C Apt. 22&shipping_city=Palo Alto&shipping_state=CA&shipping_postal_code=94024&shipping_country=US&billing_invoice_number=1999";

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
