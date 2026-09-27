using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CredentialConnections;

[JsonConverter(typeof(JsonModelConverter<CredentialConnectionUpdateResponse, CredentialConnectionUpdateResponseFromRaw>))]
public sealed record class CredentialConnectionUpdateResponse : JsonModel
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

    public CredentialConnectionUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CredentialConnectionUpdateResponse (
        CredentialConnectionUpdateResponse credentialConnectionUpdateResponse
    ) : base(credentialConnectionUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public CredentialConnectionUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CredentialConnectionUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CredentialConnectionUpdateResponseFromRaw.FromRawUnchecked"/>
    public static CredentialConnectionUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CredentialConnectionUpdateResponseFromRaw : IFromRawJson<CredentialConnectionUpdateResponse>
{
    /// <inheritdoc/>
    public CredentialConnectionUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CredentialConnectionUpdateResponse.FromRawUnchecked(rawData);
}