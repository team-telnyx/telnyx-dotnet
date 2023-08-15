using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Connections;
using Telnyx.net.Entities.Connections.CredentialConnections;
using Telnyx.net.Entities.Connections.FQDNConnections;
using Telnyx.net.Entities.Connections.FQDNs;
using Telnyx.net.Entities.Connections.IPConnections;
using Telnyx.net.Entities.Connections.IPs;
using Telnyx.net.Entities.Enum.Connections;
using Telnyx.net.Services.Connections;
using Telnyx.net.Services.Connections.CredentialConnections;
using Telnyx.net.Services.Connections.FQDNConnections;
using Telnyx.net.Services.Connections.FQDNs;
using Telnyx.net.Services.Connections.IPConnections;
using Telnyx.net.Services.Connections.IPs;

namespace Telnyx.Example
{
    public class ConnectionsExample
    {
        private readonly ConnectionService connectionService = new ConnectionService();
        private readonly CredentialConnectionService credConnService = new CredentialConnectionService();
        private readonly FQDNConnectionService fqdnConnService = new FQDNConnectionService();
        private readonly IPConnectionService ipConnService = new IPConnectionService();
        private readonly FQDNService fQDNService = new FQDNService();
        private readonly IPService ipService = new IPService();

        public async Task<TelnyxList<Connection>> ListConnectionsAsync()
        {
            var options = new ConnectionListOptions
            {
                PageNumber = 1,
                PageSize = 2,
                Sort = ConnectionSort.ConnectionName,

            };
            var conns = await connectionService.ListConnectionsAsync(options);
            Console.WriteLine("Connections List Async: " + JsonConvert.SerializeObject(conns) + "\n");
            return conns;

        }
        public async Task<TelnyxList<CredentialConnection>> ListCredConnectionsAsync()
        {
            var options = new ConnectionListOptions
            {
                PageNumber = 1,
                PageSize = 2,
                Sort = ConnectionSort.ConnectionNameDESC,

            };
            var conns = await credConnService.ListCredentialConnectionAsync(options);
            Console.WriteLine("Credential Connections List Async: " + JsonConvert.SerializeObject(conns) + "\n");
            return conns;

        }
        public async Task<TelnyxList<FQDNConnection>> ListFQDNConnectionsAsync()
        {
            var options = new ConnectionListOptions
            {
                PageNumber = 1,
                PageSize = 2,
                Sort = ConnectionSort.Active,
                NumberOfPagesToFetch = 3

            };
            var conns = await fqdnConnService.ListFQDNConnectionAsync(options);
            Console.WriteLine("FQDN Connection List Async: " + JsonConvert.SerializeObject(conns) + "\n");
            return conns;

        }
        public async Task<TelnyxList<IPConnection>> ListIPConnectionsAsync()
        {
            var options = new ConnectionListOptions
            {
                PageNumber = 1,
                PageSize = 2,
                Sort = ConnectionSort.ActiveDESC,

            };
            var conns = await ipConnService.ListIPConnectionsAsync(options);
            Console.WriteLine("IP Connection List Async: " + JsonConvert.SerializeObject(conns) + "\n");
            return conns;

        }
        public async Task<TelnyxList<IP>> ListIPsAsync()
        {
            var options = new IPListOptions
            {
                PageNumber = 1,
                PageSize = 2,
            };
            var conns = await ipService.ListIPsAsync(options);
            Console.WriteLine("IP List Async: " + JsonConvert.SerializeObject(conns) + "\n");
            return conns;

        }
        public async Task<TelnyxList<FQDN>> ListFQDNsAsync()
        {
            var options = new FQDNListOptions
            {
                PageNumber = 1,
                PageSize = 2,
            };
            var conns = await fQDNService.ListFQDNsAsync(options);
            Console.WriteLine("FQDN List Async: " + JsonConvert.SerializeObject(conns) + "\n");
            return conns;

        }
    }
}
