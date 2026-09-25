using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Threads;

[JsonConverter(typeof(JsonModelConverter<InboundEmailAddress, InboundEmailAddressFromRaw>))]
public sealed record class InboundEmailAddress : JsonModel
{
    public required string Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
    }

    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.Name;
    }

    public InboundEmailAddress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundEmailAddress (InboundEmailAddress inboundEmailAddress) : base(
        inboundEmailAddress
    )
    {  }
    #pragma warning restore CS8618

    public InboundEmailAddress (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundEmailAddress (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundEmailAddressFromRaw.FromRawUnchecked"/>
    public static InboundEmailAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public InboundEmailAddress (string email) : this()
    { this.Email = email; }
}

class InboundEmailAddressFromRaw : IFromRawJson<InboundEmailAddress>
{
    /// <inheritdoc/>
    public InboundEmailAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboundEmailAddress.FromRawUnchecked(rawData);
}