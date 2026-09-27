using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIps;

[JsonConverter(typeof(JsonModelConverter<GlobalIPRetrieveResponse, GlobalIPRetrieveResponseFromRaw>))]
public sealed record class GlobalIPRetrieveResponse : JsonModel
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

    public GlobalIPRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPRetrieveResponse (
        GlobalIPRetrieveResponse globalIPRetrieveResponse
    ) : base(globalIPRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPRetrieveResponseFromRaw : IFromRawJson<GlobalIPRetrieveResponse>
{
    /// <inheritdoc/>
    public GlobalIPRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPRetrieveResponse.FromRawUnchecked(rawData);
}