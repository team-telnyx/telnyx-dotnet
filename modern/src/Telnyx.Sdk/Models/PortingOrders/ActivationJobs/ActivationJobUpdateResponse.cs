using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.ActivationJobs;

[JsonConverter(typeof(JsonModelConverter<ActivationJobUpdateResponse, ActivationJobUpdateResponseFromRaw>))]
public sealed record class ActivationJobUpdateResponse : JsonModel
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

    public ActivationJobUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivationJobUpdateResponse (
        ActivationJobUpdateResponse activationJobUpdateResponse
    ) : base(activationJobUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public ActivationJobUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivationJobUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActivationJobUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ActivationJobUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActivationJobUpdateResponseFromRaw : IFromRawJson<ActivationJobUpdateResponse>
{
    /// <inheritdoc/>
    public ActivationJobUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActivationJobUpdateResponse.FromRawUnchecked(rawData);
}