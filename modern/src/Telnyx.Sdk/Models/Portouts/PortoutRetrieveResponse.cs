using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Portouts;

[JsonConverter(typeof(JsonModelConverter<PortoutRetrieveResponse, PortoutRetrieveResponseFromRaw>))]
public sealed record class PortoutRetrieveResponse : JsonModel
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

    public PortoutRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortoutRetrieveResponse (
        PortoutRetrieveResponse portoutRetrieveResponse
    ) : base(portoutRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public PortoutRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortoutRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortoutRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static PortoutRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortoutRetrieveResponseFromRaw : IFromRawJson<PortoutRetrieveResponse>
{
    /// <inheritdoc/>
    public PortoutRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortoutRetrieveResponse.FromRawUnchecked(rawData);
}