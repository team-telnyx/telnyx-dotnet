using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections;

[JsonConverter(typeof(JsonModelConverter<ExternalConnectionCreateResponse, ExternalConnectionCreateResponseFromRaw>))]
public sealed record class ExternalConnectionCreateResponse : JsonModel
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

    public ExternalConnectionCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalConnectionCreateResponse (
        ExternalConnectionCreateResponse externalConnectionCreateResponse
    ) : base(externalConnectionCreateResponse)
    {  }
    #pragma warning restore CS8618

    public ExternalConnectionCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnectionCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExternalConnectionCreateResponseFromRaw.FromRawUnchecked"/>
    public static ExternalConnectionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ExternalConnectionCreateResponseFromRaw : IFromRawJson<ExternalConnectionCreateResponse>
{
    /// <inheritdoc/>
    public ExternalConnectionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExternalConnectionCreateResponse.FromRawUnchecked(rawData);
}