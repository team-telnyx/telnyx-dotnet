using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingHostedNumbers;

[JsonConverter(typeof(JsonModelConverter<UpdatePhoneNumberMessagingSettingsRequest, UpdatePhoneNumberMessagingSettingsRequestFromRaw>))]
public sealed record class UpdatePhoneNumberMessagingSettingsRequest : JsonModel
{
    /// <summary>
    /// Configure the messaging product for this number:
    ///
    /// <para>* Omit this field or set its value to `null` to keep the current value.
    /// * Set this field to a quoted product ID to set this phone number to that product</para>
    /// </summary>
    public string? MessagingProduct {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_product"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_product", value);
        }
    }

    /// <summary>
    /// Configure the messaging profile this phone number is assigned to:
    ///
    /// <para>* Omit this field or set its value to `null` to keep the current value.
    /// * Set this field to `""` to unassign the number from its messaging profile
    /// * Set this field to a quoted UUID of a messaging profile to assign this number
    /// to that messaging profile</para>
    /// </summary>
    public string? MessagingProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_profile_id", value);
        }
    }

    /// <summary>
    /// Tags to set on this phone number.
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MessagingProduct;
        _ = this.MessagingProfileID;
        _ = this.Tags;
    }

    public UpdatePhoneNumberMessagingSettingsRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdatePhoneNumberMessagingSettingsRequest (
        UpdatePhoneNumberMessagingSettingsRequest updatePhoneNumberMessagingSettingsRequest
    ) : base(updatePhoneNumberMessagingSettingsRequest)
    {  }
    #pragma warning restore CS8618

    public UpdatePhoneNumberMessagingSettingsRequest (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdatePhoneNumberMessagingSettingsRequest (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UpdatePhoneNumberMessagingSettingsRequestFromRaw.FromRawUnchecked"/>
    public static UpdatePhoneNumberMessagingSettingsRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UpdatePhoneNumberMessagingSettingsRequestFromRaw : IFromRawJson<UpdatePhoneNumberMessagingSettingsRequest>
{
    /// <inheritdoc/>
    public UpdatePhoneNumberMessagingSettingsRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UpdatePhoneNumberMessagingSettingsRequest.FromRawUnchecked(rawData);
}