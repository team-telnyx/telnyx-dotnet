using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailTemplates;

/// <summary>
/// Creates a Liquid email template. Variables are auto-extracted when omitted.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EmailTemplateCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Letters, numbers, spaces, hyphens, and underscores only.
    /// </summary>
    public required string Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Per-template HTML autoescaping setting. Defaults to `false` for backward compatibility.
    /// When `true`, the rendered `html_body` HTML-escapes each Liquid expression's
    /// output at the output boundary (after its filters run, before concatenation
    /// with literal template markup). Input values are never mutated and `subject`/`text_body`
    /// are never autoescaped. The boundary escape is idempotent: HTML entities already
    /// present in the output (e.g. from an explicit `escape` filter) are preserved,
    /// so an explicit `escape`/`escape_once` is never double-escaped, and markup
    /// introduced by any later filter in the chain is still escaped.
    /// </summary>
    public bool? Autoescape {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "autoescape"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("autoescape", value);
        }
    }

    /// <summary>
    /// Liquid template HTML body.
    /// </summary>
    public string? HtmlBody {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "html_body"
            );
        }
        init { this._rawBodyData.Set("html_body", value); }
    }

    /// <summary>
    /// Per-template strict variable-validation setting. Defaults to `false` for
    /// backward compatibility. When `true`, a send or render that is missing a variable
    /// marked `required: true` in `variable_schema` fails with 422 naming the variable.
    /// Missing optional variables never fail; their schema `default` (when set)
    /// is applied to the render.
    /// </summary>
    public bool? StrictVariables {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "strict_variables"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("strict_variables", value);
        }
    }

    /// <summary>
    /// Liquid template subject.
    /// </summary>
    public string? Subject {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "subject"
            );
        }
        init { this._rawBodyData.Set("subject", value); }
    }

    /// <summary>
    /// Liquid template text body.
    /// </summary>
    public string? TextBody {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "text_body"
            );
        }
        init { this._rawBodyData.Set("text_body", value); }
    }

    /// <summary>
    /// Structured variable requirements. Required variables cannot define defaults;
    /// invalid combinations return 422. This is independent of the legacy `variables`
    /// array. On render with `strict_variables` enabled: `required` variables must
    /// be supplied as non-empty values — absent, `null`, empty string, empty object
    /// `{}`, and empty array `[]` all fail with 422 naming the variable, while present
    /// values such as `false` and `0` pass (they are present, not empty). Optional
    /// variables fall back to their `default` when absent.
    /// </summary>
    public IReadOnlyDictionary<string, VariableSchemaItem>? VariableSchema {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, VariableSchemaItem>>(
                "variable_schema"
            );
        }
        init {
            this._rawBodyData.Set<FrozenDictionary<string, VariableSchemaItem>?>(
                "variable_schema",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Template variables. Auto-extracted from subject/body fields when absent.
    /// </summary>
    public IReadOnlyList<string>? Variables {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "variables"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "variables",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? IdempotencyKey {
        get {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>(
                "Idempotency-Key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
    }

    public EmailTemplateCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailTemplateCreateParams (
        EmailTemplateCreateParams emailTemplateCreateParams
    ) : base(emailTemplateCreateParams)
    { this._rawBodyData = new(emailTemplateCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public EmailTemplateCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailTemplateCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EmailTemplateCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(EmailTemplateCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/email_templates"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

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

[JsonConverter(typeof(JsonModelConverter<VariableSchemaItem, VariableSchemaItemFromRaw>))]
public sealed record class VariableSchemaItem : JsonModel
{
    /// <summary>
    /// Whether the variable must be supplied when strict variable validation is enabled.
    /// </summary>
    public required bool Required {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "required"
            );
        }
        init { this._rawData.Set("required", value); }
    }

    /// <summary>
    /// Default value for an optional variable. Rejected when `required` is `true`.
    /// </summary>
    public string? Default {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "default"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Required;
        _ = this.Default;
    }

    public VariableSchemaItem ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VariableSchemaItem (VariableSchemaItem variableSchemaItem) : base(
        variableSchemaItem
    )
    {  }
    #pragma warning restore CS8618

    public VariableSchemaItem (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VariableSchemaItem (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VariableSchemaItemFromRaw.FromRawUnchecked"/>
    public static VariableSchemaItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public VariableSchemaItem (bool required) : this()
    { this.Required = required; }
}

class VariableSchemaItemFromRaw : IFromRawJson<VariableSchemaItem>
{
    /// <inheritdoc/>
    public VariableSchemaItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VariableSchemaItem.FromRawUnchecked(rawData);
}