using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Buckets.SslCertificate;

[JsonConverter(typeof(JsonModelConverter<SslCertificateRetrieveResponse, SslCertificateRetrieveResponseFromRaw>))]
public sealed record class SslCertificateRetrieveResponse : JsonModel
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

    public SslCertificateRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SslCertificateRetrieveResponse (
        SslCertificateRetrieveResponse sslCertificateRetrieveResponse
    ) : base(sslCertificateRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public SslCertificateRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SslCertificateRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SslCertificateRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SslCertificateRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SslCertificateRetrieveResponseFromRaw : IFromRawJson<SslCertificateRetrieveResponse>
{
    /// <inheritdoc/>
    public SslCertificateRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SslCertificateRetrieveResponse.FromRawUnchecked(rawData);
}