using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<WhatsappTemplateData, WhatsappTemplateDataFromRaw>))]
public sealed record class WhatsappTemplateData : JsonModel
{
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

    public ApiEnum<string, Category>? Category {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Category>>(
                "category"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("category", value);
        }
    }

    /// <summary>
    /// Template components (header, body, footer, buttons) as submitted, including
    /// example values.
    /// </summary>
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? Components {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "components"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "components",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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

    public string? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "language"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("language", value);
        }
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

    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    public string? RejectionReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rejection_reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rejection_reason", value);
        }
    }

    /// <summary>
    /// Current template status from Meta (e.g. PENDING, APPROVED, REJECTED, PAUSED,
    /// DISABLED). Additional statuses may be returned as Meta evolves the template lifecycle.
    /// </summary>
    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public string? TemplateID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "template_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("template_id", value);
        }
    }

    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    public WhatsappBusinessAccount? WhatsappBusinessAccount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappBusinessAccount>(
                "whatsapp_business_account"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("whatsapp_business_account", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Category?.Validate();
        _ = this.Components;
        _ = this.CreatedAt;
        _ = this.Language;
        _ = this.Name;
        _ = this.RecordType;
        _ = this.RejectionReason;
        _ = this.Status;
        _ = this.TemplateID;
        _ = this.UpdatedAt;
        this.WhatsappBusinessAccount?.Validate();
    }

    public WhatsappTemplateData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappTemplateData (
        WhatsappTemplateData whatsappTemplateData
    ) : base(whatsappTemplateData)
    {  }
    #pragma warning restore CS8618

    public WhatsappTemplateData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappTemplateData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappTemplateDataFromRaw.FromRawUnchecked"/>
    public static WhatsappTemplateData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappTemplateDataFromRaw : IFromRawJson<WhatsappTemplateData>
{
    /// <inheritdoc/>
    public WhatsappTemplateData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappTemplateData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    Marketing, Utility, Authentication
}sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MARKETING"=>Category.Marketing,
            "UTILITY"=>Category.Utility,
            "AUTHENTICATION"=>Category.Authentication,
            _ =>(Category)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Category value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Category.Marketing=>"MARKETING",
            Category.Utility=>"UTILITY",
            Category.Authentication=>"AUTHENTICATION",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<WhatsappBusinessAccount, WhatsappBusinessAccountFromRaw>))]
public sealed record class WhatsappBusinessAccount : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.ID; }

    public WhatsappBusinessAccount ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappBusinessAccount (
        WhatsappBusinessAccount whatsappBusinessAccount
    ) : base(whatsappBusinessAccount)
    {  }
    #pragma warning restore CS8618

    public WhatsappBusinessAccount (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappBusinessAccount (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappBusinessAccountFromRaw.FromRawUnchecked"/>
    public static WhatsappBusinessAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WhatsappBusinessAccountFromRaw : IFromRawJson<WhatsappBusinessAccount>
{
    /// <inheritdoc/>
    public WhatsappBusinessAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappBusinessAccount.FromRawUnchecked(rawData);
}