using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.FqdnConnections;

[JsonConverter(typeof(JsonModelConverter<FqdnConnectionCreateResponse, FqdnConnectionCreateResponseFromRaw>))]
public sealed record class FqdnConnectionCreateResponse : JsonModel
{
    public FqdnConnection? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FqdnConnection>(
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

    public FqdnConnectionCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FqdnConnectionCreateResponse (
        FqdnConnectionCreateResponse fqdnConnectionCreateResponse
    ) : base(fqdnConnectionCreateResponse)
    {  }
    #pragma warning restore CS8618

    public FqdnConnectionCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FqdnConnectionCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FqdnConnectionCreateResponseFromRaw.FromRawUnchecked"/>
    public static FqdnConnectionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FqdnConnectionCreateResponseFromRaw : IFromRawJson<FqdnConnectionCreateResponse>
{
    /// <inheritdoc/>
    public FqdnConnectionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FqdnConnectionCreateResponse.FromRawUnchecked(rawData);
}