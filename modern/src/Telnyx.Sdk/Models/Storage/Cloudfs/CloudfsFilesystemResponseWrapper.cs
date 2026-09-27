using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Cloudfs;

[JsonConverter(typeof(JsonModelConverter<CloudfsFilesystemResponseWrapper, CloudfsFilesystemResponseWrapperFromRaw>))]
public sealed record class CloudfsFilesystemResponseWrapper : JsonModel
{
    /// <summary>
    /// A CloudFS filesystem, including its metadata credential. This shape is returned
    /// only by create and rotate-meta-token.
    /// </summary>
    public CloudfsFilesystem? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CloudfsFilesystem>(
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

    public CloudfsFilesystemResponseWrapper ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudfsFilesystemResponseWrapper (
        CloudfsFilesystemResponseWrapper cloudfsFilesystemResponseWrapper
    ) : base(cloudfsFilesystemResponseWrapper)
    {  }
    #pragma warning restore CS8618

    public CloudfsFilesystemResponseWrapper (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudfsFilesystemResponseWrapper (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CloudfsFilesystemResponseWrapperFromRaw.FromRawUnchecked"/>
    public static CloudfsFilesystemResponseWrapper FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CloudfsFilesystemResponseWrapperFromRaw : IFromRawJson<CloudfsFilesystemResponseWrapper>
{
    /// <inheritdoc/>
    public CloudfsFilesystemResponseWrapper FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CloudfsFilesystemResponseWrapper.FromRawUnchecked(rawData);
}