using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CredentialConnections;

[JsonConverter(typeof(JsonModelConverter<CredentialConnectionCreateResponse, CredentialConnectionCreateResponseFromRaw>))]
public sealed record class CredentialConnectionCreateResponse : JsonModel
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

    public CredentialConnectionCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CredentialConnectionCreateResponse (
        CredentialConnectionCreateResponse credentialConnectionCreateResponse
    ) : base(credentialConnectionCreateResponse)
    {  }
    #pragma warning restore CS8618

    public CredentialConnectionCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CredentialConnectionCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CredentialConnectionCreateResponseFromRaw.FromRawUnchecked"/>
    public static CredentialConnectionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CredentialConnectionCreateResponseFromRaw : IFromRawJson<CredentialConnectionCreateResponse>
{
    /// <inheritdoc/>
    public CredentialConnectionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CredentialConnectionCreateResponse.FromRawUnchecked(rawData);
}