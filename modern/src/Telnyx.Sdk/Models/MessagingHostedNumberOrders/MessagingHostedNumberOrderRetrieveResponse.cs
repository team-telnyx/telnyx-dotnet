using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingHostedNumberOrders;

[JsonConverter(typeof(JsonModelConverter<MessagingHostedNumberOrderRetrieveResponse, MessagingHostedNumberOrderRetrieveResponseFromRaw>))]
public sealed record class MessagingHostedNumberOrderRetrieveResponse : JsonModel
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

    public MessagingHostedNumberOrderRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingHostedNumberOrderRetrieveResponse (
        MessagingHostedNumberOrderRetrieveResponse messagingHostedNumberOrderRetrieveResponse
    ) : base(messagingHostedNumberOrderRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingHostedNumberOrderRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingHostedNumberOrderRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingHostedNumberOrderRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MessagingHostedNumberOrderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingHostedNumberOrderRetrieveResponseFromRaw : IFromRawJson<MessagingHostedNumberOrderRetrieveResponse>
{
    /// <inheritdoc/>
    public MessagingHostedNumberOrderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingHostedNumberOrderRetrieveResponse.FromRawUnchecked(rawData);
}