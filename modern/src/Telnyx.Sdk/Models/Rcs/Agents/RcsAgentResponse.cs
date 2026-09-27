using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rcs.Agents;

[JsonConverter(typeof(JsonModelConverter<RcsAgentResponse, RcsAgentResponseFromRaw>))]
public sealed record class RcsAgentResponse : JsonModel
{
    public RcsAgent? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RcsAgent>(
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

    public RcsAgentResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcsAgentResponse (RcsAgentResponse rcsAgentResponse) : base(
        rcsAgentResponse
    )
    {  }
    #pragma warning restore CS8618

    public RcsAgentResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RcsAgentResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RcsAgentResponseFromRaw.FromRawUnchecked"/>
    public static RcsAgentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RcsAgentResponseFromRaw : IFromRawJson<RcsAgentResponse>
{
    /// <inheritdoc/>
    public RcsAgentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RcsAgentResponse.FromRawUnchecked(rawData);
}