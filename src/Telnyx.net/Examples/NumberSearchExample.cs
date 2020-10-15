namespace Telnyx.net.Examples
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    /// <summary>
    /// Number Search Example.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class NumberSearchExample
    {
        private const string YOURAPIKEY = "YOUR_API_KEY";
        private readonly NumberSearchService service = new NumberSearchService();

        /// <summary>
        /// List number service.
        /// </summary>
        public void ListNumberService()
        {
            var listOptions = new NumberSearchOptions();
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var numberSearchList = this.service.List(listOptions, requestOptions);
            Console.WriteLine(JsonConvert.SerializeObject(numberSearchList));
        }
    }
}
