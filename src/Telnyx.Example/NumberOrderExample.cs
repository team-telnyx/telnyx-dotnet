using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Telnyx.Example
{
    /// <summary>
    /// Number Order Example
    /// </summary>
    public class NumberOrderExample
    {
        private readonly NumberOrderService service = new NumberOrderService();

        /// <summary>
        /// Create number order
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
            Console.WriteLine("numberOrderCreateOptions");
            Console.WriteLine(JsonConvert.SerializeObject(numberOrderCreateOptions, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            try
            {
                var result = this.service.Create(numberOrderCreateOptions);
                Console.WriteLine("result");
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// List number order
        /// </summary>
        public void ListNumberOrder()
        {
            var listOptions = new NumberOrderListOptions();
            Console.WriteLine("listOptions");
            Console.WriteLine(JsonConvert.SerializeObject(listOptions, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            var requestOptions = new RequestOptions();
            try
            {
                var numberOrderList = this.service.List(listOptions, requestOptions);
                Console.WriteLine("numberOrderList");
                Console.WriteLine(JsonConvert.SerializeObject(numberOrderList));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }
    }
}
