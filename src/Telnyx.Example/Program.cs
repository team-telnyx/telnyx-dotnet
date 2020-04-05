using System;

namespace Telnyx.Example
{
    class Program
    {
        private static string AcquiredCallControlId = "v2:3fa85f64-5717-4562-b3fc-2c963f66afa6";

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Examples...");

            TelnyxConfiguration.SetApiBase("https://api.telnyx.com/v2");// ($"http://localhost:12111/v2");
            TelnyxConfiguration.SetFilesBase("http://api.telnyx.com/v2"); //($"http://localhost:12111/v2");
            TelnyxConfiguration.SetApiKey("KEY0170CBFE0003DDA859D411D1013E1F90_e4Hp11KrxKgfFlqUxLgg9H");

            Console.WriteLine("MessagesExample...");
            MessagesExample messagesExample = new MessagesExample();
            messagesExample.SendMessage();
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
            CallControlExample callCommandsExample = new CallControlExample();
            callCommandsExample.Dial();
            callCommandsExample.Speak(AcquiredCallControlId);
            callCommandsExample.Bridge(AcquiredCallControlId);
            callCommandsExample.ForkingStart(AcquiredCallControlId);
            callCommandsExample.ForkingStop(AcquiredCallControlId);
            callCommandsExample.GatherUsingAudio(AcquiredCallControlId);
            callCommandsExample.GatherUsingSpeak(AcquiredCallControlId);
            callCommandsExample.Hangup(AcquiredCallControlId);
            callCommandsExample.PlaybackStart(AcquiredCallControlId);
            callCommandsExample.PlaybackStop(AcquiredCallControlId);
            callCommandsExample.RecordStart(AcquiredCallControlId);
            callCommandsExample.RecordStop(AcquiredCallControlId);
            callCommandsExample.Reject(AcquiredCallControlId);
            callCommandsExample.SendDTMF(AcquiredCallControlId);
            callCommandsExample.Transfer(AcquiredCallControlId);
        }
    }
}
