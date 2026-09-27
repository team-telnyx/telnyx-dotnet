using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Buckets.SslCertificate;

[JsonConverter(typeof(JsonModelConverter<SslCertificateSslCertificate, SslCertificateSslCertificateFromRaw>))]
public sealed record class SslCertificateSslCertificate : JsonModel
{
    /// <summary>
    /// Unique identifier for the SSL certificate
    /// </summary>
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

    /// <summary>
    /// Time when SSL certificate was uploaded
    /// </summary>
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

    public IssuedBy? IssuedBy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IssuedBy>(
                "issued_by"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("issued_by", value);
        }
    }

    public IssuedTo? IssuedTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IssuedTo>(
                "issued_to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("issued_to", value);
        }
    }

    /// <summary>
    /// The time the certificate is valid from
    /// </summary>
    public DateTimeOffset? ValidFrom {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "valid_from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("valid_from", value);
        }
    }

    /// <summary>
    /// The time the certificate is valid to
    /// </summary>
    public DateTimeOffset? ValidTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "valid_to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("valid_to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.IssuedBy?.Validate();
        this.IssuedTo?.Validate();
        _ = this.ValidFrom;
        _ = this.ValidTo;
    }

    public SslCertificateSslCertificate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SslCertificateSslCertificate (
        SslCertificateSslCertificate sslCertificateSslCertificate
    ) : base(sslCertificateSslCertificate)
    {  }
    #pragma warning restore CS8618

    public SslCertificateSslCertificate (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SslCertificateSslCertificate (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SslCertificateSslCertificateFromRaw.FromRawUnchecked"/>
    public static SslCertificateSslCertificate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SslCertificateSslCertificateFromRaw : IFromRawJson<SslCertificateSslCertificate>
{
    /// <inheritdoc/>
    public SslCertificateSslCertificate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SslCertificateSslCertificate.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IssuedBy, IssuedByFromRaw>))]
public sealed record class IssuedBy : JsonModel
{
    /// <summary>
    /// The common name of the entity the certificate was issued by
    /// </summary>
    public string? CommonName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "common_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("common_name", value);
        }
    }

    /// <summary>
    /// The organization the certificate was issued by
    /// </summary>
    public string? Organization {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization", value);
        }
    }

    /// <summary>
    /// The organizational unit the certificate was issued by
    /// </summary>
    public string? OrganizationUnit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization_unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_unit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CommonName;
        _ = this.Organization;
        _ = this.OrganizationUnit;
    }

    public IssuedBy ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IssuedBy (IssuedBy issuedBy) : base(issuedBy)
    {  }
    #pragma warning restore CS8618

    public IssuedBy (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IssuedBy (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IssuedByFromRaw.FromRawUnchecked"/>
    public static IssuedBy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class IssuedByFromRaw : IFromRawJson<IssuedBy>
{
    /// <inheritdoc/>
    public IssuedBy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IssuedBy.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<IssuedTo, IssuedToFromRaw>))]
public sealed record class IssuedTo : JsonModel
{
    /// <summary>
    /// The common name of the entity the certificate was issued to
    /// </summary>
    public string? CommonName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "common_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("common_name", value);
        }
    }

    /// <summary>
    /// The organization the certificate was issued to
    /// </summary>
    public string? Organization {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization", value);
        }
    }

    /// <summary>
    /// The organizational unit the certificate was issued to
    /// </summary>
    public string? OrganizationUnit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization_unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_unit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CommonName;
        _ = this.Organization;
        _ = this.OrganizationUnit;
    }

    public IssuedTo ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IssuedTo (IssuedTo issuedTo) : base(issuedTo)
    {  }
    #pragma warning restore CS8618

    public IssuedTo (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IssuedTo (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IssuedToFromRaw.FromRawUnchecked"/>
    public static IssuedTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class IssuedToFromRaw : IFromRawJson<IssuedTo>
{
    /// <inheritdoc/>
    public IssuedTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IssuedTo.FromRawUnchecked(rawData);
}