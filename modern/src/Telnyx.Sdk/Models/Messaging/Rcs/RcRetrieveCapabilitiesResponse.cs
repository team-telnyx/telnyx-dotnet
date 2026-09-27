using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging.Rcs;

[JsonConverter(typeof(JsonModelConverter<RcRetrieveCapabilitiesResponse, RcRetrieveCapabilitiesResponseFromRaw>))]
public sealed record class RcRetrieveCapabilitiesResponse : JsonModel
{
    public RcsCapabilities? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RcsCapabilities>(
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

    public RcRetrieveCapabilitiesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcRetrieveCapabilitiesResponse (
        RcRetrieveCapabilitiesResponse rcRetrieveCapabilitiesResponse
    ) : base(rcRetrieveCapabilitiesResponse)
    {  }
    #pragma warning restore CS8618

    public RcRetrieveCapabilitiesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RcRetrieveCapabilitiesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RcRetrieveCapabilitiesResponseFromRaw.FromRawUnchecked"/>
    public static RcRetrieveCapabilitiesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RcRetrieveCapabilitiesResponseFromRaw : IFromRawJson<RcRetrieveCapabilitiesResponse>
{
    /// <inheritdoc/>
    public RcRetrieveCapabilitiesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RcRetrieveCapabilitiesResponse.FromRawUnchecked(rawData);
}