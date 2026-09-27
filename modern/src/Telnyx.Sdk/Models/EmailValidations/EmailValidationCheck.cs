using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailValidations;

[JsonConverter(typeof(JsonModelConverter<EmailValidationCheck, EmailValidationCheckFromRaw>))]
public sealed record class EmailValidationCheck : JsonModel
{
    public required bool Pass {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "pass"
            );
        }
        init { this._rawData.Set("pass", value); }
    }

    /// <summary>
    /// Human-readable check detail. Omitted when nil.
    /// </summary>
    public string? Details {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "details"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("details", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Pass;
        _ = this.Details;
    }

    public EmailValidationCheck ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailValidationCheck (
        EmailValidationCheck emailValidationCheck
    ) : base(emailValidationCheck)
    {  }
    #pragma warning restore CS8618

    public EmailValidationCheck (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailValidationCheck (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailValidationCheckFromRaw.FromRawUnchecked"/>
    public static EmailValidationCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailValidationCheck (bool pass) : this()
    { this.Pass = pass; }
}

class EmailValidationCheckFromRaw : IFromRawJson<EmailValidationCheck>
{
    /// <inheritdoc/>
    public EmailValidationCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailValidationCheck.FromRawUnchecked(rawData);
}