using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Threads;

[JsonConverter(typeof(JsonModelConverter<InboundThreadListResponse, InboundThreadListResponseFromRaw>))]
public sealed record class InboundThreadListResponse : JsonModel
{
    public required IReadOnlyList<InboundThread> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InboundThread>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<InboundThread>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required EmailPaginationMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailPaginationMeta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public InboundThreadListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundThreadListResponse (
        InboundThreadListResponse inboundThreadListResponse
    ) : base(inboundThreadListResponse)
    {  }
    #pragma warning restore CS8618

    public InboundThreadListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundThreadListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundThreadListResponseFromRaw.FromRawUnchecked"/>
    public static InboundThreadListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InboundThreadListResponseFromRaw : IFromRawJson<InboundThreadListResponse>
{
    /// <inheritdoc/>
    public InboundThreadListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboundThreadListResponse.FromRawUnchecked(rawData);
}