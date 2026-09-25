using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BillingGroups;

[JsonConverter(typeof(JsonModelConverter<BillingGroupUpdateResponse, BillingGroupUpdateResponseFromRaw>))]
public sealed record class BillingGroupUpdateResponse : JsonModel
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

    public BillingGroupUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingGroupUpdateResponse (
        BillingGroupUpdateResponse billingGroupUpdateResponse
    ) : base(billingGroupUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public BillingGroupUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingGroupUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BillingGroupUpdateResponseFromRaw.FromRawUnchecked"/>
    public static BillingGroupUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BillingGroupUpdateResponseFromRaw : IFromRawJson<BillingGroupUpdateResponse>
{
    /// <inheritdoc/>
    public BillingGroupUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BillingGroupUpdateResponse.FromRawUnchecked(rawData);
}