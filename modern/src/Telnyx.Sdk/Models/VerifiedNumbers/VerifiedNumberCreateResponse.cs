using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VerifiedNumbers;

[JsonConverter(typeof(JsonModelConverter<VerifiedNumberCreateResponse, VerifiedNumberCreateResponseFromRaw>))]
public sealed record class VerifiedNumberCreateResponse : JsonModel
{
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    public string? VerificationMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "verification_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("verification_method", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PhoneNumber;
        _ = this.VerificationMethod;
    }

    public VerifiedNumberCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifiedNumberCreateResponse (
        VerifiedNumberCreateResponse verifiedNumberCreateResponse
    ) : base(verifiedNumberCreateResponse)
    {  }
    #pragma warning restore CS8618

    public VerifiedNumberCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifiedNumberCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifiedNumberCreateResponseFromRaw.FromRawUnchecked"/>
    public static VerifiedNumberCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VerifiedNumberCreateResponseFromRaw : IFromRawJson<VerifiedNumberCreateResponse>
{
    /// <inheritdoc/>
    public VerifiedNumberCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifiedNumberCreateResponse.FromRawUnchecked(rawData);
}