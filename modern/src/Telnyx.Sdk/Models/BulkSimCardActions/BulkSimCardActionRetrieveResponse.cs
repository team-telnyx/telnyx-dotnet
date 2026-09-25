using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BulkSimCardActions;

[JsonConverter(typeof(JsonModelConverter<BulkSimCardActionRetrieveResponse, BulkSimCardActionRetrieveResponseFromRaw>))]
public sealed record class BulkSimCardActionRetrieveResponse : JsonModel
{
    public BulkSimCardActionDetailed? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BulkSimCardActionDetailed>(
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

    public BulkSimCardActionRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BulkSimCardActionRetrieveResponse (
        BulkSimCardActionRetrieveResponse bulkSimCardActionRetrieveResponse
    ) : base(bulkSimCardActionRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public BulkSimCardActionRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkSimCardActionRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BulkSimCardActionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static BulkSimCardActionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BulkSimCardActionRetrieveResponseFromRaw : IFromRawJson<BulkSimCardActionRetrieveResponse>
{
    /// <inheritdoc/>
    public BulkSimCardActionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BulkSimCardActionRetrieveResponse.FromRawUnchecked(rawData);
}