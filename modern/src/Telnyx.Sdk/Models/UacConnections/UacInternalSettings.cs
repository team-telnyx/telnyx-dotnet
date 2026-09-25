using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.UacConnections;

/// <summary>
/// Internal Telnyx-side settings for a UAC connection.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UacInternalSettings, UacInternalSettingsFromRaw>))]
public sealed record class UacInternalSettings : JsonModel
{
    /// <summary>
    /// The SIP URI that Telnyx will call when handling an inbound request from the
    /// external peer. Do not include a `sip:` prefix. The value must be in the format
    /// `userinfo@&lt;subdomain.&gt;sip.telnyx.com` or `userinfo@&lt;subdomain.&gt;sipdev.telnyx.com`;
    /// the userinfo portion may contain only letters, digits, hyphens, and underscores.
    /// </summary>
    public string? DestinationUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "destination_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("destination_uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.DestinationUri; }

    public UacInternalSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UacInternalSettings (UacInternalSettings uacInternalSettings) : base(
        uacInternalSettings
    )
    {  }
    #pragma warning restore CS8618

    public UacInternalSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UacInternalSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UacInternalSettingsFromRaw.FromRawUnchecked"/>
    public static UacInternalSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UacInternalSettingsFromRaw : IFromRawJson<UacInternalSettings>
{
    /// <inheritdoc/>
    public UacInternalSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UacInternalSettings.FromRawUnchecked(rawData);
}