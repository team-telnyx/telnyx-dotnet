using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.InboundChannels;

[JsonConverter(typeof(JsonModelConverter<InboundChannelListResponse, InboundChannelListResponseFromRaw>))]
public sealed record class InboundChannelListResponse : JsonModel
{
    public InboundChannelListResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InboundChannelListResponseData>(
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

    public InboundChannelListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundChannelListResponse (
        InboundChannelListResponse inboundChannelListResponse
    ) : base(inboundChannelListResponse)
    {  }
    #pragma warning restore CS8618

    public InboundChannelListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundChannelListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundChannelListResponseFromRaw.FromRawUnchecked"/>
    public static InboundChannelListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InboundChannelListResponseFromRaw : IFromRawJson<InboundChannelListResponse>
{
    /// <inheritdoc/>
    public InboundChannelListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboundChannelListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<InboundChannelListResponseData, InboundChannelListResponseDataFromRaw>))]
public sealed record class InboundChannelListResponseData : JsonModel
{
    /// <summary>
    /// The current number of concurrent channels set for the account
    /// </summary>
    public long? Channels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channels", value);
        }
    }

    /// <summary>
    /// Identifies the type of the response
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.RecordType;
    }

    public InboundChannelListResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundChannelListResponseData (
        InboundChannelListResponseData inboundChannelListResponseData
    ) : base(inboundChannelListResponseData)
    {  }
    #pragma warning restore CS8618

    public InboundChannelListResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundChannelListResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundChannelListResponseDataFromRaw.FromRawUnchecked"/>
    public static InboundChannelListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class InboundChannelListResponseDataFromRaw : IFromRawJson<InboundChannelListResponseData>
{
    /// <inheritdoc/>
    public InboundChannelListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboundChannelListResponseData.FromRawUnchecked(rawData);
}