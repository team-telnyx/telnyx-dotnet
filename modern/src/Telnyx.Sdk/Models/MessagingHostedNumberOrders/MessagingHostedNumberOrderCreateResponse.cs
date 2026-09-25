using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingHostedNumberOrders;

[JsonConverter(typeof(JsonModelConverter<MessagingHostedNumberOrderCreateResponse, MessagingHostedNumberOrderCreateResponseFromRaw>))]
public sealed record class MessagingHostedNumberOrderCreateResponse : JsonModel
{
    public MessagingHostedNumberOrder? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingHostedNumberOrder>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public MessagingHostedNumberOrderCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingHostedNumberOrderCreateResponse (
        MessagingHostedNumberOrderCreateResponse messagingHostedNumberOrderCreateResponse
    ) : base(messagingHostedNumberOrderCreateResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingHostedNumberOrderCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingHostedNumberOrderCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingHostedNumberOrderCreateResponseFromRaw.FromRawUnchecked"/>
    public static MessagingHostedNumberOrderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingHostedNumberOrderCreateResponseFromRaw : IFromRawJson<MessagingHostedNumberOrderCreateResponse>
{
    /// <inheritdoc/>
    public MessagingHostedNumberOrderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingHostedNumberOrderCreateResponse.FromRawUnchecked(rawData);
}