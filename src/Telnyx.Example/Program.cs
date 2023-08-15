using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Enum.Webhooks;
using Telnyx.net.Infrastructure.Public;

namespace Telnyx.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Examples...");

            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build()
            .LoadAppSettingsIntoEnvironmentVariables();

            TelnyxConfiguration.SetApiBase("https://api.telnyx.com/v2");
            TelnyxConfiguration.SetApiKey(config["TelnyxApiKey"]);

            Console.WriteLine("MessagesExample...");
            MessagesExample messagesExample = new MessagesExample();
            await messagesExample.SendMessage();
            messagesExample.RetrieveMessage();

            Console.WriteLine("MessagingProfilesExample...");
            MessagingProfilesExample messagingProfilesExample = new MessagingProfilesExample();
            messagingProfilesExample.ListPaged();
            messagingProfilesExample.List();
            messagingProfilesExample.ListAllMessagingProfilePhoneNumbers();
            messagingProfilesExample.Create();
            messagingProfilesExample.Update();
            messagingProfilesExample.Delete();

            Console.WriteLine("MessagingProfilesMetricsExample...");
            //Optional add your own messaging profile ID
            await messagingProfilesExample.GetDetailAsync();
            await messagingProfilesExample.ListOverviewAsync();

            Console.WriteLine("NumberOrderExample...");
            NumberOrderExample numberOrderExample = new NumberOrderExample();
            numberOrderExample.ListNumberOrder();
            numberOrderExample.CreateNumberOrder();

            Console.WriteLine("NumberReservationExample...");
            NumberReservationExample numberReservationExample = new NumberReservationExample();
            numberReservationExample.CreateNumberReservation();
            numberReservationExample.ListNumberReservation();

            Console.WriteLine("NumberSearchExample...");
            NumberSearchExample numberSearchExample = new NumberSearchExample();
            numberSearchExample.ListNumberService();
            numberSearchExample.ListNumberServicePaged();

            Console.WriteLine("PhoneNumbersExample...");
            PhoneNumbersExample phoneNumbersExample = new PhoneNumbersExample();
            phoneNumbersExample.GetPhoneNumber();
            phoneNumbersExample.ListNumberOrder();
            phoneNumbersExample.UpdatePhoneNumber();

            Console.WriteLine("CallControlExample...");
            CallControlExample callControlExample = new CallControlExample();
            callControlExample.Dial();

            callControlExample.SetCallControlId("v2:ZKoCq-ggJPRhO3H9KxQa5zVQphVX8Hx9d_FRl2b-W2dQfVUHfhe13g");

            callControlExample.Speak();
            callControlExample.Bridge();
            callControlExample.ForkingStart();
            callControlExample.ForkingStop();
            callControlExample.GatherUsingAudio();
            callControlExample.GatherUsingSpeak();
            callControlExample.Hangup();
            callControlExample.PlaybackStart();
            callControlExample.PlaybackStop();
            callControlExample.RecordStart();
            callControlExample.RecordStop();
            callControlExample.Reject();
            callControlExample.SendDTMF();
            callControlExample.Transfer();

            Console.WriteLine("ConferenceCommandsExample...");
            ConferenceCommandsExample conferenceCommandsExample = new ConferenceCommandsExample();
            conferenceCommandsExample.SetCallControlId("v2:ZKoCq-ggJPRhO3H9KxQa5zVQphVX8Hx9d_FRl2b-W2dQfVUHfhe13g");

            conferenceCommandsExample.Create();
            conferenceCommandsExample.List();
            Console.WriteLine("NumberConfigurationExample..");
            NumberConfigurationExample numConfigExample = new NumberConfigurationExample();
            await numConfigExample.ListPhoneNumbersWithPagingAsync();
            await numConfigExample.ListPhoneNumbersWithFiltersAsync();
            await numConfigExample.ListMessagingOptionsAsync();
            await numConfigExample.ListVoiceSettingsWithFiltersAsync();

            Console.WriteLine("CallControlApplicationExample...");
            CallControlApplicationsExample callControlApplicationsExample = new CallControlApplicationsExample();
            callControlApplicationsExample.List();
            callControlApplicationsExample.Create();
            callControlApplicationsExample.Get();
            callControlApplicationsExample.Delete();
            callControlApplicationsExample.Update();

            Console.WriteLine("OutboundVoiceProfilesExample...");
            OutboundVoiceProfilesExample outboundVoiceProfilesExample = new OutboundVoiceProfilesExample();
            outboundVoiceProfilesExample.List();
            outboundVoiceProfilesExample.Create();
            outboundVoiceProfilesExample.Get();
            outboundVoiceProfilesExample.Delete();
            outboundVoiceProfilesExample.Update();

            Console.WriteLine("Connections Example....");
            ConnectionsExample connectionsExample = new ConnectionsExample();
            await connectionsExample.ListConnectionsAsync();
            await connectionsExample.ListCredConnectionsAsync();
            await connectionsExample.ListIPConnectionsAsync();
            await connectionsExample.ListIPsAsync();
            await connectionsExample.ListFQDNConnectionsAsync();
            await connectionsExample.ListFQDNsAsync();

            Console.WriteLine("NumberLookupExample...");
            NumberLookupExample numberLookupExample = new NumberLookupExample();
            numberLookupExample.Get();
            await numberLookupExample.GetAsync();

            Console.WriteLine("MobileOperatorNetworksExample...");
            MobileOperatorNetworksExample mobileOperatorNetworksExample = new MobileOperatorNetworksExample();
            mobileOperatorNetworksExample.List();
            await mobileOperatorNetworksExample.ListAsync();

            Console.WriteLine("OTAUpdatesExample...");
            OTAUpdatesExample oTAUpdatesExample = new OTAUpdatesExample();
            oTAUpdatesExample.Get();
            await oTAUpdatesExample.GetAsync();
            oTAUpdatesExample.List();
            await oTAUpdatesExample.ListAsync();

            Console.WriteLine("WDRReportsExample...");
            WDRReportsExample wDRReportsExample = new WDRReportsExample();
            wDRReportsExample.Get();
            await wDRReportsExample.GetAsync();
            wDRReportsExample.List();
            await wDRReportsExample.ListAsync();
            wDRReportsExample.Create();
            await wDRReportsExample.CreateAsync();
            wDRReportsExample.Delete();
            await wDRReportsExample.DeleteAsync();

            Console.WriteLine("SimCardsExample...");
            SimCardsExample simCardsExample = new SimCardsExample();
            simCardsExample.Get();
            await simCardsExample.GetAsync();
            simCardsExample.List();
            await simCardsExample.ListAsync();
            simCardsExample.Delete();
            await simCardsExample.DeleteAsync();
            simCardsExample.Enable();
            await simCardsExample.EnableAsync();
            simCardsExample.Disable();
            await simCardsExample.DisableAsync();
            simCardsExample.Register();
            await simCardsExample.RegisterAsync();
            simCardsExample.BulkUpdateNetworkPreference();
            await simCardsExample.BulkUpdateNetworkPreferenceAsync();
            simCardsExample.GetNetworkPreference();
            await simCardsExample.GetNetworkPreferenceAsync();
            simCardsExample.SetNetworkPreference();
            await simCardsExample.SetNetworkPreferenceAsync();
            simCardsExample.DeleteNetworkPreference();
            await simCardsExample.DeleteNetworkPreferenceAsync();

            Console.WriteLine("Start Webhook Example....");
            await ReceiveAndHandleWebhook();

            Console.WriteLine("TelephonyCredentialExample...");
            TelephonyCredentialExample telephonyCredentialExample = new TelephonyCredentialExample();
            telephonyCredentialExample.Get();
            await telephonyCredentialExample.GetAsync();
            telephonyCredentialExample.List();
            await telephonyCredentialExample.ListAsync();
            telephonyCredentialExample.Create();
            await telephonyCredentialExample.CreateAsync();
            telephonyCredentialExample.Update();
            await telephonyCredentialExample.UpdateAsync();
            telephonyCredentialExample.Delete();
            await telephonyCredentialExample.DeleteAsync();
            telephonyCredentialExample.GetToken();
            await telephonyCredentialExample.GetTokenAsync();

            Console.WriteLine("2FA Verification Example...");
            var verificationExample = new VerificationExample();
            await verificationExample.RunVerification();

            Console.WriteLine("Fax Example...");
            var faxExample = new FaxExample();
            faxExample.ReceiveWebhook();
            Console.WriteLine("HostedNumber Orders Example...");
            var hostedExample = new HostedNumbersExample();
            await hostedExample.CreatedHostedNumberAsync(new List<string> { "+17735556766" });
            /*Only call with your credentials*/
            //GetWebhook();

        }

        public async static Task<HttpStatusCode> ReceiveAndHandleWebhook()
        {
            Console.WriteLine("Beginning WebhookExample...");
            Console.WriteLine("Send Message...");
            MessagesExample messagesExample = new MessagesExample();
            await messagesExample.SendMessage();
            Console.WriteLine("Message sent waiting for webhook...");
            await Task.Delay(3000);
            Console.WriteLine("Webhook Listener...");
            await Task.Delay(2000);
            var request = new MockHTTPRequest("{\r\n  \"data\": {\r\n    \"event_type\": \"message.finalized\",\r\n    \"id\": \"4ee8c3a6-4995-4309-a3c6-38e3db9ea4be\",\r\n    \"occurred_at\": \"2019-12-09T21:32:14.148+00:00\",\r\n    \"payload\": {\r\n      \"completed_at\": \"2019-12-09T21:32:14.148+00:00\",\r\n      \"cost\": null,\r\n      \"direction\": \"outbound\",\r\n      \"encoding\": \"GSM-7\",\r\n      \"errors\": [],\r\n      \"from\": {\r\n        \"carrier\": \"T-Mobile USA\",\r\n        \"line_type\": \"Wireless\",\r\n        \"phone_number\": \"+13125000000\",\r\n        \"status\": \"webhook_delivered\"\r\n      },\r\n      \"id\": \"ac012cbf-5e09-46af-a69a-7c0e2d90993c\",\r\n      \"media\": [],\r\n      \"messaging_profile_id\": \"83d2343b-553f-4c5f-b8c8-fd27004f94bf\",\r\n      \"organization_id\": \"9d76d591-1b7d-405d-8c64-1320ee070245\",\r\n      \"parts\": 1,\r\n      \"received_at\": \"2019-12-09T21:32:13.552+00:00\",\r\n      \"record_type\": \"message\",\r\n      \"sent_at\": \"2019-12-09T21:32:13.596+00:00\",\r\n      \"tags\": [],\r\n      \"text\": \"Hello there!\",\r\n      \"to\": [\r\n        {\r\n          \"carrier\": \"T-MOBILE USA, INC.\",\r\n          \"line_type\": \"Wireless\",\r\n          \"phone_number\": \"+13125000000\",\r\n          \"status\": \"delivered\"\r\n        }\r\n      ],\r\n      \"type\": \"SMS\",\r\n      \"valid_until\": \"2019-12-09T22:32:13.552+00:00\",\r\n      \"webhook_failover_url\": \"\",\r\n      \"webhook_url\": \"http://webhook.site/af3a92e7-e150-442c-9fe6-61658ce26b1a\"\r\n    },\r\n    \"record_type\": \"event\"\r\n  },\r\n  \"meta\": {\r\n    \"attempt\": 1,\r\n    \"delivered_to\": \"http://webhook.site/af3a92e7-e150-442c-9fe6-61658ce26b1a\"\r\n  }\r\n}");
            Console.WriteLine($"Webhook Received at {DateTime.Now} via {request.Method}");
            //Get the Message body from the HTTP POST Request
            var body = request.Body;
            try
            {
                //Can get the object type two ways if wanting webhook url to be generic:
                //Method 1:
                JObject parsedJson = JObject.Parse(body);
                EventType eventType = ToEnum<EventType>(parsedJson["data"]["event_type"].ToString());
                //TODO: build event type to object mapping, for now, can use a dicitionary for example:
                var typeLookup = GetTypeLookup(eventType);

                //Method2:
                var objectToParse = JsonConvert.DeserializeObject<TelnyxWebhook<object>>(body);
                var typeofObject = objectToParse.Data.Payload.GetType();
                TelnyxWebhook<OutboundMessage> message = (TelnyxWebhook<OutboundMessage>)JsonConvert.DeserializeObject(body, typeofObject);

                if (eventType == EventType.MessageFinalized || typeLookup.GetType() == typeof(OutboundMessage))
                {
                    var messageFinalWebhook = JsonConvert.DeserializeObject<TelnyxWebhook<OutboundMessage>>(body);
                    var myRepository = new SaveResponseRepository<OutboundMessage>();

                    Console.WriteLine("Save properties from webhook or do stuff...");

                    if (messageFinalWebhook != null && messageFinalWebhook.Data.Payload.CreatedAt != null)
                        await myRepository.Save(messageFinalWebhook.Data.Payload);

                    Console.WriteLine("Return 200 OK");
                    return HttpStatusCode.OK;
                }
                /*
                 * else... do something else. 
                 * Ideally webhook URLs should know the type that they are expecting when the webhook is registered via the webhook_url property.
                 * For example, when creating an OutBoundMessage, you explicitly set the webhook_url the webhook will ping for updates. 
                 */
                return HttpStatusCode.NotFound;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong.. {ex.Message}");
                return HttpStatusCode.InternalServerError;
            }

        }

        public static Type GetTypeLookup(EventType enumType)
        {
            var typeLookup = new Dictionary<EventType, Type> {
                { EventType.MessageFinalized, typeof(OutboundMessage) },
                { EventType.MessageReceived, typeof(OutboundMessage) },
                { EventType.MessageSent, typeof(OutboundMessage) },
                /*
                 * {...} //More Enum mappings etc.
                 */
            };
            return typeLookup[enumType];
        }

        public static T ToEnum<T>(string str)
        {
            var enumType = typeof(T);
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
                if (enumMemberAttribute.Value == str) return (T)Enum.Parse(enumType, name);
            }
            return default;
        }

        public static TelnyxWebhook<dynamic> GetWebhook()
        {
            var payload = "SAMPLE_PAYLOAD";
            var publicKey = "YOUR_PUBLIC_KEY";
            /*From request object example: Request.Headers["telnyx-signature-ed25519"]; */
            var telnyxSignature = "hk0AvSYv+xze5WKnEwNoE2zisVK6R3whPKkso8drRZhYjkpgXd9MkSnjsJGhQ+sEUqaMF5fQdaHSZnz/ET3pDA==";
            /*From request object example: Request.Headers["telnyx-timestamp"]; */
            var telnyxTimeStamp = 1601667324.ToString();
            var @event = Webhook.ConstructEvent(payload, telnyxSignature, telnyxTimeStamp, publicKey);
            return @event;
        }


    }

    public class SaveResponseRepository<T>
    {
        public async Task Save(T objectToSave)
        {
            Console.WriteLine("Succesfully Saved!");
            await Task.Delay(2000);
        }
    }
    public class MockHTTPRequest
    {
        public MockHTTPRequest(string body)
        {
            this.Body = body;
        }
        public string Body { get; set; }
        public HttpMethod Method => HttpMethod.Post;

    }
}
