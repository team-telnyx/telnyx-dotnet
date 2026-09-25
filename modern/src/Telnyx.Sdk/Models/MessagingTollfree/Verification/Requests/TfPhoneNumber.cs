using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

/// <summary>
/// A phone number
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TfPhoneNumber, TfPhoneNumberFromRaw>))]
public sealed record class TfPhoneNumber : JsonModel
{
    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phoneNumber"
            );
        }
        init { this._rawData.Set("phoneNumber", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.PhoneNumber; }

    public TfPhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TfPhoneNumber (TfPhoneNumber tfPhoneNumber) : base(tfPhoneNumber)
    {  }
    #pragma warning restore CS8618

    public TfPhoneNumber (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TfPhoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TfPhoneNumberFromRaw.FromRawUnchecked"/>
    public static TfPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public TfPhoneNumber (string phoneNumber) : this()
    { this.PhoneNumber = phoneNumber; }
}

class TfPhoneNumberFromRaw : IFromRawJson<TfPhoneNumber>
{
    /// <inheritdoc/>
    public TfPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TfPhoneNumber.FromRawUnchecked(rawData);
}