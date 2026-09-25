using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Porting.LoaConfigurations;

[JsonConverter(typeof(JsonModelConverter<LoaConfigurationCreateResponse, LoaConfigurationCreateResponseFromRaw>))]
public sealed record class LoaConfigurationCreateResponse : JsonModel
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

    public LoaConfigurationCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LoaConfigurationCreateResponse (
        LoaConfigurationCreateResponse loaConfigurationCreateResponse
    ) : base(loaConfigurationCreateResponse)
    {  }
    #pragma warning restore CS8618

    public LoaConfigurationCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LoaConfigurationCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LoaConfigurationCreateResponseFromRaw.FromRawUnchecked"/>
    public static LoaConfigurationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class LoaConfigurationCreateResponseFromRaw : IFromRawJson<LoaConfigurationCreateResponse>
{
    /// <inheritdoc/>
    public LoaConfigurationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LoaConfigurationCreateResponse.FromRawUnchecked(rawData);
}