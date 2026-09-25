using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberExtensions;

[JsonConverter(typeof(JsonModelConverter<PortingPhoneNumberExtension, PortingPhoneNumberExtensionFromRaw>))]
public sealed record class PortingPhoneNumberExtension : JsonModel
{
    /// <summary>
    /// Uniquely identifies this porting phone number extension.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Specifies the activation ranges for this porting phone number extension.
    /// The activation range must be within the extension range and should not overlap
    /// with other activation ranges.
    /// </summary>
    public IReadOnlyList<PortingPhoneNumberExtensionActivationRange>? ActivationRanges {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingPhoneNumberExtensionActivationRange>>(
                "activation_ranges"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingPhoneNumberExtensionActivationRange>?>(
                "activation_ranges",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
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
    /// Specifies the extension range for this porting phone number extension.
    /// </summary>
    public PortingPhoneNumberExtensionExtensionRange? ExtensionRange {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingPhoneNumberExtensionExtensionRange>(
                "extension_range"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("extension_range", value);
        }
    }

    /// <summary>
    /// Identifies the porting phone number associated with this porting phone number extension.
    /// </summary>
    public string? PortingPhoneNumberID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "porting_phone_number_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("porting_phone_number_id", value);
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
    /// ISO 8601 formatted date indicating when the resource was last updated.
    /// </summary>
    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.ActivationRanges ?? [])
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        this.ExtensionRange?.Validate();
        _ = this.PortingPhoneNumberID;
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public PortingPhoneNumberExtension ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingPhoneNumberExtension (
        PortingPhoneNumberExtension portingPhoneNumberExtension
    ) : base(portingPhoneNumberExtension)
    {  }
    #pragma warning restore CS8618

    public PortingPhoneNumberExtension (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingPhoneNumberExtension (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingPhoneNumberExtensionFromRaw.FromRawUnchecked"/>
    public static PortingPhoneNumberExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingPhoneNumberExtensionFromRaw : IFromRawJson<PortingPhoneNumberExtension>
{
    /// <inheritdoc/>
    public PortingPhoneNumberExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingPhoneNumberExtension.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PortingPhoneNumberExtensionActivationRange, PortingPhoneNumberExtensionActivationRangeFromRaw>))]
public sealed record class PortingPhoneNumberExtensionActivationRange : JsonModel
{
    /// <summary>
    /// Specifies the end of the activation range. It must be no more than the end
    /// of the extension range.
    /// </summary>
    public long? EndAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "end_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_at", value);
        }
    }

    /// <summary>
    /// Specifies the start of the activation range. Must be greater or equal the
    /// start of the extension range.
    /// </summary>
    public long? StartAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "start_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndAt;
        _ = this.StartAt;
    }

    public PortingPhoneNumberExtensionActivationRange ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingPhoneNumberExtensionActivationRange (
        PortingPhoneNumberExtensionActivationRange portingPhoneNumberExtensionActivationRange
    ) : base(portingPhoneNumberExtensionActivationRange)
    {  }
    #pragma warning restore CS8618

    public PortingPhoneNumberExtensionActivationRange (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingPhoneNumberExtensionActivationRange (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingPhoneNumberExtensionActivationRangeFromRaw.FromRawUnchecked"/>
    public static PortingPhoneNumberExtensionActivationRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingPhoneNumberExtensionActivationRangeFromRaw : IFromRawJson<PortingPhoneNumberExtensionActivationRange>
{
    /// <inheritdoc/>
    public PortingPhoneNumberExtensionActivationRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingPhoneNumberExtensionActivationRange.FromRawUnchecked(rawData);
}/// <summary>
/// Specifies the extension range for this porting phone number extension.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortingPhoneNumberExtensionExtensionRange, PortingPhoneNumberExtensionExtensionRangeFromRaw>))]
public sealed record class PortingPhoneNumberExtensionExtensionRange : JsonModel
{
    /// <summary>
    /// Specifies the end of the extension range for this porting phone number extension.
    /// </summary>
    public long? EndAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "end_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_at", value);
        }
    }

    /// <summary>
    /// Specifies the start of the extension range for this porting phone number extension.
    /// </summary>
    public long? StartAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "start_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndAt;
        _ = this.StartAt;
    }

    public PortingPhoneNumberExtensionExtensionRange ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingPhoneNumberExtensionExtensionRange (
        PortingPhoneNumberExtensionExtensionRange portingPhoneNumberExtensionExtensionRange
    ) : base(portingPhoneNumberExtensionExtensionRange)
    {  }
    #pragma warning restore CS8618

    public PortingPhoneNumberExtensionExtensionRange (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingPhoneNumberExtensionExtensionRange (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingPhoneNumberExtensionExtensionRangeFromRaw.FromRawUnchecked"/>
    public static PortingPhoneNumberExtensionExtensionRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingPhoneNumberExtensionExtensionRangeFromRaw : IFromRawJson<PortingPhoneNumberExtensionExtensionRange>
{
    /// <inheritdoc/>
    public PortingPhoneNumberExtensionExtensionRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingPhoneNumberExtensionExtensionRange.FromRawUnchecked(rawData);
}