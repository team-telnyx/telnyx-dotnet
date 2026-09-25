using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Dir.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<RejectionReason, RejectionReasonFromRaw>))]
public sealed record class RejectionReason : JsonModel
{
    public string? Code {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    public string? Detail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "detail"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("detail", value);
        }
    }

    /// <summary>
    /// Customer-visible free-text comment from the Telnyx vetting team. Only the
    /// first entry of `rejection_reasons` carries this; the rest are `null`.
    /// </summary>
    public string? Message {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "message"
            );
        }
        init { this._rawData.Set("message", value); }
    }

    public string? Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "title"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Detail;
        _ = this.Message;
        _ = this.Title;
    }

    public RejectionReason ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RejectionReason (RejectionReason rejectionReason) : base(
        rejectionReason
    )
    {  }
    #pragma warning restore CS8618

    public RejectionReason (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RejectionReason (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RejectionReasonFromRaw.FromRawUnchecked"/>
    public static RejectionReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RejectionReasonFromRaw : IFromRawJson<RejectionReason>
{
    /// <inheritdoc/>
    public RejectionReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RejectionReason.FromRawUnchecked(rawData);
}