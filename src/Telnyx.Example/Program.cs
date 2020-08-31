using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Telnyx.Infrastructure;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Enum.Webhooks;
using Telnyx.net.Entities.Messaging.Messaging;

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

            //Console.WriteLine("MessagesExample...");
            //MessagesExample messagesExample = new MessagesExample();
            //await messagesExample.SendMessage();
            //messagesExample.RetrieveMessage();

            //Console.WriteLine("MessagingProfilesExample...");
            //MessagingProfilesExample messagingProfilesExample = new MessagingProfilesExample();
            //messagingProfilesExample.ListPaged();
            //messagingProfilesExample.List();
            //messagingProfilesExample.ListAllMessagingProfilePhoneNumbers();
            //messagingProfilesExample.Create();
            //messagingProfilesExample.Update();
            //messagingProfilesExample.Delete();

            //Console.WriteLine("MessagingProfilesMetricsExample...");
            ////Optional add your own messaging profile ID
            //await messagingProfilesExample.GetDetailAsync();
            //await messagingProfilesExample.ListOverviewAsync();

            //Console.WriteLine("NumberOrderExample...");
            //NumberOrderExample numberOrderExample = new NumberOrderExample();
            //numberOrderExample.ListNumberOrder();
            //numberOrderExample.CreateNumberOrder();

            //Console.WriteLine("NumberReservationExample...");
            //NumberReservationExample numberReservationExample = new NumberReservationExample();
            //numberReservationExample.CreateNumberReservation();
            //numberReservationExample.ListNumberReservation();

            //Console.WriteLine("NumberSearchExample...");
            //NumberSearchExample numberSearchExample = new NumberSearchExample();
            //numberSearchExample.ListNumberService();
            //numberSearchExample.ListNumberServicePaged();

            //Console.WriteLine("PhoneNumbersExample...");
            //PhoneNumbersExample phoneNumbersExample = new PhoneNumbersExample();
            //phoneNumbersExample.GetPhoneNumber();
            //phoneNumbersExample.ListNumberOrder();
            //phoneNumbersExample.UpdatePhoneNumber();

            //Console.WriteLine("CallControlExample...");
            //CallControlExample callControlExample = new CallControlExample();
            //callControlExample.Dial();

            //callControlExample.SetCallControlId("v2:ZKoCq-ggJPRhO3H9KxQa5zVQphVX8Hx9d_FRl2b-W2dQfVUHfhe13g");

            //callControlExample.Speak();
            //callControlExample.Bridge();
            //callControlExample.ForkingStart();
            //callControlExample.ForkingStop();
            //callControlExample.GatherUsingAudio();
            //callControlExample.GatherUsingSpeak();
            //callControlExample.Hangup();
            //callControlExample.PlaybackStart();
            //callControlExample.PlaybackStop();
            //callControlExample.RecordStart();
            //callControlExample.RecordStop();
            //callControlExample.Reject();
            //callControlExample.SendDTMF();
            //callControlExample.Transfer();

            //Console.WriteLine("ConferenceCommandsExample...");
            //ConferenceCommandsExample conferenceCommandsExample = new ConferenceCommandsExample();
            //conferenceCommandsExample.SetCallControlId("v2:ZKoCq-ggJPRhO3H9KxQa5zVQphVX8Hx9d_FRl2b-W2dQfVUHfhe13g");

            //conferenceCommandsExample.Create();

            //Console.WriteLine("NumberConfigurationExample..");
            //NumberConfigurationExample numConfigExample = new NumberConfigurationExample();
            //await numConfigExample.ListPhoneNumbersWithPagingAsync();
            //await numConfigExample.ListPhoneNumbersWithFiltersAsync();
            //await numConfigExample.ListMessagingOptionsAsync();
            //await numConfigExample.ListVoiceSettingsWithFiltersAsync();

            //Console.WriteLine("CallControlApplicationExample...");
            //CallControlApplicationsExample callControlApplicationsExample = new CallControlApplicationsExample();
            //callControlApplicationsExample.List();
            //callControlApplicationsExample.Create();
            //callControlApplicationsExample.Get();
            //callControlApplicationsExample.Delete();
            //callControlApplicationsExample.Update();

            //Console.WriteLine("OutboundVoiceProfilesExample...");
            //OutboundVoiceProfilesExample outboundVoiceProfilesExample = new OutboundVoiceProfilesExample();
            //outboundVoiceProfilesExample.List();
            //outboundVoiceProfilesExample.Create();
            //outboundVoiceProfilesExample.Get();
            //outboundVoiceProfilesExample.Delete();
            //outboundVoiceProfilesExample.Update();

            //Console.WriteLine("Connections Example....");
            //ConnectionsExample connectionsExample = new ConnectionsExample();
            //await connectionsExample.ListConnectionsAsync();
            //await connectionsExample.ListCredConnectionsAsync();
            //await connectionsExample.ListIPConnectionsAsync();
            //await connectionsExample.ListIPsAsync();
            //await connectionsExample.ListFQDNConnectionsAsync();
            //await connectionsExample.ListFQDNsAsync();

            //Console.WriteLine("NumberLookupExample...");
            //NumberLookupExample numberLookupExample = new NumberLookupExample();
            //numberLookupExample.Get();
            //await numberLookupExample.GetAsync();

            //Console.WriteLine("MobileOperatorNetworksExample...");
            //MobileOperatorNetworksExample mobileOperatorNetworksExample = new MobileOperatorNetworksExample();
            //mobileOperatorNetworksExample.List();
            //await mobileOperatorNetworksExample.ListAsync();

            //Console.WriteLine("OTAUpdatesExample...");
            //OTAUpdatesExample oTAUpdatesExample = new OTAUpdatesExample();
            //oTAUpdatesExample.Get();
            //await oTAUpdatesExample.GetAsync();
            //oTAUpdatesExample.List();
            //await oTAUpdatesExample.ListAsync();

            //Console.WriteLine("WDRReportsExample...");
            //WDRReportsExample wDRReportsExample = new WDRReportsExample();
            //wDRReportsExample.Get();
            //await wDRReportsExample.GetAsync();
            //wDRReportsExample.List();
            //await wDRReportsExample.ListAsync();
            //wDRReportsExample.Create();
            //await wDRReportsExample.CreateAsync();
            //wDRReportsExample.Delete();
            //await wDRReportsExample.DeleteAsync();

            //Console.WriteLine("SimCardsExample...");
            //SimCardsExample simCardsExample = new SimCardsExample();
            //simCardsExample.Get();
            //await simCardsExample.GetAsync();
            //simCardsExample.List();
            //await simCardsExample.ListAsync();
            //simCardsExample.Delete();
            //await simCardsExample.DeleteAsync();
            //simCardsExample.Enable();
            //await simCardsExample.EnableAsync();
            //simCardsExample.Disable();
            //await simCardsExample.DisableAsync();
            //simCardsExample.Register();
            //await simCardsExample.RegisterAsync();
            //simCardsExample.BulkUpdateNetworkPreference();
            //await simCardsExample.BulkUpdateNetworkPreferenceAsync();
            //simCardsExample.GetNetworkPreference();
            //await simCardsExample.GetNetworkPreferenceAsync();
            //simCardsExample.SetNetworkPreference();
            //await simCardsExample.SetNetworkPreferenceAsync();
            //simCardsExample.DeleteNetworkPreference();
            //await simCardsExample.DeleteNetworkPreferenceAsync();

            Console.WriteLine("Start Webhook Example....");
            await ReceiveAndHandleWebhook();
        }
        public async static Task<HttpStatusCode> ReceiveAndHandleWebhook()
        {
            Console.WriteLine("Beginning WebhookExample...");
            Console.WriteLine("Send Message...");
            //MessagesExample messagesExample = new MessagesExample();
            //await messagesExample.SendMessage();
            Console.WriteLine("Message sent waiting for webhook...");
            await Task.Delay(3000);
            Console.WriteLine("Webhook Listener...");
            await Task.Delay(2000);
            var outBoundRequest = new MockHTTPRequest("{\r\n  \"data\": {\r\n    \"event_type\": \"message.finalized\",\r\n    \"id\": \"4ee8c3a6-4995-4309-a3c6-38e3db9ea4be\",\r\n    \"occurred_at\": \"2019-12-09T21:32:14.148+00:00\",\r\n    \"payload\": {\r\n      \"completed_at\": \"2019-12-09T21:32:14.148+00:00\",\r\n      \"cost\": null,\r\n      \"direction\": \"outbound\",\r\n      \"encoding\": \"GSM-7\",\r\n      \"errors\": [],\r\n      \"from\": {\r\n        \"carrier\": \"T-Mobile USA\",\r\n        \"line_type\": \"Wireless\",\r\n        \"phone_number\": \"+13125000000\",\r\n        \"status\": \"webhook_delivered\"\r\n      },\r\n      \"id\": \"ac012cbf-5e09-46af-a69a-7c0e2d90993c\",\r\n      \"media\": [],\r\n      \"messaging_profile_id\": \"83d2343b-553f-4c5f-b8c8-fd27004f94bf\",\r\n      \"organization_id\": \"9d76d591-1b7d-405d-8c64-1320ee070245\",\r\n      \"parts\": 1,\r\n      \"received_at\": \"2019-12-09T21:32:13.552+00:00\",\r\n      \"record_type\": \"message\",\r\n      \"sent_at\": \"2019-12-09T21:32:13.596+00:00\",\r\n      \"tags\": [],\r\n      \"text\": \"Hello there!\",\r\n      \"to\": [\r\n        {\r\n          \"carrier\": \"T-MOBILE USA, INC.\",\r\n          \"line_type\": \"Wireless\",\r\n          \"phone_number\": \"+13125000000\",\r\n          \"status\": \"delivered\"\r\n        }\r\n      ],\r\n      \"type\": \"SMS\",\r\n      \"valid_until\": \"2019-12-09T22:32:13.552+00:00\",\r\n      \"webhook_failover_url\": \"\",\r\n      \"webhook_url\": \"http://webhook.site/af3a92e7-e150-442c-9fe6-61658ce26b1a\"\r\n    },\r\n    \"record_type\": \"event\"\r\n  },\r\n  \"meta\": {\r\n    \"attempt\": 1,\r\n    \"delivered_to\": \"http://webhook.site/af3a92e7-e150-442c-9fe6-61658ce26b1a\"\r\n  }\r\n}");
            var inboundRequest = new MockHTTPRequest("{\r\n  \"data\": {\r\n    \"event_type\": \"message.received\",\r\n    \"id\": \"0b39187e-bbd3-438f-9c55-cf048e9a00c7\",\r\n    \"occurred_at\": \"2020-08-26T18:49:58.026+00:00\",\r\n    \"payload\": {\r\n      \"cc\": [],\r\n      \"completed_at\": null,\r\n      \"cost\": null,\r\n      \"direction\": \"inbound\",\r\n      \"encoding\": \"UCS-2\",\r\n      \"errors\": [],\r\n      \"from\": {\r\n        \"carrier\": \"Verizon Wireless\",\r\n        \"line_type\": \"Wireless\",\r\n        \"phone_number\": \"+19197891146\"\r\n      },\r\n      \"id\": \"4c87f42a-6023-4aa6-84af-cc903469bdf9\",\r\n      \"media\": [\r\n        {\r\n          \"content_type\": \"image/jpeg\",\r\n          \"hash_sha256\": \"6c8cb6ea44a91de858dae49802e1a528d1c77bdaa89af036c3139edbd442960a\",\r\n          \"size\": 92084,\r\n          \"url\": \"https://tlnx-mms-media.s3.amazonaws.com/mms/ffaf3631da836e7d26ec56527f0c8e22/6c8cb6ea44a91de858dae49802e1a528d1c77bdaa89af036c3139edbd442960a.jpeg\"\r\n        }\r\n      ],\r\n      \"messaging_profile_id\": \"4001742b-90be-405d-b1b5-40a434f0ffec\",\r\n      \"organization_id\": \"747f5f5c-c2f5-4518-b749-b06a1d3f4a34\",\r\n      \"parts\": 1,\r\n      \"received_at\": \"2020-08-26T18:49:57.866+00:00\",\r\n      \"record_type\": \"message\",\r\n      \"sent_at\": null,\r\n      \"tags\": [],\r\n      \"text\": \"\",\r\n      \"to\": [\r\n        {\r\n          \"carrier\": \"Telnyx\",\r\n          \"line_type\": \"Wireless\",\r\n          \"phone_number\": \"+19842550905\",\r\n          \"status\": \"webhook_delivered\"\r\n        }\r\n      ],\r\n      \"type\": \"MMS\",\r\n      \"valid_until\": null,\r\n      \"webhook_failover_url\": null,\r\n      \"webhook_url\": \"https://webhook.x.pipedream.net\"\r\n    },\r\n    \"record_type\": \"event\"\r\n  },\r\n  \"meta\": {\r\n    \"attempt\": 1,\r\n    \"delivered_to\": \"https://webhook.x.pipedream.net\"\r\n  }\r\n}");
            Console.WriteLine($"Webhook Received at {DateTime.Now} via {outBoundRequest.Method}");
            //Get the Message body from the HTTP POST Request
            var outBoundBody = outBoundRequest.Body;
            var inboundBody = inboundRequest.Body;
            try
            {
                //Can get the object type two ways if wanting webhook url to be generic:
                //Method 1:
                JObject parsedJsonInbound = JObject.Parse(inboundBody);
                EventType eventTypeInbound = ToEnum<EventType>(parsedJsonInbound["data"]["event_type"].ToString());
                //TODO: build event type to object mapping, for now, can use a dicitionary for example:
                var typeLookupInbound = GetTypeLookup(eventTypeInbound);

                JObject parsedJsonOutbound = JObject.Parse(outBoundBody);
                EventType eventTypeOutbound = ToEnum<EventType>(parsedJsonOutbound["data"]["event_type"].ToString());
                //TODO: build event type to object mapping, for now, can use a dicitionary for example:
                var typeLookupOutbound = GetTypeLookup(eventTypeOutbound);

                if (eventTypeOutbound == EventType.MessageFinalized || typeLookupOutbound == typeof(OutboundMessage))
                {
                    var messageFinalWebhook = JsonConvert.DeserializeObject<TelnyxWebhook<OutboundMessage>>(outBoundBody);
                    var myRepository = new SaveResponseRepository<OutboundMessage>();
                    
                    Console.WriteLine("Save properties from outbound webhook or do stuff...");
                    
                    if (messageFinalWebhook != null && messageFinalWebhook.Data.Payload.CreatedAt != null)
                        await myRepository.Save(messageFinalWebhook.Data.Payload);
                    
                    Console.WriteLine("Return 200 OK");
                    return HttpStatusCode.OK;
                }
                
                if (typeLookupInbound == typeof(MessageWebhook))
                {
                    var messageInboundWebhook = JsonConvert.DeserializeObject<TelnyxWebhook<MessageWebhook>>(inboundBody);
                    var myRepository = new SaveResponseRepository<MessageWebhook>();

                    Console.WriteLine("Save properties from inbound webhook or do stuff...");

                    if (messageInboundWebhook != null && messageInboundWebhook.Data.Payload.CreatedAt != null)
                        await myRepository.Save(messageInboundWebhook.Data.Payload);

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
                { EventType.MessageReceived, typeof(MessageWebhook) },
                { EventType.MessageSent, typeof(MessageWebhook) },
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
