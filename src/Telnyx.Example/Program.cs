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
            await numConfigExample.ListPhoneNumbersWithFiltersAsync();
            await numConfigExample.ListMessagingOptionsAsync();
            await numConfigExample.ListVoiceSettingsWithFiltersAsync();

        }
    }
}
