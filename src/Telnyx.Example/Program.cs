using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

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
        }
    }
}
