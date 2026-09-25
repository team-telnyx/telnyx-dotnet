using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CredentialConnections;

[JsonConverter(typeof(JsonModelConverter<CredentialConnectionRetrieveResponse, CredentialConnectionRetrieveResponseFromRaw>))]
public sealed record class CredentialConnectionRetrieveResponse : JsonModel
{
    public CredentialConnection? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CredentialConnection>(
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

    public CredentialConnectionRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CredentialConnectionRetrieveResponse (
        CredentialConnectionRetrieveResponse credentialConnectionRetrieveResponse
    ) : base(credentialConnectionRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public CredentialConnectionRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CredentialConnectionRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CredentialConnectionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static CredentialConnectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CredentialConnectionRetrieveResponseFromRaw : IFromRawJson<CredentialConnectionRetrieveResponse>
{
    /// <inheritdoc/>
    public CredentialConnectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CredentialConnectionRetrieveResponse.FromRawUnchecked(rawData);
}