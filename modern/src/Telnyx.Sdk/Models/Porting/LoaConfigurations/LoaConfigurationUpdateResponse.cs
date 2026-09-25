using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Porting.LoaConfigurations;

[JsonConverter(typeof(JsonModelConverter<LoaConfigurationUpdateResponse, LoaConfigurationUpdateResponseFromRaw>))]
public sealed record class LoaConfigurationUpdateResponse : JsonModel
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

    public LoaConfigurationUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LoaConfigurationUpdateResponse (
        LoaConfigurationUpdateResponse loaConfigurationUpdateResponse
    ) : base(loaConfigurationUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public LoaConfigurationUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LoaConfigurationUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LoaConfigurationUpdateResponseFromRaw.FromRawUnchecked"/>
    public static LoaConfigurationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class LoaConfigurationUpdateResponseFromRaw : IFromRawJson<LoaConfigurationUpdateResponse>
{
    /// <inheritdoc/>
    public LoaConfigurationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LoaConfigurationUpdateResponse.FromRawUnchecked(rawData);
}