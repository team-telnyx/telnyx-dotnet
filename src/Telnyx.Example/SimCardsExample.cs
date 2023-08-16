using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Wireless.OTAUpdates;
using Telnyx.net.Entities.Wireless.SimCards;
using Telnyx.net.Services.Wireless.SimCards;

namespace Telnyx.Example
{
    public class SimCardsExample
    {
        private readonly SimCardsService service = new SimCardsService();

        private const string id = "6a09cdc3-8948-47f0-aa62-74ac943d6c58";

        public SimCardRecord Get()
        {
            SimCardRecord result = new SimCardRecord();

            try
            {
                var baseOptions = new BaseOptions();
                baseOptions.AddExtraParam("include_sim_card_group", "true");

                result = service.Get(id, null);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<SimCardRecord> GetAsync()
        {
            SimCardRecord result = new SimCardRecord();

            try
            {
                var baseOptions = new BaseOptions();
                baseOptions.AddExtraParam("include_sim_card_group", "true");

                result = await service.GetAsync(id, baseOptions, null);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public TelnyxList<SimCardRecord> List()
        {
            TelnyxList<SimCardRecord> result = new TelnyxList<SimCardRecord>();
            ListOptions listOptions = new ListOptions
            {
                PageNumber = 1,
                PageSize = 20
            };
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            try
            {
                result = service.List(listOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<TelnyxList<SimCardRecord>> ListAsync()
        {
            TelnyxList<SimCardRecord> result = new TelnyxList<SimCardRecord>();
            ListOptions listOptions = new ListOptions
            {
                PageNumber = 1,
                PageSize = 20
            };
            Console.WriteLine(JsonConvert.SerializeObject(listOptions));

            try
            {
                result = await service.ListAsync(listOptions, null, new CancellationToken());
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public SimCardRecord Delete()
        {
            SimCardRecord result = new SimCardRecord();

            try
            {
                var baseOptions = new BaseOptions();
                baseOptions.AddExtraParam("include_sim_card_group", "true");

                result = service.Delete(id, null);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<SimCardRecord> DeleteAsync()
        {
            SimCardRecord result = new SimCardRecord();

            try
            {
                result = await service.DeleteAsync(id, null);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public SimCardRecord Enable()
        {
            SimCardRecord result = new SimCardRecord();

            try
            {
                result = service.Enable(id);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<SimCardRecord> EnableAsync()
        {
            SimCardRecord result = new SimCardRecord();
            try
            {
                result = await service.EnableAsync(id);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public SimCardRecord Disable()
        {
            SimCardRecord result = new SimCardRecord();

            BaseOptions baseOptions = new BaseOptions();

            try
            {
                result = service.Disable(id);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<SimCardRecord> DisableAsync()
        {
            SimCardRecord result = new SimCardRecord();

            BaseOptions baseOptions = new BaseOptions();

            try
            {
                result = await service.DisableAsync(id);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public TelnyxList<SimCardRecord> Register()
        {
            TelnyxList<SimCardRecord> result = new TelnyxList<SimCardRecord>();
            SimCardRegisterOptions baseOptions = new SimCardRegisterOptions
            {
                RegistrationCodes = new string[]
                {
                    "0000000001",
                    "0000000002",
                    "0000000003",
                },
                SimCardGroupId = "6a09cdc3-8948-47f0-aa62-74ac943d6c58",
                Tags = new string[]
                {
                    "personal",
                    "customers",
                    "active-customers",
                },
            };

            try
            {
                result = service.Register(baseOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<TelnyxList<SimCardRecord>> RegisterAsync()
        {
            TelnyxList<SimCardRecord> result = new TelnyxList<SimCardRecord>();
            SimCardRegisterOptions baseOptions = new SimCardRegisterOptions
            {
                RegistrationCodes = new string[]
                {
                    "0000000001",
                    "0000000002",
                    "0000000003",
                },
                SimCardGroupId = "6a09cdc3-8948-47f0-aa62-74ac943d6c58",
                Tags = new string[]
                {
                    "personal",
                    "customers",
                    "active-customers",
                },
            };

            try
            {
                result = await service.RegisterAsync(baseOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public TelnyxCollection<MobileOperatorNetworksPreferencesRecord> BulkUpdateNetworkPreference()
        {
            TelnyxCollection<MobileOperatorNetworksPreferencesRecord> result = new TelnyxCollection<MobileOperatorNetworksPreferencesRecord>();
            SimCardBulkNetworkPreferenceUpdateOptions baseOptions = new SimCardBulkNetworkPreferenceUpdateOptions
            {
                SimCardIds = new string[]
               {
                    "6b14e151-8493-4fa1-8664-1cc4e6d14158",
                    "6b14e151-8493-4fa1-8664-1cc4e6d14158",
               },
                MobileOperatorNetworksPreferences = new List<MobileOperatorNetworksPreferences>()
                {
                    new MobileOperatorNetworksPreferences()
                    {
                        MobileOperatorNetworkId = new Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                        Priority = 0,
                    },
                },
            };

            try
            {
                result = service.BulkUpdateNetworkPreference(baseOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }
        public async Task<TelnyxCollection<MobileOperatorNetworksPreferencesRecord>> BulkUpdateNetworkPreferenceAsync()
        {
            TelnyxCollection<MobileOperatorNetworksPreferencesRecord> result = new TelnyxCollection<MobileOperatorNetworksPreferencesRecord>();
            SimCardBulkNetworkPreferenceUpdateOptions baseOptions = new SimCardBulkNetworkPreferenceUpdateOptions
            {
                SimCardIds = new string[]
               {
                    "6b14e151-8493-4fa1-8664-1cc4e6d14158",
                    "6b14e151-8493-4fa1-8664-1cc4e6d14158",
               },
                MobileOperatorNetworksPreferences = new List<MobileOperatorNetworksPreferences>()
                {
                    new MobileOperatorNetworksPreferences()
                    {
                        MobileOperatorNetworkId = new Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                        Priority = 0,
                    },
                },
            };

            try
            {
                result = await service.BulkUpdateNetworkPreferenceAsync(baseOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public MobileOperatorNetworksPreferencesRecord GetNetworkPreference()
        {
            MobileOperatorNetworksPreferencesRecord result = new MobileOperatorNetworksPreferencesRecord();

            try
            {
                var baseOptions = new BaseOptions();
                baseOptions.AddExtraParam("include_ota_updates", "true");

                result = service.GetNetworkPreference(id, baseOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<MobileOperatorNetworksPreferencesRecord> GetNetworkPreferenceAsync()
        {
            MobileOperatorNetworksPreferencesRecord result = new MobileOperatorNetworksPreferencesRecord();

            try
            {
                var baseOptions = new BaseOptions();
                baseOptions.AddExtraParam("include_ota_updates", "true");

                result = await service.GetNetworkPreferenceAsync(id, baseOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public MobileOperatorNetworksPreferencesRecord SetNetworkPreference()
        {
            MobileOperatorNetworksPreferencesRecord result = new MobileOperatorNetworksPreferencesRecord();

            try
            {
                var baseOptions = new SimCardNetworkPreferenceUpdateOptions
                {
                    MobileOperatorNetworksPreferences = new List<MobileOperatorNetworksPreferences>()
                {
                    new MobileOperatorNetworksPreferences()
                    {
                        MobileOperatorNetworkId = new Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                        Priority = 0,
                    },
                },
                };
                result = service.SetNetworkPreference(id, baseOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<MobileOperatorNetworksPreferencesRecord> SetNetworkPreferenceAsync()
        {
            MobileOperatorNetworksPreferencesRecord result = new MobileOperatorNetworksPreferencesRecord();

            try
            {
                var baseOptions = new SimCardNetworkPreferenceUpdateOptions
                {
                    MobileOperatorNetworksPreferences = new List<MobileOperatorNetworksPreferences>()
                {
                    new MobileOperatorNetworksPreferences()
                    {
                        MobileOperatorNetworkId = new Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                        Priority = 0,
                    },
                },
                };
                result = await service.SetNetworkPreferenceAsync(id, baseOptions);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public MobileOperatorNetworksPreferencesRecord DeleteNetworkPreference()
        {
            MobileOperatorNetworksPreferencesRecord result = new MobileOperatorNetworksPreferencesRecord();

            try
            {
                result = service.DeleteNetworkPreference(id);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public async Task<MobileOperatorNetworksPreferencesRecord> DeleteNetworkPreferenceAsync()
        {
            MobileOperatorNetworksPreferencesRecord result = new MobileOperatorNetworksPreferencesRecord();

            try
            {
                result = await service.DeleteNetworkPreferenceAsync(id);
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return result;
        }
    }
}
