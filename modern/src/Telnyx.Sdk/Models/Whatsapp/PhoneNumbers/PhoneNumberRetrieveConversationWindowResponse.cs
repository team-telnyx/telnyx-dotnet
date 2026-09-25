using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberRetrieveConversationWindowResponse, PhoneNumberRetrieveConversationWindowResponseFromRaw>))]
public sealed record class PhoneNumberRetrieveConversationWindowResponse : JsonModel
{
    public PhoneNumberRetrieveConversationWindowResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneNumberRetrieveConversationWindowResponseData>(
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

    public PhoneNumberRetrieveConversationWindowResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberRetrieveConversationWindowResponse (
        PhoneNumberRetrieveConversationWindowResponse phoneNumberRetrieveConversationWindowResponse
    ) : base(phoneNumberRetrieveConversationWindowResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberRetrieveConversationWindowResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberRetrieveConversationWindowResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberRetrieveConversationWindowResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberRetrieveConversationWindowResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberRetrieveConversationWindowResponseFromRaw : IFromRawJson<PhoneNumberRetrieveConversationWindowResponse>
{
    /// <inheritdoc/>
    public PhoneNumberRetrieveConversationWindowResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberRetrieveConversationWindowResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PhoneNumberRetrieveConversationWindowResponseData, PhoneNumberRetrieveConversationWindowResponseDataFromRaw>))]
public sealed record class PhoneNumberRetrieveConversationWindowResponseData : JsonModel
{
    /// <summary>
    /// Timestamp of the last inbound message that opened the window
    /// </summary>
    public DateTimeOffset? LastUserMessageAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "last_user_message_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("last_user_message_at", value);
        }
    }

    /// <summary>
    /// Whether the 24-hour conversation window is currently open
    /// </summary>
    public bool? WindowActive {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "window_active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("window_active", value);
        }
    }

    /// <summary>
    /// When the window closes. Null if no active window.
    /// </summary>
    public DateTimeOffset? WindowExpiresAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "window_expires_at"
            );
        }
        init { this._rawData.Set("window_expires_at", value); }
    }

    /// <summary>
    /// Window type. Currently always 24h when present.
    /// </summary>
    public string? WindowType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "window_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("window_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LastUserMessageAt;
        _ = this.WindowActive;
        _ = this.WindowExpiresAt;
        _ = this.WindowType;
    }

    public PhoneNumberRetrieveConversationWindowResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberRetrieveConversationWindowResponseData (
        PhoneNumberRetrieveConversationWindowResponseData phoneNumberRetrieveConversationWindowResponseData
    ) : base(phoneNumberRetrieveConversationWindowResponseData)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberRetrieveConversationWindowResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberRetrieveConversationWindowResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberRetrieveConversationWindowResponseDataFromRaw.FromRawUnchecked"/>
    public static PhoneNumberRetrieveConversationWindowResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PhoneNumberRetrieveConversationWindowResponseDataFromRaw : IFromRawJson<PhoneNumberRetrieveConversationWindowResponseData>
{
    /// <inheritdoc/>
    public PhoneNumberRetrieveConversationWindowResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberRetrieveConversationWindowResponseData.FromRawUnchecked(rawData);
}