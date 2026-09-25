using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ReplacedLinkClick, ReplacedLinkClickFromRaw>))]
public sealed record class ReplacedLinkClick : JsonModel
{
    /// <summary>
    /// The message ID associated with the clicked link.
    /// </summary>
    public string? MessageID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "message_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("message_id", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
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

    /// <summary>
    /// ISO 8601 formatted date indicating when the message request was received.
    /// </summary>
    public DateTimeOffset? TimeClicked {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "time_clicked"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("time_clicked", value);
        }
    }

    /// <summary>
    /// Sending address (+E.164 formatted phone number, alphanumeric sender ID, or
    /// short code).
    /// </summary>
    public string? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <summary>
    /// The original link that was sent in the message.
    /// </summary>
    public string? Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MessageID;
        _ = this.RecordType;
        _ = this.TimeClicked;
        _ = this.To;
        _ = this.Url;
    }

    public ReplacedLinkClick ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacedLinkClick (ReplacedLinkClick replacedLinkClick) : base(
        replacedLinkClick
    )
    {  }
    #pragma warning restore CS8618

    public ReplacedLinkClick (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacedLinkClick (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReplacedLinkClickFromRaw.FromRawUnchecked"/>
    public static ReplacedLinkClick FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReplacedLinkClickFromRaw : IFromRawJson<ReplacedLinkClick>
{
    /// <inheritdoc/>
    public ReplacedLinkClick FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReplacedLinkClick.FromRawUnchecked(rawData);
}