using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Webhooks;

namespace Telnyx.Sdk.Models.EmailInboxes.Messages.Labels;

[JsonConverter(typeof(JsonModelConverter<LabelCreateResponse, LabelCreateResponseFromRaw>))]
public sealed record class LabelCreateResponse : JsonModel
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

    public LabelCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LabelCreateResponse (LabelCreateResponse labelCreateResponse) : base(
        labelCreateResponse
    )
    {  }
    #pragma warning restore CS8618

    public LabelCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LabelCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LabelCreateResponseFromRaw.FromRawUnchecked"/>
    public static LabelCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public LabelCreateResponse (InboundMessage data) : this()
    { this.Data = data; }
}

class LabelCreateResponseFromRaw : IFromRawJson<LabelCreateResponse>
{
    /// <inheritdoc/>
    public LabelCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LabelCreateResponse.FromRawUnchecked(rawData);
}