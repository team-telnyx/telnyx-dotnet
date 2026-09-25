using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingHostedNumbers;

[JsonConverter(typeof(JsonModelConverter<MessagingHostedNumberDeleteResponse, MessagingHostedNumberDeleteResponseFromRaw>))]
public sealed record class MessagingHostedNumberDeleteResponse : JsonModel
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

    public MessagingHostedNumberDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingHostedNumberDeleteResponse (
        MessagingHostedNumberDeleteResponse messagingHostedNumberDeleteResponse
    ) : base(messagingHostedNumberDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingHostedNumberDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingHostedNumberDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingHostedNumberDeleteResponseFromRaw.FromRawUnchecked"/>
    public static MessagingHostedNumberDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingHostedNumberDeleteResponseFromRaw : IFromRawJson<MessagingHostedNumberDeleteResponse>
{
    /// <inheritdoc/>
    public MessagingHostedNumberDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingHostedNumberDeleteResponse.FromRawUnchecked(rawData);
}