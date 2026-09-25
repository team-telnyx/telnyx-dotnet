using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BillingGroups;

[JsonConverter(typeof(JsonModelConverter<BillingGroupDeleteResponse, BillingGroupDeleteResponseFromRaw>))]
public sealed record class BillingGroupDeleteResponse : JsonModel
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

    public BillingGroupDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingGroupDeleteResponse (
        BillingGroupDeleteResponse billingGroupDeleteResponse
    ) : base(billingGroupDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public BillingGroupDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingGroupDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BillingGroupDeleteResponseFromRaw.FromRawUnchecked"/>
    public static BillingGroupDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BillingGroupDeleteResponseFromRaw : IFromRawJson<BillingGroupDeleteResponse>
{
    /// <inheritdoc/>
    public BillingGroupDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BillingGroupDeleteResponse.FromRawUnchecked(rawData);
}