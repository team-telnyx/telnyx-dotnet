using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Telnyx.Example
{
    /// <summary>
    /// Number Reservation Example
    /// </summary>
    public class NumberReservationExample
    {
        private readonly NumberReservationsService service = new NumberReservationsService();

        /// <summary>
        /// Create number reservation
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

            try
            {
                var result = this.service.Create(numberReservation);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// List number reservation
        /// </summary>
        public void ListNumberReservation()
        {
            var listOptions = new NumberReservationsListOptions();
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            try
            {
                var numberReservationList = this.service.List(listOptions);
                Console.WriteLine(JsonConvert.SerializeObject(numberReservationList));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
        }
    }
}
