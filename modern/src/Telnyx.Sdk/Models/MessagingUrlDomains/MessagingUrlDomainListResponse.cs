using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingUrlDomains;

[JsonConverter(typeof(JsonModelConverter<MessagingUrlDomainListResponse, MessagingUrlDomainListResponseFromRaw>))]
public sealed record class MessagingUrlDomainListResponse : JsonModel
{
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    public string? UrlDomain {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "url_domain"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("url_domain", value);
        }
    }

    public string? UseCase {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "use_case"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("use_case", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.RecordType;
        _ = this.UrlDomain;
        _ = this.UseCase;
    }

    public MessagingUrlDomainListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingUrlDomainListResponse (
        MessagingUrlDomainListResponse messagingUrlDomainListResponse
    ) : base(messagingUrlDomainListResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingUrlDomainListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingUrlDomainListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingUrlDomainListResponseFromRaw.FromRawUnchecked"/>
    public static MessagingUrlDomainListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingUrlDomainListResponseFromRaw : IFromRawJson<MessagingUrlDomainListResponse>
{
    /// <inheritdoc/>
    public MessagingUrlDomainListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingUrlDomainListResponse.FromRawUnchecked(rawData);
}