using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailTemplates;

[JsonConverter(typeof(JsonModelConverter<UpdateEmailTemplateRequest, UpdateEmailTemplateRequestFromRaw>))]
public sealed record class UpdateEmailTemplateRequest : JsonModel
{
    /// <summary>
    /// Per-template HTML autoescaping setting.
    /// </summary>
    public bool? Autoescape {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "autoescape"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("autoescape", value);
        }
    }

    /// <summary>
    /// Liquid template HTML body.
    /// </summary>
    public string? HtmlBody {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "html_body"
            );
        }
        init { this._rawData.Set("html_body", value); }
    }

    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Per-template strict variable-validation setting.
    /// </summary>
    public bool? StrictVariables {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "strict_variables"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("strict_variables", value);
        }
    }

    /// <summary>
    /// Liquid template subject.
    /// </summary>
    public string? Subject {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "subject"
            );
        }
        init { this._rawData.Set("subject", value); }
    }

    /// <summary>
    /// Liquid template text body.
    /// </summary>
    public string? TextBody {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text_body"
            );
        }
        init { this._rawData.Set("text_body", value); }
    }

    /// <summary>
    /// Structured variable requirements. Required variables cannot define defaults;
    /// invalid combinations return 422. Set to `null` to clear the schema.
    /// </summary>
    public IReadOnlyDictionary<string, UpdateEmailTemplateRequestVariableSchemaItem>? VariableSchema {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, UpdateEmailTemplateRequestVariableSchemaItem>>(
                "variable_schema"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, UpdateEmailTemplateRequestVariableSchemaItem>?>(
                "variable_schema",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyList<string>? Variables {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "variables"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "variables",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Autoescape;
        _ = this.HtmlBody;
        _ = this.Name;
        _ = this.StrictVariables;
        _ = this.Subject;
        _ = this.TextBody;
        if (this.VariableSchema != null)
        {
            foreach (var item in this.VariableSchema.Values)
            {
                item.Validate();
            }
        }
        _ = this.Variables;
    }

    public UpdateEmailTemplateRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateEmailTemplateRequest (
        UpdateEmailTemplateRequest updateEmailTemplateRequest
    ) : base(updateEmailTemplateRequest)
    {  }
    #pragma warning restore CS8618

    public UpdateEmailTemplateRequest (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateEmailTemplateRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UpdateEmailTemplateRequestFromRaw.FromRawUnchecked"/>
    public static UpdateEmailTemplateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UpdateEmailTemplateRequestFromRaw : IFromRawJson<UpdateEmailTemplateRequest>
{
    /// <inheritdoc/>
    public UpdateEmailTemplateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UpdateEmailTemplateRequest.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<UpdateEmailTemplateRequestVariableSchemaItem, UpdateEmailTemplateRequestVariableSchemaItemFromRaw>))]
public sealed record class UpdateEmailTemplateRequestVariableSchemaItem : JsonModel
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

    public UpdateEmailTemplateRequestVariableSchemaItem ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateEmailTemplateRequestVariableSchemaItem (
        UpdateEmailTemplateRequestVariableSchemaItem updateEmailTemplateRequestVariableSchemaItem
    ) : base(updateEmailTemplateRequestVariableSchemaItem)
    {  }
    #pragma warning restore CS8618

    public UpdateEmailTemplateRequestVariableSchemaItem (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateEmailTemplateRequestVariableSchemaItem (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UpdateEmailTemplateRequestVariableSchemaItemFromRaw.FromRawUnchecked"/>
    public static UpdateEmailTemplateRequestVariableSchemaItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public UpdateEmailTemplateRequestVariableSchemaItem (bool required) : this()
    { this.Required = required; }
}class UpdateEmailTemplateRequestVariableSchemaItemFromRaw : IFromRawJson<UpdateEmailTemplateRequestVariableSchemaItem>
{
    /// <inheritdoc/>
    public UpdateEmailTemplateRequestVariableSchemaItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UpdateEmailTemplateRequestVariableSchemaItem.FromRawUnchecked(rawData);
}