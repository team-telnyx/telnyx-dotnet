using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MobilePushCredentials;

/// <summary>
/// Success response with details about a push credential
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PushCredentialResponse, PushCredentialResponseFromRaw>))]
public sealed record class PushCredentialResponse : JsonModel
{
    public PushCredential? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PushCredential>(
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

    public PushCredentialResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PushCredentialResponse (
        PushCredentialResponse pushCredentialResponse
    ) : base(pushCredentialResponse)
    {  }
    #pragma warning restore CS8618

    public PushCredentialResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PushCredentialResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PushCredentialResponseFromRaw.FromRawUnchecked"/>
    public static PushCredentialResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PushCredentialResponseFromRaw : IFromRawJson<PushCredentialResponse>
{
    /// <inheritdoc/>
    public PushCredentialResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PushCredentialResponse.FromRawUnchecked(rawData);
}