using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Dir.VerifyEmail;

[JsonConverter(typeof(JsonModelConverter<EmailVerificationStatusWrapped, EmailVerificationStatusWrappedFromRaw>))]
public sealed record class EmailVerificationStatusWrapped : JsonModel
{
    /// <summary>
    /// Verification state for a DIR's authorizer email.
    /// </summary>
    public required EmailVerificationStatus Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailVerificationStatus>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EmailVerificationStatusWrapped ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailVerificationStatusWrapped (
        EmailVerificationStatusWrapped emailVerificationStatusWrapped
    ) : base(emailVerificationStatusWrapped)
    {  }
    #pragma warning restore CS8618

    public EmailVerificationStatusWrapped (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailVerificationStatusWrapped (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailVerificationStatusWrappedFromRaw.FromRawUnchecked"/>
    public static EmailVerificationStatusWrapped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailVerificationStatusWrapped (EmailVerificationStatus data) : this(

    )
    { this.Data = data; }
}

class EmailVerificationStatusWrappedFromRaw : IFromRawJson<EmailVerificationStatusWrapped>
{
    /// <inheritdoc/>
    public EmailVerificationStatusWrapped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailVerificationStatusWrapped.FromRawUnchecked(rawData);
}