using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AlphanumericSenderIds;

[JsonConverter(typeof(JsonModelConverter<AlphanumericSenderIDDeleteResponse, AlphanumericSenderIDDeleteResponseFromRaw>))]
public sealed record class AlphanumericSenderIDDeleteResponse : JsonModel
{
    public AlphanumericSenderID? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AlphanumericSenderID>(
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

    public AlphanumericSenderIDDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AlphanumericSenderIDDeleteResponse (
        AlphanumericSenderIDDeleteResponse alphanumericSenderIDDeleteResponse
    ) : base(alphanumericSenderIDDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public AlphanumericSenderIDDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AlphanumericSenderIDDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AlphanumericSenderIDDeleteResponseFromRaw.FromRawUnchecked"/>
    public static AlphanumericSenderIDDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AlphanumericSenderIDDeleteResponseFromRaw : IFromRawJson<AlphanumericSenderIDDeleteResponse>
{
    /// <inheritdoc/>
    public AlphanumericSenderIDDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AlphanumericSenderIDDeleteResponse.FromRawUnchecked(rawData);
}