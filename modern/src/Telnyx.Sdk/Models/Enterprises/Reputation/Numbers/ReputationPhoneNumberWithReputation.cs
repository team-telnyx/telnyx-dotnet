using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises.Reputation.Numbers;

[JsonConverter(typeof(JsonModelConverter<ReputationPhoneNumberWithReputation, ReputationPhoneNumberWithReputationFromRaw>))]
public sealed record class ReputationPhoneNumberWithReputation : JsonModel
{
    public required ReputationPhoneNumber Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReputationPhoneNumber>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public ReputationPhoneNumberWithReputation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReputationPhoneNumberWithReputation (
        ReputationPhoneNumberWithReputation reputationPhoneNumberWithReputation
    ) : base(reputationPhoneNumberWithReputation)
    {  }
    #pragma warning restore CS8618

    public ReputationPhoneNumberWithReputation (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReputationPhoneNumberWithReputation (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReputationPhoneNumberWithReputationFromRaw.FromRawUnchecked"/>
    public static ReputationPhoneNumberWithReputation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ReputationPhoneNumberWithReputation (
        ReputationPhoneNumber data
    ) : this()
    { this.Data = data; }
}

class ReputationPhoneNumberWithReputationFromRaw : IFromRawJson<ReputationPhoneNumberWithReputation>
{
    /// <inheritdoc/>
    public ReputationPhoneNumberWithReputation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReputationPhoneNumberWithReputation.FromRawUnchecked(rawData);
}