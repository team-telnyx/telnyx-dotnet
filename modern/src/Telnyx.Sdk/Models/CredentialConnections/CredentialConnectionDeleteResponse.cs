using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CredentialConnections;

[JsonConverter(typeof(JsonModelConverter<CredentialConnectionDeleteResponse, CredentialConnectionDeleteResponseFromRaw>))]
public sealed record class CredentialConnectionDeleteResponse : JsonModel
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

    public CredentialConnectionDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CredentialConnectionDeleteResponse (
        CredentialConnectionDeleteResponse credentialConnectionDeleteResponse
    ) : base(credentialConnectionDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public CredentialConnectionDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CredentialConnectionDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CredentialConnectionDeleteResponseFromRaw.FromRawUnchecked"/>
    public static CredentialConnectionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CredentialConnectionDeleteResponseFromRaw : IFromRawJson<CredentialConnectionDeleteResponse>
{
    /// <inheritdoc/>
    public CredentialConnectionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CredentialConnectionDeleteResponse.FromRawUnchecked(rawData);
}