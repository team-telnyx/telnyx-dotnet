using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingOptouts;

[JsonConverter(typeof(JsonModelConverter<MessagingOptoutListResponse, MessagingOptoutListResponseFromRaw>))]
public sealed record class MessagingOptoutListResponse : JsonModel
{
    /// <summary>
    /// The timestamp when the opt-out was created
    /// </summary>
    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Sending address (+E.164 formatted phone number, alphanumeric sender ID, or
    /// short code).
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// The keyword that triggered the opt-out.
    /// </summary>
    public string? Keyword {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "keyword"
            );
        }
        init { this._rawData.Set("keyword", value); }
    }

    /// <summary>
    /// Unique identifier for a messaging profile.
    /// </summary>
    public string? MessagingProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_profile_id"
            );
        }
        init { this._rawData.Set("messaging_profile_id", value); }
    }

    /// <summary>
    /// Receiving address (+E.164 formatted phone number or short code).
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.From;
        _ = this.Keyword;
        _ = this.MessagingProfileID;
        _ = this.To;
    }

    public MessagingOptoutListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingOptoutListResponse (
        MessagingOptoutListResponse messagingOptoutListResponse
    ) : base(messagingOptoutListResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingOptoutListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingOptoutListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingOptoutListResponseFromRaw.FromRawUnchecked"/>
    public static MessagingOptoutListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingOptoutListResponseFromRaw : IFromRawJson<MessagingOptoutListResponse>
{
    /// <inheritdoc/>
    public MessagingOptoutListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingOptoutListResponse.FromRawUnchecked(rawData);
}