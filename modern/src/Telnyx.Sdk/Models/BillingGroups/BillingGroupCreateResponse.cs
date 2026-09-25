using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BillingGroups;

[JsonConverter(typeof(JsonModelConverter<BillingGroupCreateResponse, BillingGroupCreateResponseFromRaw>))]
public sealed record class BillingGroupCreateResponse : JsonModel
{
    public BillingGroup? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BillingGroup>(
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

    public BillingGroupCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingGroupCreateResponse (
        BillingGroupCreateResponse billingGroupCreateResponse
    ) : base(billingGroupCreateResponse)
    {  }
    #pragma warning restore CS8618

    public BillingGroupCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingGroupCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BillingGroupCreateResponseFromRaw.FromRawUnchecked"/>
    public static BillingGroupCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BillingGroupCreateResponseFromRaw : IFromRawJson<BillingGroupCreateResponse>
{
    /// <inheritdoc/>
    public BillingGroupCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BillingGroupCreateResponse.FromRawUnchecked(rawData);
}