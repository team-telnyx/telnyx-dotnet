using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections;

[JsonConverter(typeof(JsonModelConverter<ExternalConnectionUpdateResponse, ExternalConnectionUpdateResponseFromRaw>))]
public sealed record class ExternalConnectionUpdateResponse : JsonModel
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

    public ExternalConnectionUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalConnectionUpdateResponse (
        ExternalConnectionUpdateResponse externalConnectionUpdateResponse
    ) : base(externalConnectionUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public ExternalConnectionUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnectionUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExternalConnectionUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ExternalConnectionUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ExternalConnectionUpdateResponseFromRaw : IFromRawJson<ExternalConnectionUpdateResponse>
{
    /// <inheritdoc/>
    public ExternalConnectionUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExternalConnectionUpdateResponse.FromRawUnchecked(rawData);
}