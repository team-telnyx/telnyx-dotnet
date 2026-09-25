using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Threads;

namespace Telnyx.Sdk.Models.EmailThreads;

[JsonConverter(typeof(JsonModelConverter<EmailThreadRetrieveResponse, EmailThreadRetrieveResponseFromRaw>))]
public sealed record class EmailThreadRetrieveResponse : JsonModel
{
    public required InboundThreadDetail Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<InboundThreadDetail>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required EmailPaginationMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailPaginationMeta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        this.Meta.Validate();
    }

    public EmailThreadRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailThreadRetrieveResponse (
        EmailThreadRetrieveResponse emailThreadRetrieveResponse
    ) : base(emailThreadRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public EmailThreadRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailThreadRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailThreadRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static EmailThreadRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailThreadRetrieveResponseFromRaw : IFromRawJson<EmailThreadRetrieveResponse>
{
    /// <inheritdoc/>
    public EmailThreadRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailThreadRetrieveResponse.FromRawUnchecked(rawData);
}