using System;
using Newtonsoft.Json;

namespace Telnyx.Example
{
    /// <summary>
    /// Number Search Example
    /// </summary>
    public class NumberSearchExample
    {
        private readonly NumberSearchService service = new NumberSearchService();

        /// <summary>
        /// List number service
        /// </summary>
        public void ListNumberService()
        {
            var numberSearchListOptions = new NumberSearchOptions()
            {
                CountryCode = "US",
                Limit = 3,
                NumberType = "toll-free",
                Quickship = true
            };
            Console.WriteLine(JsonConvert.SerializeObject(numberSearchListOptions));

            try
            {
                var numberSearchList = this.service.List(numberSearchListOptions);
                Console.WriteLine("numberSearchList");
                Console.WriteLine(JsonConvert.SerializeObject(numberSearchList));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }
        public void ListNumberServicePaged()
        {
            var numberSearchListOptions = new NumberSearchOptions()
            {
                CountryCode = "US",
            };
            Console.WriteLine(JsonConvert.SerializeObject(numberSearchListOptions));

            try
            {
                var numberSearchList = this.service.List(numberSearchListOptions);
                Console.WriteLine("numberSearchList");
                Console.WriteLine(JsonConvert.SerializeObject(numberSearchList));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }
    }
}
