using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Buckets.SslCertificate;

[JsonConverter(typeof(JsonModelConverter<SslCertificateCreateResponse, SslCertificateCreateResponseFromRaw>))]
public sealed record class SslCertificateCreateResponse : JsonModel
{
    public SslCertificateSslCertificate? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SslCertificateSslCertificate>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public SslCertificateCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SslCertificateCreateResponse (
        SslCertificateCreateResponse sslCertificateCreateResponse
    ) : base(sslCertificateCreateResponse)
    {  }
    #pragma warning restore CS8618

    public SslCertificateCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SslCertificateCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SslCertificateCreateResponseFromRaw.FromRawUnchecked"/>
    public static SslCertificateCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SslCertificateCreateResponseFromRaw : IFromRawJson<SslCertificateCreateResponse>
{
    /// <inheritdoc/>
    public SslCertificateCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SslCertificateCreateResponse.FromRawUnchecked(rawData);
}