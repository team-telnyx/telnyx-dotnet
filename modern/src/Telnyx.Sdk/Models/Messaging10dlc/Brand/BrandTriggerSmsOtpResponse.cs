using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

/// <summary>
/// Response after successfully triggering a Brand SMS OTP
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrandTriggerSmsOtpResponse, BrandTriggerSmsOtpResponseFromRaw>))]
public sealed record class BrandTriggerSmsOtpResponse : JsonModel
{
    /// <summary>
    /// The Brand ID for which the OTP was triggered
    /// </summary>
    public required string BrandID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "brandId"
            );
        }
        init { this._rawData.Set("brandId", value); }
    }

    /// <summary>
    /// The reference ID that can be used to check OTP status
    /// </summary>
    public required string ReferenceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "referenceId"
            );
        }
        init { this._rawData.Set("referenceId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.ReferenceID;
    }

    public BrandTriggerSmsOtpResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandTriggerSmsOtpResponse (
        BrandTriggerSmsOtpResponse brandTriggerSmsOtpResponse
    ) : base(brandTriggerSmsOtpResponse)
    {  }
    #pragma warning restore CS8618

    public BrandTriggerSmsOtpResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandTriggerSmsOtpResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandTriggerSmsOtpResponseFromRaw.FromRawUnchecked"/>
    public static BrandTriggerSmsOtpResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BrandTriggerSmsOtpResponseFromRaw : IFromRawJson<BrandTriggerSmsOtpResponse>
{
    /// <inheritdoc/>
    public BrandTriggerSmsOtpResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandTriggerSmsOtpResponse.FromRawUnchecked(rawData);
}