using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Faxes;

/// <summary>
/// Send a fax. Files have size limits and page count limit validations. If a file
/// is bigger than 50MB or has more than 350 pages it will fail with `file_size_limit_exceeded`
/// and `page_count_limit_exceeded` respectively.
///
/// <para>**Supported file formats:**</para>
///
/// <para>- PDF (`application/pdf`) - TIFF (`application/tiff`, `image/tiff`) - JPEG
/// (`image/jpeg`) - PNG (`image/png`) - Microsoft Word `.doc` (`application/msword`)
/// - Microsoft Word `.docx` (`application/vnd.openxmlformats-officedocument.wordprocessingml.document`)
/// - Rich Text Format `.rtf` (`application/rtf`) - Plain text `.txt` (`text/plain`)</para>
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `fax.queued` - `fax.media.processed` - `fax.sending.started` - `fax.delivered`
/// - `fax.failed`</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FaxCreateParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The connection ID to send the fax with.
    /// </summary>
    public required string ConnectionID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "connection_id"
            );
        }
        init { this._rawBodyData.Set("connection_id", value); }
    }

    /// <summary>
    /// The phone number, in E.164 format, the fax will be sent from.
    /// </summary>
    public required string From {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "from"
            );
        }
        init { this._rawBodyData.Set("from", value); }
    }

    /// <summary>
    /// The phone number, in E.164 format, the fax will be sent to or SIP URI
    /// </summary>
    public required string To {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "to"
            );
        }
        init { this._rawBodyData.Set("to", value); }
    }

    /// <summary>
    /// The black threshold percentage for monochrome faxes. Only applicable if `monochrome`
    /// is set to `true`.
    /// </summary>
    public long? BlackThreshold {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "black_threshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("black_threshold", value);
        }
    }

    /// <summary>
    /// Use this field to add state to every subsequent webhook. It must be a valid
    /// Base-64 encoded string.
    /// </summary>
    public string? ClientState {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("client_state", value);
        }
    }

    /// <summary>
    /// The `from_display_name` string to be used as the caller id name (SIP From
    /// Display Name) presented to the destination (`to` number). The string should
    /// have a maximum of 128 characters, containing only letters, numbers, spaces,
    /// and -_~!.+ special characters. If ommited, the display name will be the same
    /// as the number in the `from` field.
    /// </summary>
    public string? FromDisplayName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "from_display_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("from_display_name", value);
        }
    }

    /// <summary>
    /// The media_name used for the fax's media. Must point to a file previously uploaded
    /// to api.telnyx.com/v2/media by the same user/organization. Supported formats:
    /// PDF, TIFF, JPEG, PNG, DOC, DOCX, RTF, and TXT. media_name and media_url/contents
    /// can't be submitted together.
    /// </summary>
    public string? MediaName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "media_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("media_name", value);
        }
    }

    /// <summary>
    /// The URL (or list of URLs) to the fax document. Supported formats: PDF, TIFF,
    /// JPEG, PNG, DOC, DOCX, RTF, and TXT. media_url and media_name/contents can't
    /// be submitted together.
    /// </summary>
    public string? MediaUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "media_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("media_url", value);
        }
    }

    /// <summary>
    /// The flag to enable monochrome, true black and white fax results.
    /// </summary>
    public bool? Monochrome {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "monochrome"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("monochrome", value);
        }
    }

    /// <summary>
    /// The format for the preview file in case the `store_preview` is `true`.
    /// </summary>
    public ApiEnum<string, PreviewFormat>? PreviewFormat {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PreviewFormat>>(
                "preview_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("preview_format", value);
        }
    }

    /// <summary>
    /// The quality of the fax. The `ultra` settings provides the highest quality
    /// available, but also present longer fax processing times. `ultra_light` is
    /// best suited for images, wihle `ultra_dark` is best suited for text.
    /// </summary>
    public ApiEnum<string, Quality>? Quality {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Quality>>(
                "quality"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("quality", value);
        }
    }

    /// <summary>
    /// Should fax media be stored on temporary URL. It does not support media_name,
    /// they can't be submitted together.
    /// </summary>
    public bool? StoreMedia {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "store_media"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("store_media", value);
        }
    }

    /// <summary>
    /// Should fax preview be stored on temporary URL.
    /// </summary>
    public bool? StorePreview {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "store_preview"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("store_preview", value);
        }
    }

    /// <summary>
    /// The flag to disable the T.38 protocol.
    /// </summary>
    public bool? T38Enabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "t38_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("t38_enabled", value);
        }
    }

    /// <summary>
    /// Use this field to override the URL to which Telnyx will send subsequent webhooks
    /// for this fax.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_url", value);
        }
    }

    public FaxCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxCreateParams (FaxCreateParams faxCreateParams) : base(
        faxCreateParams
    )
    { this._rawBodyData = new(faxCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public FaxCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FaxCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, MultipartJsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(FaxCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/faxes"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    { return MultipartJsonSerializer.Serialize(RawBodyData) ; }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// The format for the preview file in case the `store_preview` is `true`.
/// </summary>
[JsonConverter(typeof(PreviewFormatConverter))]
public enum PreviewFormat
{
    Pdf, Tiff
}

sealed class PreviewFormatConverter : JsonConverter<PreviewFormat>
{
    public override PreviewFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pdf"=>PreviewFormat.Pdf,
            "tiff"=>PreviewFormat.Tiff,
            _ =>(PreviewFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreviewFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PreviewFormat.Pdf=>"pdf",
            PreviewFormat.Tiff=>"tiff",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}