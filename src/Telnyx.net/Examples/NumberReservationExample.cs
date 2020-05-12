namespace Telnyx.net.Examples
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Number Reservation Example.
    /// </summary>
    public class NumberReservationExample
    {
        private const string YOURAPIKEY = "YOUR_API_KEY";
        private readonly NumberReservationsService service = new NumberReservationsService();

        /// <summary>
        /// Create number reservation.
        /// </summary>
        public void CreateNumberReservation()
        {
            var numberReservation = new NumberReservation
            {
                PhoneNumbers = new List<ReservedPhoneNumber>()
                {
                    new ReservedPhoneNumber
                    {
                        PhoneNumber = "+18665552368"
                    }
                }
            };
            Console.WriteLine(JsonConvert.SerializeObject(numberReservation));

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var result = this.service.Create(numberReservation, requestOptions);
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// List number reservation.
        /// </summary>
        public void ListNumberReservation()
        {
            var listOptions = new NumberReservationsListOptions();
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            var requestOptions = new RequestOptions
            {
                ApiKey = YOURAPIKEY
            };
            Console.WriteLine(JsonConvert.SerializeObject(requestOptions));

            var numberReservationList = this.service.List(listOptions, requestOptions);
            Console.WriteLine(JsonConvert.SerializeObject(numberReservationList));
        }
    }
}
