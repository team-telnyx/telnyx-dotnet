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
/// Updates one or more fields of the specified email template and returns the updated template.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EmailTemplateUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Per-template HTML autoescaping setting.
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

    public string? Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    /// <summary>
    /// Per-template strict variable-validation setting.
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
    /// invalid combinations return 422. Set to `null` to clear the schema.
    /// </summary>
    public IReadOnlyDictionary<string, EmailTemplateUpdateParamsVariableSchemaItem>? VariableSchema {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, EmailTemplateUpdateParamsVariableSchemaItem>>(
                "variable_schema"
            );
        }
        init {
            this._rawBodyData.Set<FrozenDictionary<string, EmailTemplateUpdateParamsVariableSchemaItem>?>(
                "variable_schema",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

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

    public EmailTemplateUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailTemplateUpdateParams (
        EmailTemplateUpdateParams emailTemplateUpdateParams
    ) : base(emailTemplateUpdateParams)
    {
        this.ID = emailTemplateUpdateParams.ID;

        this._rawBodyData = new(emailTemplateUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public EmailTemplateUpdateParams (
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
    EmailTemplateUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EmailTemplateUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(EmailTemplateUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/email_templates/{0}",
            this.ID)
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

[JsonConverter(typeof(JsonModelConverter<EmailTemplateUpdateParamsVariableSchemaItem, EmailTemplateUpdateParamsVariableSchemaItemFromRaw>))]
public sealed record class EmailTemplateUpdateParamsVariableSchemaItem : JsonModel
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

    public EmailTemplateUpdateParamsVariableSchemaItem ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailTemplateUpdateParamsVariableSchemaItem (
        EmailTemplateUpdateParamsVariableSchemaItem emailTemplateUpdateParamsVariableSchemaItem
    ) : base(emailTemplateUpdateParamsVariableSchemaItem)
    {  }
    #pragma warning restore CS8618

    public EmailTemplateUpdateParamsVariableSchemaItem (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailTemplateUpdateParamsVariableSchemaItem (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailTemplateUpdateParamsVariableSchemaItemFromRaw.FromRawUnchecked"/>
    public static EmailTemplateUpdateParamsVariableSchemaItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailTemplateUpdateParamsVariableSchemaItem (bool required) : this()
    { this.Required = required; }
}

class EmailTemplateUpdateParamsVariableSchemaItemFromRaw : IFromRawJson<EmailTemplateUpdateParamsVariableSchemaItem>
{
    /// <inheritdoc/>
    public EmailTemplateUpdateParamsVariableSchemaItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailTemplateUpdateParamsVariableSchemaItem.FromRawUnchecked(rawData);
}