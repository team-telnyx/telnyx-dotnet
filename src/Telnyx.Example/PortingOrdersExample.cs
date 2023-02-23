namespace Telnyx.Example
{
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;
    using Telnyx;
    using Telnyx.net.Services;

    public class PortingOrdersExample
    {
        private readonly PortingOrderService _service = new PortingOrderService();

        /// <summary>
        /// Get phone number
        /// </summary>
        public async Task GetListPortingOrdersAsync()
        {
            try
            {
                var options = new PortingOrderOption();
                var portingOrders = await this._service.ListPortingOrdersAsync(options);
                Console.WriteLine(JsonConvert.SerializeObject(portingOrders));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        } 
    }
}
