using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIPHealthChecks;

[JsonConverter(typeof(JsonModelConverter<GlobalIPHealthCheckCreateResponse, GlobalIPHealthCheckCreateResponseFromRaw>))]
public sealed record class GlobalIPHealthCheckCreateResponse : JsonModel
{
    public GlobalIPHealthCheck? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GlobalIPHealthCheck>(
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

    public GlobalIPHealthCheckCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPHealthCheckCreateResponse (
        GlobalIPHealthCheckCreateResponse globalIPHealthCheckCreateResponse
    ) : base(globalIPHealthCheckCreateResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPHealthCheckCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPHealthCheckCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPHealthCheckCreateResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPHealthCheckCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPHealthCheckCreateResponseFromRaw : IFromRawJson<GlobalIPHealthCheckCreateResponse>
{
    /// <inheritdoc/>
    public GlobalIPHealthCheckCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPHealthCheckCreateResponse.FromRawUnchecked(rawData);
}