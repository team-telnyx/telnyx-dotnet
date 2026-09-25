using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Verifications;

[JsonConverter(typeof(JsonModelConverter<VerificationRetrieveResponse, VerificationRetrieveResponseFromRaw>))]
public sealed record class VerificationRetrieveResponse : JsonModel
{
    public required Verification Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Verification>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public VerificationRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationRetrieveResponse (
        VerificationRetrieveResponse verificationRetrieveResponse
    ) : base(verificationRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public VerificationRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerificationRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static VerificationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public VerificationRetrieveResponse (Verification data) : this()
    { this.Data = data; }
}

class VerificationRetrieveResponseFromRaw : IFromRawJson<VerificationRetrieveResponse>
{
    /// <inheritdoc/>
    public VerificationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerificationRetrieveResponse.FromRawUnchecked(rawData);
}