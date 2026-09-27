using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Buckets.SslCertificate;

[JsonConverter(typeof(JsonModelConverter<SslCertificateDeleteResponse, SslCertificateDeleteResponseFromRaw>))]
public sealed record class SslCertificateDeleteResponse : JsonModel
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

    public SslCertificateDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SslCertificateDeleteResponse (
        SslCertificateDeleteResponse sslCertificateDeleteResponse
    ) : base(sslCertificateDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public SslCertificateDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SslCertificateDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SslCertificateDeleteResponseFromRaw.FromRawUnchecked"/>
    public static SslCertificateDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SslCertificateDeleteResponseFromRaw : IFromRawJson<SslCertificateDeleteResponse>
{
    /// <inheritdoc/>
    public SslCertificateDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SslCertificateDeleteResponse.FromRawUnchecked(rawData);
}