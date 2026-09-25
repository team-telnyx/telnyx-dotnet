using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailUnsubscribeGroups;

[JsonConverter(typeof(JsonModelConverter<UnsubscribeGroupResponse, UnsubscribeGroupResponseFromRaw>))]
public sealed record class UnsubscribeGroupResponse : JsonModel
{
    public required UnsubscribeGroup Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UnsubscribeGroup>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public UnsubscribeGroupResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnsubscribeGroupResponse (
        UnsubscribeGroupResponse unsubscribeGroupResponse
    ) : base(unsubscribeGroupResponse)
    {  }
    #pragma warning restore CS8618

    public UnsubscribeGroupResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UnsubscribeGroupResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UnsubscribeGroupResponseFromRaw.FromRawUnchecked"/>
    public static UnsubscribeGroupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public UnsubscribeGroupResponse (UnsubscribeGroup data) : this()
    { this.Data = data; }
}

class UnsubscribeGroupResponseFromRaw : IFromRawJson<UnsubscribeGroupResponse>
{
    /// <inheritdoc/>
    public UnsubscribeGroupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UnsubscribeGroupResponse.FromRawUnchecked(rawData);
}