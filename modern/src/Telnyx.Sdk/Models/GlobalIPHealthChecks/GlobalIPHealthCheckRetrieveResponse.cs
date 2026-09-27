using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIPHealthChecks;

[JsonConverter(typeof(JsonModelConverter<GlobalIPHealthCheckRetrieveResponse, GlobalIPHealthCheckRetrieveResponseFromRaw>))]
public sealed record class GlobalIPHealthCheckRetrieveResponse : JsonModel
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

    public GlobalIPHealthCheckRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPHealthCheckRetrieveResponse (
        GlobalIPHealthCheckRetrieveResponse globalIPHealthCheckRetrieveResponse
    ) : base(globalIPHealthCheckRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPHealthCheckRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPHealthCheckRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPHealthCheckRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPHealthCheckRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPHealthCheckRetrieveResponseFromRaw : IFromRawJson<GlobalIPHealthCheckRetrieveResponse>
{
    /// <inheritdoc/>
    public GlobalIPHealthCheckRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPHealthCheckRetrieveResponse.FromRawUnchecked(rawData);
}