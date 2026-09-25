using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VirtualCrossConnects;

[JsonConverter(typeof(JsonModelConverter<VirtualCrossConnectRetrieveResponse, VirtualCrossConnectRetrieveResponseFromRaw>))]
public sealed record class VirtualCrossConnectRetrieveResponse : JsonModel
{
    public VirtualCrossConnectCombined? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VirtualCrossConnectCombined>(
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

    public VirtualCrossConnectRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VirtualCrossConnectRetrieveResponse (
        VirtualCrossConnectRetrieveResponse virtualCrossConnectRetrieveResponse
    ) : base(virtualCrossConnectRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public VirtualCrossConnectRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VirtualCrossConnectRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VirtualCrossConnectRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static VirtualCrossConnectRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VirtualCrossConnectRetrieveResponseFromRaw : IFromRawJson<VirtualCrossConnectRetrieveResponse>
{
    /// <inheritdoc/>
    public VirtualCrossConnectRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VirtualCrossConnectRetrieveResponse.FromRawUnchecked(rawData);
}