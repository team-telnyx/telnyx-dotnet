using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Wireless.ValidateSIMCardsRegistrationCodes;

namespace Telnyx.net.Services.Wireless.ValidateSIMCardsRegistrationCodes
{
    public class ValidateSIMCardsRegistrationCodeService : Service<ValidateSIMCardsRegistrationCode>
    {
        public override string BasePath => "/sim_cards/actions/validate_registration_codes";

        public async Task<ValidateSIMCardsRegistrationCode> CreateValidateSIMCardsRegistrationCodeAsync(UpsertValidateSIMCardsRegistrationCode options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public ValidateSIMCardsRegistrationCode CreateValidateSIMCardsRegistrationCode(UpsertValidateSIMCardsRegistrationCode options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }
    }
}
