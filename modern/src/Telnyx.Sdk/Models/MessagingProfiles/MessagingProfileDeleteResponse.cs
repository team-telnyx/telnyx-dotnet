using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingProfiles;

[JsonConverter(typeof(JsonModelConverter<MessagingProfileDeleteResponse, MessagingProfileDeleteResponseFromRaw>))]
public sealed record class MessagingProfileDeleteResponse : JsonModel
{
    public MessagingMessagingProfile? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingMessagingProfile>(
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

    public MessagingProfileDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingProfileDeleteResponse (
        MessagingProfileDeleteResponse messagingProfileDeleteResponse
    ) : base(messagingProfileDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingProfileDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingProfileDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingProfileDeleteResponseFromRaw.FromRawUnchecked"/>
    public static MessagingProfileDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingProfileDeleteResponseFromRaw : IFromRawJson<MessagingProfileDeleteResponse>
{
    /// <inheritdoc/>
    public MessagingProfileDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingProfileDeleteResponse.FromRawUnchecked(rawData);
}