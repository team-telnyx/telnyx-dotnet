using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VirtualCrossConnects;

[JsonConverter(typeof(JsonModelConverter<VirtualCrossConnectDeleteResponse, VirtualCrossConnectDeleteResponseFromRaw>))]
public sealed record class VirtualCrossConnectDeleteResponse : JsonModel
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

    public VirtualCrossConnectDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VirtualCrossConnectDeleteResponse (
        VirtualCrossConnectDeleteResponse virtualCrossConnectDeleteResponse
    ) : base(virtualCrossConnectDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public VirtualCrossConnectDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VirtualCrossConnectDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VirtualCrossConnectDeleteResponseFromRaw.FromRawUnchecked"/>
    public static VirtualCrossConnectDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VirtualCrossConnectDeleteResponseFromRaw : IFromRawJson<VirtualCrossConnectDeleteResponse>
{
    /// <inheritdoc/>
    public VirtualCrossConnectDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VirtualCrossConnectDeleteResponse.FromRawUnchecked(rawData);
}