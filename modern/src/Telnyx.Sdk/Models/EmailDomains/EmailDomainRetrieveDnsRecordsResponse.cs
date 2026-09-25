using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailDomains;

[JsonConverter(typeof(JsonModelConverter<EmailDomainRetrieveDnsRecordsResponse, EmailDomainRetrieveDnsRecordsResponseFromRaw>))]
public sealed record class EmailDomainRetrieveDnsRecordsResponse : JsonModel
{
    public required IReadOnlyList<DnsRecord> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DnsRecord>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<DnsRecord>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public EmailDomainRetrieveDnsRecordsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainRetrieveDnsRecordsResponse (
        EmailDomainRetrieveDnsRecordsResponse emailDomainRetrieveDnsRecordsResponse
    ) : base(emailDomainRetrieveDnsRecordsResponse)
    {  }
    #pragma warning restore CS8618

    public EmailDomainRetrieveDnsRecordsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainRetrieveDnsRecordsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainRetrieveDnsRecordsResponseFromRaw.FromRawUnchecked"/>
    public static EmailDomainRetrieveDnsRecordsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailDomainRetrieveDnsRecordsResponse (
        IReadOnlyList<DnsRecord> data
    ) : this()
    { this.Data = data; }
}

class EmailDomainRetrieveDnsRecordsResponseFromRaw : IFromRawJson<EmailDomainRetrieveDnsRecordsResponse>
{
    /// <inheritdoc/>
    public EmailDomainRetrieveDnsRecordsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailDomainRetrieveDnsRecordsResponse.FromRawUnchecked(rawData);
}