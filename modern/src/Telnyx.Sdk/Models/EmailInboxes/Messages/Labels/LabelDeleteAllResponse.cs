using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Webhooks;

namespace Telnyx.Sdk.Models.EmailInboxes.Messages.Labels;

[JsonConverter(typeof(JsonModelConverter<LabelDeleteAllResponse, LabelDeleteAllResponseFromRaw>))]
public sealed record class LabelDeleteAllResponse : JsonModel
{
    public required InboundMessage Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<InboundMessage>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public LabelDeleteAllResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LabelDeleteAllResponse (
        LabelDeleteAllResponse labelDeleteAllResponse
    ) : base(labelDeleteAllResponse)
    {  }
    #pragma warning restore CS8618

    public LabelDeleteAllResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LabelDeleteAllResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LabelDeleteAllResponseFromRaw.FromRawUnchecked"/>
    public static LabelDeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public LabelDeleteAllResponse (InboundMessage data) : this()
    { this.Data = data; }
}

class LabelDeleteAllResponseFromRaw : IFromRawJson<LabelDeleteAllResponse>
{
    /// <inheritdoc/>
    public LabelDeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LabelDeleteAllResponse.FromRawUnchecked(rawData);
}