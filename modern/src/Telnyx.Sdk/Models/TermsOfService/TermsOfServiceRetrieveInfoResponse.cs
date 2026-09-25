using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.TermsOfService.Agreements;

namespace Telnyx.Sdk.Models.TermsOfService;

[JsonConverter(typeof(JsonModelConverter<TermsOfServiceRetrieveInfoResponse, TermsOfServiceRetrieveInfoResponseFromRaw>))]
public sealed record class TermsOfServiceRetrieveInfoResponse : JsonModel
{
    public IReadOnlyList<Agreement>? Agreements {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Agreement>>(
                "agreements"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Agreement>?>(
                "agreements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Agreements ?? [])
        {
            item.Validate();
        }
    }

    public TermsOfServiceRetrieveInfoResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TermsOfServiceRetrieveInfoResponse (
        TermsOfServiceRetrieveInfoResponse termsOfServiceRetrieveInfoResponse
    ) : base(termsOfServiceRetrieveInfoResponse)
    {  }
    #pragma warning restore CS8618

    public TermsOfServiceRetrieveInfoResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TermsOfServiceRetrieveInfoResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TermsOfServiceRetrieveInfoResponseFromRaw.FromRawUnchecked"/>
    public static TermsOfServiceRetrieveInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TermsOfServiceRetrieveInfoResponseFromRaw : IFromRawJson<TermsOfServiceRetrieveInfoResponse>
{
    /// <inheritdoc/>
    public TermsOfServiceRetrieveInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TermsOfServiceRetrieveInfoResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Agreement, AgreementFromRaw>))]
public sealed record class Agreement : JsonModel
{
    public string? CurrentVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "current_version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("current_version", value);
        }
    }

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public string? EffectiveDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "effective_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("effective_date", value);
        }
    }

    /// <summary>
    /// Telnyx product the Terms of Service apply to.
    /// </summary>
    public ApiEnum<string, TosProductType>? ProductType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TosProductType>>(
                "product_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("product_type", value);
        }
    }

    public string? TermsUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "terms_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("terms_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrentVersion;
        _ = this.Description;
        _ = this.EffectiveDate;
        this.ProductType?.Validate();
        _ = this.TermsUrl;
    }

    public Agreement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Agreement (Agreement agreement) : base(agreement)
    {  }
    #pragma warning restore CS8618

    public Agreement (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Agreement (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgreementFromRaw.FromRawUnchecked"/>
    public static Agreement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class AgreementFromRaw : IFromRawJson<Agreement>
{
    /// <inheritdoc/>
    public Agreement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Agreement.FromRawUnchecked(rawData);
}