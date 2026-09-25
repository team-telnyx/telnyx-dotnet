using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TermsOfService.Agreements;

/// <summary>
/// A recorded user agreement to a product's Terms of Service. The `user_id` is intentionally
/// NOT echoed back on this public surface - the caller already knows their own identity.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TosAgreement, TosAgreementFromRaw>))]
public sealed record class TosAgreement : JsonModel
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

    public DateTimeOffset? AgreedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "agreed_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("agreed_at", value);
        }
    }

    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
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

    public string? TermsVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "terms_version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("terms_version", value);
        }
    }

    /// <summary>
    /// Convenience alias of `terms_version`. Both keys are present on every response.
    /// </summary>
    public string? Version {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AgreedAt;
        _ = this.CreatedAt;
        this.ProductType?.Validate();
        _ = this.TermsVersion;
        _ = this.Version;
    }

    public TosAgreement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TosAgreement (TosAgreement tosAgreement) : base(tosAgreement)
    {  }
    #pragma warning restore CS8618

    public TosAgreement (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TosAgreement (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TosAgreementFromRaw.FromRawUnchecked"/>
    public static TosAgreement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TosAgreementFromRaw : IFromRawJson<TosAgreement>
{
    /// <inheritdoc/>
    public TosAgreement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TosAgreement.FromRawUnchecked(rawData);
}