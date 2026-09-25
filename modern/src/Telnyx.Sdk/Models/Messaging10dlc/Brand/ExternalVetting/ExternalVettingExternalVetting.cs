using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand.ExternalVetting;

[JsonConverter(typeof(JsonModelConverter<ExternalVettingExternalVetting, ExternalVettingExternalVettingFromRaw>))]
public sealed record class ExternalVettingExternalVetting : JsonModel
{
    /// <summary>
    /// Vetting submission date. This is the date when the vetting request is generated
    /// in ISO 8601 format.
    /// </summary>
    public string? CreateDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "createDate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("createDate", value);
        }
    }

    /// <summary>
    /// External vetting provider ID for the brand.
    /// </summary>
    public string? EvpID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "evpId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("evpId", value);
        }
    }

    /// <summary>
    /// Vetting effective date. This is the date when vetting was completed, or the
    /// starting effective date in ISO 8601 format. If this date is missing, then
    /// the vetting was not complete or not valid.
    /// </summary>
    public string? VettedDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "vettedDate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("vettedDate", value);
        }
    }

    /// <summary>
    /// Identifies the vetting classification.
    /// </summary>
    public string? VettingClass {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "vettingClass"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("vettingClass", value);
        }
    }

    /// <summary>
    /// Unique ID that identifies a vetting transaction performed by a vetting provider.
    /// This ID is provided by the vetting provider at time of vetting.
    /// </summary>
    public string? VettingID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "vettingId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("vettingId", value);
        }
    }

    /// <summary>
    /// Vetting score ranging from 0-100.
    /// </summary>
    public long? VettingScore {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "vettingScore"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("vettingScore", value);
        }
    }

    /// <summary>
    /// Required by some providers for vetting record confirmation.
    /// </summary>
    public string? VettingToken {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "vettingToken"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("vettingToken", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreateDate;
        _ = this.EvpID;
        _ = this.VettedDate;
        _ = this.VettingClass;
        _ = this.VettingID;
        _ = this.VettingScore;
        _ = this.VettingToken;
    }

    public ExternalVettingExternalVetting ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalVettingExternalVetting (
        ExternalVettingExternalVetting externalVettingExternalVetting
    ) : base(externalVettingExternalVetting)
    {  }
    #pragma warning restore CS8618

    public ExternalVettingExternalVetting (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalVettingExternalVetting (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExternalVettingExternalVettingFromRaw.FromRawUnchecked"/>
    public static ExternalVettingExternalVetting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ExternalVettingExternalVettingFromRaw : IFromRawJson<ExternalVettingExternalVetting>
{
    /// <inheritdoc/>
    public ExternalVettingExternalVetting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExternalVettingExternalVetting.FromRawUnchecked(rawData);
}