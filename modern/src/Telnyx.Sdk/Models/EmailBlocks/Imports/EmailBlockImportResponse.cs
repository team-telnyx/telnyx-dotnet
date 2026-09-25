using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailBlocks.Imports;

[JsonConverter(typeof(JsonModelConverter<EmailBlockImportResponse, EmailBlockImportResponseFromRaw>))]
public sealed record class EmailBlockImportResponse : JsonModel
{
    /// <summary>
    /// Import job. Schema fields hidden: `account_id`, `csv_content`, `block_ttl_days`.
    /// Nullable fields use the omit-nullable pattern.
    /// </summary>
    public required EmailBlockImport Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailBlockImport>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EmailBlockImportResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailBlockImportResponse (
        EmailBlockImportResponse emailBlockImportResponse
    ) : base(emailBlockImportResponse)
    {  }
    #pragma warning restore CS8618

    public EmailBlockImportResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailBlockImportResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailBlockImportResponseFromRaw.FromRawUnchecked"/>
    public static EmailBlockImportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailBlockImportResponse (EmailBlockImport data) : this()
    { this.Data = data; }
}

class EmailBlockImportResponseFromRaw : IFromRawJson<EmailBlockImportResponse>
{
    /// <inheritdoc/>
    public EmailBlockImportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailBlockImportResponse.FromRawUnchecked(rawData);
}