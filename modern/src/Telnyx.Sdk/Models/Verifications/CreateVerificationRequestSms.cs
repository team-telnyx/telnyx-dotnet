using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Verifications;

/// <summary>
/// The request body when creating a verification.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreateVerificationRequestSms, CreateVerificationRequestSmsFromRaw>))]
public sealed record class CreateVerificationRequestSms : JsonModel
{
    /// <summary>
    /// +E164 formatted phone number.
    /// </summary>
    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <summary>
    /// The identifier of the associated Verify profile.
    /// </summary>
    public required string VerifyProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "verify_profile_id"
            );
        }
        init { this._rawData.Set("verify_profile_id", value); }
    }

    /// <summary>
    /// Send a self-generated numeric code to the end-user
    /// </summary>
    public string? CustomCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "custom_code"
            );
        }
        init { this._rawData.Set("custom_code", value); }
    }

    /// <summary>
    /// The number of seconds the verification code is valid for.
    /// </summary>
    public long? TimeoutSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timeout_secs", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PhoneNumber;
        _ = this.VerifyProfileID;
        _ = this.CustomCode;
        _ = this.TimeoutSecs;
    }

    public CreateVerificationRequestSms ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateVerificationRequestSms (
        CreateVerificationRequestSms createVerificationRequestSms
    ) : base(createVerificationRequestSms)
    {  }
    #pragma warning restore CS8618

    public CreateVerificationRequestSms (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateVerificationRequestSms (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CreateVerificationRequestSmsFromRaw.FromRawUnchecked"/>
    public static CreateVerificationRequestSms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CreateVerificationRequestSmsFromRaw : IFromRawJson<CreateVerificationRequestSms>
{
    /// <inheritdoc/>
    public CreateVerificationRequestSms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CreateVerificationRequestSms.FromRawUnchecked(rawData);
}