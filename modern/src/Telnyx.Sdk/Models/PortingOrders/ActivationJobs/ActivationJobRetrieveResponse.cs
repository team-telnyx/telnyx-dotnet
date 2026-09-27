using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.ActivationJobs;

[JsonConverter(typeof(JsonModelConverter<ActivationJobRetrieveResponse, ActivationJobRetrieveResponseFromRaw>))]
public sealed record class ActivationJobRetrieveResponse : JsonModel
{
    public PortingOrdersActivationJob? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrdersActivationJob>(
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

    public ActivationJobRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivationJobRetrieveResponse (
        ActivationJobRetrieveResponse activationJobRetrieveResponse
    ) : base(activationJobRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ActivationJobRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivationJobRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActivationJobRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ActivationJobRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActivationJobRetrieveResponseFromRaw : IFromRawJson<ActivationJobRetrieveResponse>
{
    /// <inheritdoc/>
    public ActivationJobRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActivationJobRetrieveResponse.FromRawUnchecked(rawData);
}