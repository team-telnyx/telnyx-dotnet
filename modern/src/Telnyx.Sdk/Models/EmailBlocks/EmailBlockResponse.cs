using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailBlocks;

[JsonConverter(typeof(JsonModelConverter<EmailBlockResponse, EmailBlockResponseFromRaw>))]
public sealed record class EmailBlockResponse : JsonModel
{
    /// <summary>
    /// Suppression record. Schema fields hidden by the view: `account_id`, `bounce_category`,
    /// `dsn_code`, `meta`.
    /// </summary>
    public required EmailBlock Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailBlock>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EmailBlockResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailBlockResponse (EmailBlockResponse emailBlockResponse) : base(
        emailBlockResponse
    )
    {  }
    #pragma warning restore CS8618

    public EmailBlockResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailBlockResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailBlockResponseFromRaw.FromRawUnchecked"/>
    public static EmailBlockResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailBlockResponse (EmailBlock data) : this()
    { this.Data = data; }
}

class EmailBlockResponseFromRaw : IFromRawJson<EmailBlockResponse>
{
    /// <inheritdoc/>
    public EmailBlockResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailBlockResponse.FromRawUnchecked(rawData);
}