using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Addresses.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionValidateResponse, ActionValidateResponseFromRaw>))]
public sealed record class ActionValidateResponse : JsonModel
{
    public ActionValidateResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ActionValidateResponseData>(
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

    public ActionValidateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionValidateResponse (
        ActionValidateResponse actionValidateResponse
    ) : base(actionValidateResponse)
    {  }
    #pragma warning restore CS8618

    public ActionValidateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionValidateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionValidateResponseFromRaw.FromRawUnchecked"/>
    public static ActionValidateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionValidateResponseFromRaw : IFromRawJson<ActionValidateResponse>
{
    /// <inheritdoc/>
    public ActionValidateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionValidateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ActionValidateResponseData, ActionValidateResponseDataFromRaw>))]
public sealed record class ActionValidateResponseData : JsonModel
{
    /// <summary>
    /// Indicates whether an address is valid or invalid.
    /// </summary>
    public required ApiEnum<string, Result> Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Result>>(
                "result"
            );
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// Provides normalized address when available.
    /// </summary>
    public required Suggested Suggested {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Suggested>(
                "suggested"
            );
        }
        init { this._rawData.Set("suggested", value); }
    }

    public IReadOnlyList<ApiError>? Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiError>>(
                "errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiError>?>(
                "errors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Result.Validate();
        this.Suggested.Validate();
        foreach (var item in this.Errors ?? [])
        {
            item.Validate();
        }
        _ = this.RecordType;
    }

    public ActionValidateResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionValidateResponseData (
        ActionValidateResponseData actionValidateResponseData
    ) : base(actionValidateResponseData)
    {  }
    #pragma warning restore CS8618

    public ActionValidateResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionValidateResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionValidateResponseDataFromRaw.FromRawUnchecked"/>
    public static ActionValidateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ActionValidateResponseDataFromRaw : IFromRawJson<ActionValidateResponseData>
{
    /// <inheritdoc/>
    public ActionValidateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionValidateResponseData.FromRawUnchecked(rawData);
}/// <summary>
/// Indicates whether an address is valid or invalid.
/// </summary>
[JsonConverter(typeof(ResultConverter))]
public enum Result
{
    Valid, Invalid
}sealed class ResultConverter : JsonConverter<Result>
{
    public override Result Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "valid"=>Result.Valid, "invalid"=>Result.Invalid, _ =>(Result)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Result value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Result.Valid=>"valid",
            Result.Invalid=>"invalid",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Provides normalized address when available.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Suggested, SuggestedFromRaw>))]
public sealed record class Suggested : JsonModel
{
    /// <summary>
    /// The locality of the address. For US addresses, this corresponds to the state
    /// of the address.
    /// </summary>
    public string? AdministrativeArea {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "administrative_area"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("administrative_area", value);
        }
    }

    /// <summary>
    /// The two-character (ISO 3166-1 alpha-2) country code of the address.
    /// </summary>
    public string? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    /// <summary>
    /// Additional street address information about the address such as, but not limited
    /// to, unit number or apartment number.
    /// </summary>
    public string? ExtendedAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "extended_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("extended_address", value);
        }
    }

    /// <summary>
    /// The locality of the address. For US addresses, this corresponds to the city
    /// of the address.
    /// </summary>
    public string? Locality {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "locality"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("locality", value);
        }
    }

    /// <summary>
    /// The postal code of the address.
    /// </summary>
    public string? PostalCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "postal_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("postal_code", value);
        }
    }

    /// <summary>
    /// The primary street address information about the address.
    /// </summary>
    public string? StreetAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "street_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("street_address", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdministrativeArea;
        _ = this.CountryCode;
        _ = this.ExtendedAddress;
        _ = this.Locality;
        _ = this.PostalCode;
        _ = this.StreetAddress;
    }

    public Suggested ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Suggested (Suggested suggested) : base(suggested)
    {  }
    #pragma warning restore CS8618

    public Suggested (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Suggested (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SuggestedFromRaw.FromRawUnchecked"/>
    public static Suggested FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SuggestedFromRaw : IFromRawJson<Suggested>
{
    /// <inheritdoc/>
    public Suggested FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Suggested.FromRawUnchecked(rawData);
}