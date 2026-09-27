using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.FqdnConnections;

[JsonConverter(typeof(JsonModelConverter<FqdnConnectionDeleteResponse, FqdnConnectionDeleteResponseFromRaw>))]
public sealed record class FqdnConnectionDeleteResponse : JsonModel
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

    public FqdnConnectionDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FqdnConnectionDeleteResponse (
        FqdnConnectionDeleteResponse fqdnConnectionDeleteResponse
    ) : base(fqdnConnectionDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public FqdnConnectionDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FqdnConnectionDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FqdnConnectionDeleteResponseFromRaw.FromRawUnchecked"/>
    public static FqdnConnectionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FqdnConnectionDeleteResponseFromRaw : IFromRawJson<FqdnConnectionDeleteResponse>
{
    /// <inheritdoc/>
    public FqdnConnectionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FqdnConnectionDeleteResponse.FromRawUnchecked(rawData);
}