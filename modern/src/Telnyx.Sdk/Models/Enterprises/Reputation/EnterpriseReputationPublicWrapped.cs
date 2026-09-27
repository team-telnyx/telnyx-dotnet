using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises.Reputation;

[JsonConverter(typeof(JsonModelConverter<EnterpriseReputationPublicWrapped, EnterpriseReputationPublicWrappedFromRaw>))]
public sealed record class EnterpriseReputationPublicWrapped : JsonModel
{
    public required EnterpriseReputationPublic Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EnterpriseReputationPublic>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EnterpriseReputationPublicWrapped ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnterpriseReputationPublicWrapped (
        EnterpriseReputationPublicWrapped enterpriseReputationPublicWrapped
    ) : base(enterpriseReputationPublicWrapped)
    {  }
    #pragma warning restore CS8618

    public EnterpriseReputationPublicWrapped (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EnterpriseReputationPublicWrapped (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EnterpriseReputationPublicWrappedFromRaw.FromRawUnchecked"/>
    public static EnterpriseReputationPublicWrapped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EnterpriseReputationPublicWrapped (
        EnterpriseReputationPublic data
    ) : this()
    { this.Data = data; }
}

class EnterpriseReputationPublicWrappedFromRaw : IFromRawJson<EnterpriseReputationPublicWrapped>
{
    /// <inheritdoc/>
    public EnterpriseReputationPublicWrapped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EnterpriseReputationPublicWrapped.FromRawUnchecked(rawData);
}