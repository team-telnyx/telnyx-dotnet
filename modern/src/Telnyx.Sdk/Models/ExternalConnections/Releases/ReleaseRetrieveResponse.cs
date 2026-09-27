using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.Releases;

[JsonConverter(typeof(JsonModelConverter<ReleaseRetrieveResponse, ReleaseRetrieveResponseFromRaw>))]
public sealed record class ReleaseRetrieveResponse : JsonModel
{
    public Release? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Release>(
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

    public ReleaseRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReleaseRetrieveResponse (
        ReleaseRetrieveResponse releaseRetrieveResponse
    ) : base(releaseRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ReleaseRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReleaseRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReleaseRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ReleaseRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReleaseRetrieveResponseFromRaw : IFromRawJson<ReleaseRetrieveResponse>
{
    /// <inheritdoc/>
    public ReleaseRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReleaseRetrieveResponse.FromRawUnchecked(rawData);
}