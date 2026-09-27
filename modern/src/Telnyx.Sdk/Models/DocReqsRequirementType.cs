using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<DocReqsRequirementType, DocReqsRequirementTypeFromRaw>))]
public sealed record class DocReqsRequirementType : JsonModel
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
    /// Specifies objective criteria for acceptance
    /// </summary>
    public AcceptanceCriteria? AcceptanceCriteria {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AcceptanceCriteria>(
                "acceptance_criteria"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("acceptance_criteria", value);
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
    /// Describes the requirement type
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Provides one or more examples of acceptable documents
    /// </summary>
    public string? Example {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "example"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("example", value);
        }
    }

    /// <summary>
    /// A short descriptive name for this requirement_type
    /// </summary>
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
    /// Identifies the type of the resource
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
    /// Defines the type of this requirement type
    /// </summary>
    public ApiEnum<string, DocReqsRequirementTypeType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DocReqsRequirementTypeType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AcceptanceCriteria?.Validate();
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Example;
        _ = this.Name;
        _ = this.RecordType;
        this.Type?.Validate();
        _ = this.UpdatedAt;
    }

    public DocReqsRequirementType ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocReqsRequirementType (
        DocReqsRequirementType docReqsRequirementType
    ) : base(docReqsRequirementType)
    {  }
    #pragma warning restore CS8618

    public DocReqsRequirementType (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DocReqsRequirementType (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DocReqsRequirementTypeFromRaw.FromRawUnchecked"/>
    public static DocReqsRequirementType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DocReqsRequirementTypeFromRaw : IFromRawJson<DocReqsRequirementType>
{
    /// <inheritdoc/>
    public DocReqsRequirementType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DocReqsRequirementType.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies objective criteria for acceptance
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AcceptanceCriteria, AcceptanceCriteriaFromRaw>))]
public sealed record class AcceptanceCriteria : JsonModel
{
    /// <summary>
    /// Specifies the allowed characters as a string
    /// </summary>
    public string? AcceptableCharacters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "acceptable_characters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("acceptable_characters", value);
        }
    }

    /// <summary>
    /// Specifies the list of strictly possible values for the requirement. Ignored
    /// when empty
    /// </summary>
    public IReadOnlyList<string>? AcceptableValues {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "acceptable_values"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "acceptable_values",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Specifies geography-based acceptance criteria
    /// </summary>
    public string? LocalityLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "locality_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("locality_limit", value);
        }
    }

    /// <summary>
    /// Maximum length allowed for the value
    /// </summary>
    public long? MaxLength {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "max_length"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("max_length", value);
        }
    }

    /// <summary>
    /// Minimum length allowed for the value
    /// </summary>
    public long? MinLength {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "min_length"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("min_length", value);
        }
    }

    /// <summary>
    /// Specifies time-based acceptance criteria
    /// </summary>
    public string? TimeLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "time_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("time_limit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptableCharacters;
        _ = this.AcceptableValues;
        _ = this.LocalityLimit;
        _ = this.MaxLength;
        _ = this.MinLength;
        _ = this.TimeLimit;
    }

    public AcceptanceCriteria ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AcceptanceCriteria (AcceptanceCriteria acceptanceCriteria) : base(
        acceptanceCriteria
    )
    {  }
    #pragma warning restore CS8618

    public AcceptanceCriteria (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AcceptanceCriteria (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AcceptanceCriteriaFromRaw.FromRawUnchecked"/>
    public static AcceptanceCriteria FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class AcceptanceCriteriaFromRaw : IFromRawJson<AcceptanceCriteria>
{
    /// <inheritdoc/>
    public AcceptanceCriteria FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AcceptanceCriteria.FromRawUnchecked(rawData);
}/// <summary>
/// Defines the type of this requirement type
/// </summary>
[JsonConverter(typeof(DocReqsRequirementTypeTypeConverter))]
public enum DocReqsRequirementTypeType
{
    Document, Address, Textual
}sealed class DocReqsRequirementTypeTypeConverter : JsonConverter<DocReqsRequirementTypeType>
{
    public override DocReqsRequirementTypeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "document"=>DocReqsRequirementTypeType.Document,
            "address"=>DocReqsRequirementTypeType.Address,
            "textual"=>DocReqsRequirementTypeType.Textual,
            _ =>(DocReqsRequirementTypeType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DocReqsRequirementTypeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DocReqsRequirementTypeType.Document=>"document",
            DocReqsRequirementTypeType.Address=>"address",
            DocReqsRequirementTypeType.Textual=>"textual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}