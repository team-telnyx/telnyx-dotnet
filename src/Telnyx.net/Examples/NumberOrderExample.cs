namespace Telnyx.net.Examples
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Number Order Example.
    /// </summary>
    public class NumberOrderExample
    {
        private const string YOURAPIKEY = "YOUR_API_KEY";
        private readonly NumberOrderService service = new NumberOrderService();

        /// <summary>
        /// Create number order.
        /// </summary>
        public void CreateNumberOrder()
        {
            var numberOrderCreateOptions = new NumberOrderCreateOptions()
            {
                PhoneNumbers = new List<PhoneNumber>()
                {
                    new PhoneNumber
                    {
                        Phone_Number = "+13127000090"
                    }
                }
            };
            Console.WriteLine(JsonConvert.SerializeObject(numberOrderCreateOptions));

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var result = this.service.Create(numberOrderCreateOptions, requestOptions);
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// List number order.
        /// </summary>
        public void ListNumberOrder()
        {
            var listOptions = new NumberOrderListOptions();
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var numberOrderList = this.service.List(listOptions, requestOptions);
            Console.WriteLine(JsonConvert.SerializeObject(numberOrderList));
        }
    }
}
