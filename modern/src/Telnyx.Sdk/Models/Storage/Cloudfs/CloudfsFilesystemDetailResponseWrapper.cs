using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Cloudfs;

[JsonConverter(typeof(JsonModelConverter<CloudfsFilesystemDetailResponseWrapper, CloudfsFilesystemDetailResponseWrapperFromRaw>))]
public sealed record class CloudfsFilesystemDetailResponseWrapper : JsonModel
{
    /// <summary>
    /// A CloudFS filesystem as returned by get, update, and delete. `meta_url` omits
    /// the credential and there is no `meta_token` field — the token is only returned
    /// by create and rotate-meta-token.
    /// </summary>
    public CloudfsFilesystemDetail? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CloudfsFilesystemDetail>(
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

    public CloudfsFilesystemDetailResponseWrapper ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudfsFilesystemDetailResponseWrapper (
        CloudfsFilesystemDetailResponseWrapper cloudfsFilesystemDetailResponseWrapper
    ) : base(cloudfsFilesystemDetailResponseWrapper)
    {  }
    #pragma warning restore CS8618

    public CloudfsFilesystemDetailResponseWrapper (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudfsFilesystemDetailResponseWrapper (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CloudfsFilesystemDetailResponseWrapperFromRaw.FromRawUnchecked"/>
    public static CloudfsFilesystemDetailResponseWrapper FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CloudfsFilesystemDetailResponseWrapperFromRaw : IFromRawJson<CloudfsFilesystemDetailResponseWrapper>
{
    /// <inheritdoc/>
    public CloudfsFilesystemDetailResponseWrapper FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CloudfsFilesystemDetailResponseWrapper.FromRawUnchecked(rawData);
}