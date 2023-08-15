using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Telnyx.net.Services.HostedNumbers;

namespace Telnyx.Example
{
    [ExcludeFromCodeCoverage]
    public class HostedNumbersExample
    {
        private HostedNumberOrderService orderService;
        private HostedNumberService service;
        public HostedNumbersExample()
        {
            orderService = new HostedNumberOrderService();
            service = new HostedNumberService();
        }

        public async Task CreatedHostedNumberAsync(IEnumerable<string> numbers)
        {
            var messagingProfileService = new MessagingProfileService();
            var id = messagingProfileService.List().Data.First().Id;
            var options = new HostedNumberOrderOptions { MessagingProfileId = id.ToString(), PhoneNumbers = numbers };
            var result = await orderService.CreateHostedNumberOrdersAsync(options);
            Console.WriteLine("Number Order Created: ");
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }
        public async Task ListAsync()
        {
            var result = await orderService.ListHostedNumberOrdersAsync(new ListOptions(1, 25));
            Console.WriteLine("Number Orders Listed: ");
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }
        public async Task UploadFiles()
        {
            var messagingProfileService = new MessagingProfileService();
            var id = messagingProfileService.List().Data.First().Id;
            var fOptions = new FileUploadOptions { Bill = "testdata", Loa = "testdata" };
            var result = await orderService.UploadFileAsync(id.ToString(), fOptions);
            Console.WriteLine("Number Orders Files Uploaded: ");
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }
        public async Task DeleteAsync()
        {
            var id = (await orderService.ListHostedNumberOrdersAsync(new ListOptions(1, 25))).Data.First().PhoneNumbers.First().Id;
            var result = await service.DeleteHostedNumberAsync(id);
            Console.WriteLine("Hosted Number Deleted: ");
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}
