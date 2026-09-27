using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.FqdnConnections.FqdnAuthentication;

[JsonConverter(typeof(JsonModelConverter<FqdnAuthenticationListResponse, FqdnAuthenticationListResponseFromRaw>))]
public sealed record class FqdnAuthenticationListResponse : JsonModel
{
    public FqdnAuthenticationFqdnAuthentication? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FqdnAuthenticationFqdnAuthentication>(
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

    public FqdnAuthenticationListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FqdnAuthenticationListResponse (
        FqdnAuthenticationListResponse fqdnAuthenticationListResponse
    ) : base(fqdnAuthenticationListResponse)
    {  }
    #pragma warning restore CS8618

    public FqdnAuthenticationListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FqdnAuthenticationListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FqdnAuthenticationListResponseFromRaw.FromRawUnchecked"/>
    public static FqdnAuthenticationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FqdnAuthenticationListResponseFromRaw : IFromRawJson<FqdnAuthenticationListResponse>
{
    /// <inheritdoc/>
    public FqdnAuthenticationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FqdnAuthenticationListResponse.FromRawUnchecked(rawData);
}