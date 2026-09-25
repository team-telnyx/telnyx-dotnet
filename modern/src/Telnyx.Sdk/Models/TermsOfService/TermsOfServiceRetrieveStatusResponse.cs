using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.TermsOfService.Agreements;

namespace Telnyx.Sdk.Models.TermsOfService;

[JsonConverter(typeof(JsonModelConverter<TermsOfServiceRetrieveStatusResponse, TermsOfServiceRetrieveStatusResponseFromRaw>))]
public sealed record class TermsOfServiceRetrieveStatusResponse : JsonModel
{
    /// <summary>
    /// Whether the calling user has agreed to a product's current Terms of Service.
    /// The `user_id` is intentionally omitted on this public surface.
    /// </summary>
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public TermsOfServiceRetrieveStatusResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TermsOfServiceRetrieveStatusResponse (
        TermsOfServiceRetrieveStatusResponse termsOfServiceRetrieveStatusResponse
    ) : base(termsOfServiceRetrieveStatusResponse)
    {  }
    #pragma warning restore CS8618

    public TermsOfServiceRetrieveStatusResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TermsOfServiceRetrieveStatusResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TermsOfServiceRetrieveStatusResponseFromRaw.FromRawUnchecked"/>
    public static TermsOfServiceRetrieveStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public TermsOfServiceRetrieveStatusResponse (Data data) : this()
    { this.Data = data; }
}

class TermsOfServiceRetrieveStatusResponseFromRaw : IFromRawJson<TermsOfServiceRetrieveStatusResponse>
{
    /// <inheritdoc/>
    public TermsOfServiceRetrieveStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TermsOfServiceRetrieveStatusResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the calling user has agreed to a product's current Terms of Service. The
/// `user_id` is intentionally omitted on this public surface.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// `true` when the user must agree to the latest version before using the product.
    /// Equivalent to `!has_agreed`.
    /// </summary>
    public required bool AgreementRequired {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "agreement_required"
            );
        }
        init { this._rawData.Set("agreement_required", value); }
    }

    /// <summary>
    /// Latest published version of the ToS for this product.
    /// </summary>
    public required string CurrentTermsVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "current_terms_version"
            );
        }
        init { this._rawData.Set("current_terms_version", value); }
    }

    /// <summary>
    /// `true` if the user has agreed to the latest version.
    /// </summary>
    public required bool HasAgreed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "has_agreed"
            );
        }
        init { this._rawData.Set("has_agreed", value); }
    }

    /// <summary>
    /// Telnyx product the Terms of Service apply to.
    /// </summary>
    public required ApiEnum<string, TosProductType> ProductType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TosProductType>>(
                "product_type"
            );
        }
        init { this._rawData.Set("product_type", value); }
    }

    public DateTimeOffset? AgreedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "agreed_at"
            );
        }
        init { this._rawData.Set("agreed_at", value); }
    }

    /// <summary>
    /// Version the user previously agreed to (may be older than `current_terms_version`).
    /// `null` if the user has never agreed.
    /// </summary>
    public string? AgreedVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "agreed_version"
            );
        }
        init { this._rawData.Set("agreed_version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AgreementRequired;
        _ = this.CurrentTermsVersion;
        _ = this.HasAgreed;
        this.ProductType.Validate();
        _ = this.AgreedAt;
        _ = this.AgreedVersion;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}