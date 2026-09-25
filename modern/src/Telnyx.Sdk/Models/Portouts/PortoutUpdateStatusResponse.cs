using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Portouts;

[JsonConverter(typeof(JsonModelConverter<PortoutUpdateStatusResponse, PortoutUpdateStatusResponseFromRaw>))]
public sealed record class PortoutUpdateStatusResponse : JsonModel
{
    public PortoutDetails? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortoutDetails>(
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

    public PortoutUpdateStatusResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortoutUpdateStatusResponse (
        PortoutUpdateStatusResponse portoutUpdateStatusResponse
    ) : base(portoutUpdateStatusResponse)
    {  }
    #pragma warning restore CS8618

    public PortoutUpdateStatusResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortoutUpdateStatusResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortoutUpdateStatusResponseFromRaw.FromRawUnchecked"/>
    public static PortoutUpdateStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortoutUpdateStatusResponseFromRaw : IFromRawJson<PortoutUpdateStatusResponse>
{
    /// <inheritdoc/>
    public PortoutUpdateStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortoutUpdateStatusResponse.FromRawUnchecked(rawData);
}