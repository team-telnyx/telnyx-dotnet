using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailMessages;

[JsonConverter(typeof(JsonModelConverter<SuppressedRecipient, SuppressedRecipientFromRaw>))]
public sealed record class SuppressedRecipient : JsonModel
{
    /// <summary>
    /// Whether an authorized send may override this suppression.
    /// </summary>
    public required bool OverrideAllowed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "override_allowed"
            );
        }
        init { this._rawData.Set("override_allowed", value); }
    }

    /// <summary>
    /// Suppression reason returned by the recipient suppression service.
    /// </summary>
    public required string Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "reason"
            );
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Scope at which the suppression applies.
    /// </summary>
    public required string Scope {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "scope"
            );
        }
        init { this._rawData.Set("scope", value); }
    }

    /// <summary>
    /// Suppressed recipient email address.
    /// </summary>
    public required string To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "to"
            );
        }
        init { this._rawData.Set("to", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OverrideAllowed;
        _ = this.Reason;
        _ = this.Scope;
        _ = this.To;
    }

    public SuppressedRecipient ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SuppressedRecipient (SuppressedRecipient suppressedRecipient) : base(
        suppressedRecipient
    )
    {  }
    #pragma warning restore CS8618

    public SuppressedRecipient (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SuppressedRecipient (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SuppressedRecipientFromRaw.FromRawUnchecked"/>
    public static SuppressedRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SuppressedRecipientFromRaw : IFromRawJson<SuppressedRecipient>
{
    /// <inheritdoc/>
    public SuppressedRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SuppressedRecipient.FromRawUnchecked(rawData);
}