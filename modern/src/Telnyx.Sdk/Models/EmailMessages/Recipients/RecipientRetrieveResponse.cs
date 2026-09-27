using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailMessages.Recipients;

[JsonConverter(typeof(JsonModelConverter<RecipientRetrieveResponse, RecipientRetrieveResponseFromRaw>))]
public sealed record class RecipientRetrieveResponse : JsonModel
{
    public required EmailRecipient Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailRecipient>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public RecipientRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecipientRetrieveResponse (
        RecipientRetrieveResponse recipientRetrieveResponse
    ) : base(recipientRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public RecipientRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecipientRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecipientRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static RecipientRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public RecipientRetrieveResponse (EmailRecipient data) : this()
    { this.Data = data; }
}

class RecipientRetrieveResponseFromRaw : IFromRawJson<RecipientRetrieveResponse>
{
    /// <inheritdoc/>
    public RecipientRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecipientRetrieveResponse.FromRawUnchecked(rawData);
}