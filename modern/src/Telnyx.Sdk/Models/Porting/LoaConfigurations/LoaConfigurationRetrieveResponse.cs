using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Porting.LoaConfigurations;

[JsonConverter(typeof(JsonModelConverter<LoaConfigurationRetrieveResponse, LoaConfigurationRetrieveResponseFromRaw>))]
public sealed record class LoaConfigurationRetrieveResponse : JsonModel
{
    public PortingLoaConfiguration? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingLoaConfiguration>(
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

    public LoaConfigurationRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LoaConfigurationRetrieveResponse (
        LoaConfigurationRetrieveResponse loaConfigurationRetrieveResponse
    ) : base(loaConfigurationRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public LoaConfigurationRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LoaConfigurationRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LoaConfigurationRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static LoaConfigurationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class LoaConfigurationRetrieveResponseFromRaw : IFromRawJson<LoaConfigurationRetrieveResponse>
{
    /// <inheritdoc/>
    public LoaConfigurationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LoaConfigurationRetrieveResponse.FromRawUnchecked(rawData);
}