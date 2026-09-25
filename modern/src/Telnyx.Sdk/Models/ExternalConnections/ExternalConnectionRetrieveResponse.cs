using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections;

[JsonConverter(typeof(JsonModelConverter<ExternalConnectionRetrieveResponse, ExternalConnectionRetrieveResponseFromRaw>))]
public sealed record class ExternalConnectionRetrieveResponse : JsonModel
{
    public ExternalConnection? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExternalConnection>(
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

    public ExternalConnectionRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalConnectionRetrieveResponse (
        ExternalConnectionRetrieveResponse externalConnectionRetrieveResponse
    ) : base(externalConnectionRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ExternalConnectionRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnectionRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExternalConnectionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ExternalConnectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ExternalConnectionRetrieveResponseFromRaw : IFromRawJson<ExternalConnectionRetrieveResponse>
{
    /// <inheritdoc/>
    public ExternalConnectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExternalConnectionRetrieveResponse.FromRawUnchecked(rawData);
}