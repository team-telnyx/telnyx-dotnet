using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BillingGroups;

[JsonConverter(typeof(JsonModelConverter<BillingGroupRetrieveResponse, BillingGroupRetrieveResponseFromRaw>))]
public sealed record class BillingGroupRetrieveResponse : JsonModel
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

    public BillingGroupRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingGroupRetrieveResponse (
        BillingGroupRetrieveResponse billingGroupRetrieveResponse
    ) : base(billingGroupRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public BillingGroupRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingGroupRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BillingGroupRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static BillingGroupRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BillingGroupRetrieveResponseFromRaw : IFromRawJson<BillingGroupRetrieveResponse>
{
    /// <inheritdoc/>
    public BillingGroupRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BillingGroupRetrieveResponse.FromRawUnchecked(rawData);
}