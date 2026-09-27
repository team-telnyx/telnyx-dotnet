using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.FqdnConnections;

[JsonConverter(typeof(JsonModelConverter<FqdnConnectionUpdateResponse, FqdnConnectionUpdateResponseFromRaw>))]
public sealed record class FqdnConnectionUpdateResponse : JsonModel
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

    public FqdnConnectionUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FqdnConnectionUpdateResponse (
        FqdnConnectionUpdateResponse fqdnConnectionUpdateResponse
    ) : base(fqdnConnectionUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public FqdnConnectionUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FqdnConnectionUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FqdnConnectionUpdateResponseFromRaw.FromRawUnchecked"/>
    public static FqdnConnectionUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FqdnConnectionUpdateResponseFromRaw : IFromRawJson<FqdnConnectionUpdateResponse>
{
    /// <inheritdoc/>
    public FqdnConnectionUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FqdnConnectionUpdateResponse.FromRawUnchecked(rawData);
}