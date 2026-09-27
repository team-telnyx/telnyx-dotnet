using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Requirements;

[JsonConverter(typeof(JsonModelConverter<DocReqsRequirement, DocReqsRequirementFromRaw>))]
public sealed record class DocReqsRequirement : JsonModel
{
    /// <summary>
    /// Identifies the associated document
    /// </summary>
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

    /// <summary>
    /// Indicates whether this requirement applies to branded_calling, ordering,
    /// porting, or both ordering and porting
    /// </summary>
    public ApiEnum<string, DocReqsRequirementAction>? Action {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DocReqsRequirementAction>>(
                "action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("action", value);
        }
    }

    /// <summary>
    /// The 2-character (ISO 3166-1 alpha-2) country code where this requirement applies
    /// </summary>
    public string? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <summary>
    /// When this version was superseded. NULL means this is the active or pending version.
    /// </summary>
    public System::DateTimeOffset? EffectiveEndAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "effective_end_at"
            );
        }
        init { this._rawData.Set("effective_end_at", value); }
    }

    /// <summary>
    /// When this version became (or will become) active.
    /// </summary>
    public System::DateTimeOffset? EffectiveStartAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "effective_start_at"
            );
        }
        init { this._rawData.Set("effective_start_at", value); }
    }

    /// <summary>
    /// The locality where this requirement applies
    /// </summary>
    public string? Locality {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "locality"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("locality", value);
        }
    }

    /// <summary>
    /// Indicates the phone_number_type this requirement applies to. Leave blank if
    /// this requirement applies to all number_types.
    /// </summary>
    public ApiEnum<string, DocReqsRequirementPhoneNumberType>? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DocReqsRequirementPhoneNumberType>>(
                "phone_number_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number_type", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
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

    /// <summary>
    /// Lists the requirement types necessary to fulfill this requirement
    /// </summary>
    public IReadOnlyList<DocReqsRequirementType>? RequirementTypes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DocReqsRequirementType>>(
                "requirement_types"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<DocReqsRequirementType>?>(
                "requirement_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was last updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <summary>
    /// Version number. Increments with each new version. Defaults to 1.
    /// </summary>
    public long? Version {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Action?.Validate();
        _ = this.CountryCode;
        _ = this.CreatedAt;
        _ = this.EffectiveEndAt;
        _ = this.EffectiveStartAt;
        _ = this.Locality;
        this.PhoneNumberType?.Validate();
        _ = this.RecordType;
        foreach (var item in this.RequirementTypes ?? [])
        {
            item.Validate();
        }
        _ = this.UpdatedAt;
        _ = this.Version;
    }

    public DocReqsRequirement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocReqsRequirement (DocReqsRequirement docReqsRequirement) : base(
        docReqsRequirement
    )
    {  }
    #pragma warning restore CS8618

    public DocReqsRequirement (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DocReqsRequirement (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DocReqsRequirementFromRaw.FromRawUnchecked"/>
    public static DocReqsRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DocReqsRequirementFromRaw : IFromRawJson<DocReqsRequirement>
{
    /// <inheritdoc/>
    public DocReqsRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DocReqsRequirement.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates whether this requirement applies to branded_calling, ordering, porting,
/// or both ordering and porting
/// </summary>
[JsonConverter(typeof(DocReqsRequirementActionConverter))]
public enum DocReqsRequirementAction
{
    Both, BrandedCalling, Ordering, Porting
}sealed class DocReqsRequirementActionConverter : JsonConverter<DocReqsRequirementAction>
{
    public override DocReqsRequirementAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "both"=>DocReqsRequirementAction.Both,
            "branded_calling"=>DocReqsRequirementAction.BrandedCalling,
            "ordering"=>DocReqsRequirementAction.Ordering,
            "porting"=>DocReqsRequirementAction.Porting,
            _ =>(DocReqsRequirementAction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DocReqsRequirementAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DocReqsRequirementAction.Both=>"both",
            DocReqsRequirementAction.BrandedCalling=>"branded_calling",
            DocReqsRequirementAction.Ordering=>"ordering",
            DocReqsRequirementAction.Porting=>"porting",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Indicates the phone_number_type this requirement applies to. Leave blank if this
/// requirement applies to all number_types.
/// </summary>
[JsonConverter(typeof(DocReqsRequirementPhoneNumberTypeConverter))]
public enum DocReqsRequirementPhoneNumberType
{
    Local, National, TollFree
}sealed class DocReqsRequirementPhoneNumberTypeConverter : JsonConverter<DocReqsRequirementPhoneNumberType>
{
    public override DocReqsRequirementPhoneNumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>DocReqsRequirementPhoneNumberType.Local,
            "national"=>DocReqsRequirementPhoneNumberType.National,
            "toll_free"=>DocReqsRequirementPhoneNumberType.TollFree,
            _ =>(DocReqsRequirementPhoneNumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DocReqsRequirementPhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DocReqsRequirementPhoneNumberType.Local=>"local",
            DocReqsRequirementPhoneNumberType.National=>"national",
            DocReqsRequirementPhoneNumberType.TollFree=>"toll_free",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}