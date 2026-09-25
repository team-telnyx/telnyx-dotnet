using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Verifications;

[JsonConverter(typeof(JsonModelConverter<CreateVerificationResponse, CreateVerificationResponseFromRaw>))]
public sealed record class CreateVerificationResponse : JsonModel
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

    public CreateVerificationResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateVerificationResponse (
        CreateVerificationResponse createVerificationResponse
    ) : base(createVerificationResponse)
    {  }
    #pragma warning restore CS8618

    public CreateVerificationResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateVerificationResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CreateVerificationResponseFromRaw.FromRawUnchecked"/>
    public static CreateVerificationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public CreateVerificationResponse (Verification data) : this()
    { this.Data = data; }
}

class CreateVerificationResponseFromRaw : IFromRawJson<CreateVerificationResponse>
{
    /// <inheritdoc/>
    public CreateVerificationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CreateVerificationResponse.FromRawUnchecked(rawData);
}