using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections;

[JsonConverter(typeof(JsonModelConverter<ExternalConnectionDeleteResponse, ExternalConnectionDeleteResponseFromRaw>))]
public sealed record class ExternalConnectionDeleteResponse : JsonModel
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

    public ExternalConnectionDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalConnectionDeleteResponse (
        ExternalConnectionDeleteResponse externalConnectionDeleteResponse
    ) : base(externalConnectionDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public ExternalConnectionDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnectionDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExternalConnectionDeleteResponseFromRaw.FromRawUnchecked"/>
    public static ExternalConnectionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ExternalConnectionDeleteResponseFromRaw : IFromRawJson<ExternalConnectionDeleteResponse>
{
    /// <inheritdoc/>
    public ExternalConnectionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExternalConnectionDeleteResponse.FromRawUnchecked(rawData);
}