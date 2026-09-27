using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIps;

[JsonConverter(typeof(JsonModelConverter<GlobalIPDeleteResponse, GlobalIPDeleteResponseFromRaw>))]
public sealed record class GlobalIPDeleteResponse : JsonModel
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

    public GlobalIPDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPDeleteResponse (
        GlobalIPDeleteResponse globalIPDeleteResponse
    ) : base(globalIPDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPDeleteResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPDeleteResponseFromRaw : IFromRawJson<GlobalIPDeleteResponse>
{
    /// <inheritdoc/>
    public GlobalIPDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPDeleteResponse.FromRawUnchecked(rawData);
}