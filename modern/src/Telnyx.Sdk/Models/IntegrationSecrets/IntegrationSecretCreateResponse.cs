using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.IntegrationSecrets;

[JsonConverter(typeof(JsonModelConverter<IntegrationSecretCreateResponse, IntegrationSecretCreateResponseFromRaw>))]
public sealed record class IntegrationSecretCreateResponse : JsonModel
{
    public required IntegrationSecret Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<IntegrationSecret>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public IntegrationSecretCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationSecretCreateResponse (
        IntegrationSecretCreateResponse integrationSecretCreateResponse
    ) : base(integrationSecretCreateResponse)
    {  }
    #pragma warning restore CS8618

    public IntegrationSecretCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationSecretCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationSecretCreateResponseFromRaw.FromRawUnchecked"/>
    public static IntegrationSecretCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public IntegrationSecretCreateResponse (IntegrationSecret data) : this()
    { this.Data = data; }
}

class IntegrationSecretCreateResponseFromRaw : IFromRawJson<IntegrationSecretCreateResponse>
{
    /// <inheritdoc/>
    public IntegrationSecretCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IntegrationSecretCreateResponse.FromRawUnchecked(rawData);
}