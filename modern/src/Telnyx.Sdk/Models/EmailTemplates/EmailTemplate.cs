using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailTemplates;

[JsonConverter(typeof(JsonModelConverter<EmailTemplate, EmailTemplateFromRaw>))]
public sealed record class EmailTemplate : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Whether HTML autoescaping is enabled for this template. When `true`, only
    /// rendered `html_body` expression output is HTML-escaped at the output boundary;
    /// `subject` and `text_body` are never autoescaped.
    /// </summary>
    public required bool Autoescape {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "autoescape"
            );
        }
        init { this._rawData.Set("autoescape", value); }
    }

    public required System::DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string? HtmlBody {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "html_body"
            );
        }
        init { this._rawData.Set("html_body", value); }
    }

    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Whether strict variable validation is enabled for this template. When `true`,
    /// sends and renders that are missing a variable marked `required: true` in `variable_schema`
    /// fail with 422 naming the variable.
    /// </summary>
    public required bool StrictVariables {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "strict_variables"
            );
        }
        init { this._rawData.Set("strict_variables", value); }
    }

    public required string? Subject {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "subject"
            );
        }
        init { this._rawData.Set("subject", value); }
    }

    public required string? TextBody {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text_body"
            );
        }
        init { this._rawData.Set("text_body", value); }
    }

    public required System::DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Structured variable requirements, or `null` when the template uses only the
    /// legacy `variables` array.
    /// </summary>
    public required IReadOnlyDictionary<string, EmailTemplateVariableSchemaItem>? VariableSchema {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, EmailTemplateVariableSchemaItem>>(
                "variable_schema"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, EmailTemplateVariableSchemaItem>?>(
                "variable_schema",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Legacy unstructured variable names. This path remains supported unchanged.
    /// </summary>
    public required IReadOnlyList<string> Variables {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "variables"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "variables",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Autoescape;
        _ = this.CreatedAt;
        _ = this.HtmlBody;
        _ = this.Name;
        this.RecordType.Validate();
        _ = this.StrictVariables;
        _ = this.Subject;
        _ = this.TextBody;
        _ = this.UpdatedAt;
        if (this.VariableSchema != null)
        {
            foreach (var item in this.VariableSchema.Values)
            {
                item.Validate();
            }
        }
        _ = this.Variables;
    }

    public EmailTemplate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailTemplate (EmailTemplate emailTemplate) : base(emailTemplate)
    {  }
    #pragma warning restore CS8618

    public EmailTemplate (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailTemplate (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailTemplateFromRaw.FromRawUnchecked"/>
    public static EmailTemplate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailTemplateFromRaw : IFromRawJson<EmailTemplate>
{
    /// <inheritdoc/>
    public EmailTemplate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailTemplate.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    EmailTemplate
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "email_template"=>RecordType.EmailTemplate, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.EmailTemplate=>"email_template",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<EmailTemplateVariableSchemaItem, EmailTemplateVariableSchemaItemFromRaw>))]
public sealed record class EmailTemplateVariableSchemaItem : JsonModel
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

    public EmailTemplateVariableSchemaItem ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailTemplateVariableSchemaItem (
        EmailTemplateVariableSchemaItem emailTemplateVariableSchemaItem
    ) : base(emailTemplateVariableSchemaItem)
    {  }
    #pragma warning restore CS8618

    public EmailTemplateVariableSchemaItem (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailTemplateVariableSchemaItem (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailTemplateVariableSchemaItemFromRaw.FromRawUnchecked"/>
    public static EmailTemplateVariableSchemaItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailTemplateVariableSchemaItem (bool required) : this()
    { this.Required = required; }
}class EmailTemplateVariableSchemaItemFromRaw : IFromRawJson<EmailTemplateVariableSchemaItem>
{
    /// <inheritdoc/>
    public EmailTemplateVariableSchemaItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailTemplateVariableSchemaItem.FromRawUnchecked(rawData);
}