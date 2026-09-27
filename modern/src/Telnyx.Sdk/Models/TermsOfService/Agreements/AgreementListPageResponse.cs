using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.CallReasons;

namespace Telnyx.Sdk.Models.TermsOfService.Agreements;

/// <summary>
/// Paginated list of Terms of Service agreements for the calling user.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AgreementListPageResponse, AgreementListPageResponseFromRaw>))]
public sealed record class AgreementListPageResponse : JsonModel
{
    public required IReadOnlyList<TosAgreement> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TosAgreement>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<TosAgreement>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// JSON:API pagination metadata returned with every paginated list response.
    /// Page numbering is 1-based. `page_size` reports the number of items actually
    /// returned in `data` for this page; the requested size is taken from the `page[size]`
    /// query parameter.
    /// </summary>
    public required BrandedCallingPaginationMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrandedCallingPaginationMeta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public AgreementListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgreementListPageResponse (
        AgreementListPageResponse agreementListPageResponse
    ) : base(agreementListPageResponse)
    {  }
    #pragma warning restore CS8618

    public AgreementListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgreementListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgreementListPageResponseFromRaw.FromRawUnchecked"/>
    public static AgreementListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AgreementListPageResponseFromRaw : IFromRawJson<AgreementListPageResponse>
{
    /// <inheritdoc/>
    public AgreementListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgreementListPageResponse.FromRawUnchecked(rawData);
}