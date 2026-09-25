using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WellKnown;

[JsonConverter(typeof(JsonModelConverter<WellKnownRetrieveProtectedResourceMetadataResponse, WellKnownRetrieveProtectedResourceMetadataResponseFromRaw>))]
public sealed record class WellKnownRetrieveProtectedResourceMetadataResponse : JsonModel
{
    /// <summary>
    /// List of authorization server URLs
    /// </summary>
    public IReadOnlyList<string>? AuthorizationServers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "authorization_servers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "authorization_servers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Protected resource URL
    /// </summary>
    public string? Resource {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "resource"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("resource", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthorizationServers;
        _ = this.Resource;
    }

    public WellKnownRetrieveProtectedResourceMetadataResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WellKnownRetrieveProtectedResourceMetadataResponse (
        WellKnownRetrieveProtectedResourceMetadataResponse wellKnownRetrieveProtectedResourceMetadataResponse
    ) : base(wellKnownRetrieveProtectedResourceMetadataResponse)
    {  }
    #pragma warning restore CS8618

    public WellKnownRetrieveProtectedResourceMetadataResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WellKnownRetrieveProtectedResourceMetadataResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WellKnownRetrieveProtectedResourceMetadataResponseFromRaw.FromRawUnchecked"/>
    public static WellKnownRetrieveProtectedResourceMetadataResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WellKnownRetrieveProtectedResourceMetadataResponseFromRaw : IFromRawJson<WellKnownRetrieveProtectedResourceMetadataResponse>
{
    /// <inheritdoc/>
    public WellKnownRetrieveProtectedResourceMetadataResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WellKnownRetrieveProtectedResourceMetadataResponse.FromRawUnchecked(rawData);
}