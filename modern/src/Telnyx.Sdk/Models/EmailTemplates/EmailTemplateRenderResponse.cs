using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailTemplates;

[JsonConverter(typeof(JsonModelConverter<EmailTemplateRenderResponse, EmailTemplateRenderResponseFromRaw>))]
public sealed record class EmailTemplateRenderResponse : JsonModel
{
    /// <summary>
    /// Template object with `subject`, `html_body`, and `text_body` replaced by their
    /// Liquid-rendered values. All other template fields (id, name, variables, etc.)
    /// remain unchanged.
    /// </summary>
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EmailTemplateRenderResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailTemplateRenderResponse (
        EmailTemplateRenderResponse emailTemplateRenderResponse
    ) : base(emailTemplateRenderResponse)
    {  }
    #pragma warning restore CS8618

    public EmailTemplateRenderResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailTemplateRenderResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailTemplateRenderResponseFromRaw.FromRawUnchecked"/>
    public static EmailTemplateRenderResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailTemplateRenderResponse (Data data) : this()
    { this.Data = data; }
}

class EmailTemplateRenderResponseFromRaw : IFromRawJson<EmailTemplateRenderResponse>
{
    /// <inheritdoc/>
    public EmailTemplateRenderResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailTemplateRenderResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Template object with `subject`, `html_body`, and `text_body` replaced by their
/// Liquid-rendered values. All other template fields (id, name, variables, etc.)
/// remain unchanged.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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

    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
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

    public required DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
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

    public static implicit operator EmailTemplate (Data data)=> new() {
        ID = data.ID,
        Autoescape = data.Autoescape,
        CreatedAt = data.CreatedAt,
        HtmlBody = data.HtmlBody,
        Name = data.Name,
        RecordType = data.RecordType,
        StrictVariables = data.StrictVariables,
        Subject = data.Subject,
        TextBody = data.TextBody,
        UpdatedAt = data.UpdatedAt,
        VariableSchema = data.VariableSchema,
        Variables = data.Variables
    } ;

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

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}