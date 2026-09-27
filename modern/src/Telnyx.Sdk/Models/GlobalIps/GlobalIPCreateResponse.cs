using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIps;

[JsonConverter(typeof(JsonModelConverter<GlobalIPCreateResponse, GlobalIPCreateResponseFromRaw>))]
public sealed record class GlobalIPCreateResponse : JsonModel
{
    public GlobalIP? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GlobalIP>(
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

    public GlobalIPCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPCreateResponse (
        GlobalIPCreateResponse globalIPCreateResponse
    ) : base(globalIPCreateResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPCreateResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPCreateResponseFromRaw : IFromRawJson<GlobalIPCreateResponse>
{
    /// <inheritdoc/>
    public GlobalIPCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPCreateResponse.FromRawUnchecked(rawData);
}