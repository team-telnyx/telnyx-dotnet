using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.Releases;

[JsonConverter(typeof(JsonModelConverter<TnReleaseEntry, TnReleaseEntryFromRaw>))]
public sealed record class TnReleaseEntry : JsonModel
{
    /// <summary>
    /// Phone number ID from the Telnyx API.
    /// </summary>
    public string? NumberID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "number_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("number_id", value);
        }
    }

    /// <summary>
    /// Phone number in E164 format.
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NumberID;
        _ = this.PhoneNumber;
    }

    public TnReleaseEntry ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TnReleaseEntry (TnReleaseEntry tnReleaseEntry) : base(tnReleaseEntry)
    {  }
    #pragma warning restore CS8618

    public TnReleaseEntry (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TnReleaseEntry (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TnReleaseEntryFromRaw.FromRawUnchecked"/>
    public static TnReleaseEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TnReleaseEntryFromRaw : IFromRawJson<TnReleaseEntry>
{
    /// <inheritdoc/>
    public TnReleaseEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TnReleaseEntry.FromRawUnchecked(rawData);
}