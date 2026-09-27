using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingProfiles.AutorespConfigs;

[JsonConverter(typeof(JsonModelConverter<AutoRespConfigResponse, AutoRespConfigResponseFromRaw>))]
public sealed record class AutoRespConfigResponse : JsonModel
{
    public required AutoRespConfig Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AutoRespConfig>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public AutoRespConfigResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutoRespConfigResponse (
        AutoRespConfigResponse autoRespConfigResponse
    ) : base(autoRespConfigResponse)
    {  }
    #pragma warning restore CS8618

    public AutoRespConfigResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoRespConfigResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AutoRespConfigResponseFromRaw.FromRawUnchecked"/>
    public static AutoRespConfigResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AutoRespConfigResponse (AutoRespConfig data) : this()
    { this.Data = data; }
}

class AutoRespConfigResponseFromRaw : IFromRawJson<AutoRespConfigResponse>
{
    /// <inheritdoc/>
    public AutoRespConfigResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AutoRespConfigResponse.FromRawUnchecked(rawData);
}