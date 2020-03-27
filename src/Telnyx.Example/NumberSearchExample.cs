namespace Telnyx.Example
{
    using System;
    using Newtonsoft.Json;

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
            var listOptions = new NumberSearchListOptions();
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            try
            {
                var numberSearchList = this.service.List(listOptions);
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
