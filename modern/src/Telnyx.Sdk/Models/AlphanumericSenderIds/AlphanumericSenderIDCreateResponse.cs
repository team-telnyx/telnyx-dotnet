using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AlphanumericSenderIds;

[JsonConverter(typeof(JsonModelConverter<AlphanumericSenderIDCreateResponse, AlphanumericSenderIDCreateResponseFromRaw>))]
public sealed record class AlphanumericSenderIDCreateResponse : JsonModel
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

    public AlphanumericSenderIDCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AlphanumericSenderIDCreateResponse (
        AlphanumericSenderIDCreateResponse alphanumericSenderIDCreateResponse
    ) : base(alphanumericSenderIDCreateResponse)
    {  }
    #pragma warning restore CS8618

    public AlphanumericSenderIDCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AlphanumericSenderIDCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AlphanumericSenderIDCreateResponseFromRaw.FromRawUnchecked"/>
    public static AlphanumericSenderIDCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AlphanumericSenderIDCreateResponseFromRaw : IFromRawJson<AlphanumericSenderIDCreateResponse>
{
    /// <inheritdoc/>
    public AlphanumericSenderIDCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AlphanumericSenderIDCreateResponse.FromRawUnchecked(rawData);
}