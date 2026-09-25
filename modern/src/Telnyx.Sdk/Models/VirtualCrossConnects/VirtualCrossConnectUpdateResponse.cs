using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VirtualCrossConnects;

[JsonConverter(typeof(JsonModelConverter<VirtualCrossConnectUpdateResponse, VirtualCrossConnectUpdateResponseFromRaw>))]
public sealed record class VirtualCrossConnectUpdateResponse : JsonModel
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

    public VirtualCrossConnectUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VirtualCrossConnectUpdateResponse (
        VirtualCrossConnectUpdateResponse virtualCrossConnectUpdateResponse
    ) : base(virtualCrossConnectUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public VirtualCrossConnectUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VirtualCrossConnectUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VirtualCrossConnectUpdateResponseFromRaw.FromRawUnchecked"/>
    public static VirtualCrossConnectUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VirtualCrossConnectUpdateResponseFromRaw : IFromRawJson<VirtualCrossConnectUpdateResponse>
{
    /// <inheritdoc/>
    public VirtualCrossConnectUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VirtualCrossConnectUpdateResponse.FromRawUnchecked(rawData);
}