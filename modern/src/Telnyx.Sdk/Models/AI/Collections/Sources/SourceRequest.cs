using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Collections.Sources;

[JsonConverter(typeof(JsonModelConverter<SourceRequest, SourceRequestFromRaw>))]
public sealed record class SourceRequest : JsonModel
{
    /// <summary>
    /// The type of Telnyx data attached as a source. `bucket` requires an additional
    /// `bucket_id`. Only `voice` is searchable today; `meeting_bot`, `message`, and
    /// `bucket` attach but are not yet searchable (Coming soon).
    /// </summary>
    public required ApiEnum<string, SourceType> SourceType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SourceType>>(
                "source_type"
            );
        }
        init { this._rawData.Set("source_type", value); }
    }

    /// <summary>
    /// The Telnyx Storage bucket name. Required when `source_type` is `bucket`;
    /// ignored otherwise.
    /// </summary>
    public string? BucketID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "bucket_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bucket_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.SourceType.Validate();
        _ = this.BucketID;
    }

    public SourceRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SourceRequest (SourceRequest sourceRequest) : base(sourceRequest)
    {  }
    #pragma warning restore CS8618

    public SourceRequest (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SourceRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SourceRequestFromRaw.FromRawUnchecked"/>
    public static SourceRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public SourceRequest (ApiEnum<string, SourceType> sourceType) : this()
    { this.SourceType = sourceType; }
}

class SourceRequestFromRaw : IFromRawJson<SourceRequest>
{
    /// <inheritdoc/>
    public SourceRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SourceRequest.FromRawUnchecked(rawData);
}