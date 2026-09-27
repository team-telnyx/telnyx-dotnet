using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIPHealthChecks;

[JsonConverter(typeof(JsonModelConverter<GlobalIPHealthCheckDeleteResponse, GlobalIPHealthCheckDeleteResponseFromRaw>))]
public sealed record class GlobalIPHealthCheckDeleteResponse : JsonModel
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

    public GlobalIPHealthCheckDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPHealthCheckDeleteResponse (
        GlobalIPHealthCheckDeleteResponse globalIPHealthCheckDeleteResponse
    ) : base(globalIPHealthCheckDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPHealthCheckDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPHealthCheckDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPHealthCheckDeleteResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPHealthCheckDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPHealthCheckDeleteResponseFromRaw : IFromRawJson<GlobalIPHealthCheckDeleteResponse>
{
    /// <inheritdoc/>
    public GlobalIPHealthCheckDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPHealthCheckDeleteResponse.FromRawUnchecked(rawData);
}