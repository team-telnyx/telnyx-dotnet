using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Threads;

[JsonConverter(typeof(JsonModelConverter<ThreadRetrieveResponse, ThreadRetrieveResponseFromRaw>))]
public sealed record class ThreadRetrieveResponse : JsonModel
{
    public required InboundThreadDetail Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<InboundThreadDetail>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
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
        this.Data.Validate();
        this.Meta.Validate();
    }

    public ThreadRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThreadRetrieveResponse (
        ThreadRetrieveResponse threadRetrieveResponse
    ) : base(threadRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ThreadRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ThreadRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ThreadRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ThreadRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ThreadRetrieveResponseFromRaw : IFromRawJson<ThreadRetrieveResponse>
{
    /// <inheritdoc/>
    public ThreadRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ThreadRetrieveResponse.FromRawUnchecked(rawData);
}