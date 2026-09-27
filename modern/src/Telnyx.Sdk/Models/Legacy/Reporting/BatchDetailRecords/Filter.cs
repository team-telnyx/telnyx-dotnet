using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords;

/// <summary>
/// Query filter criteria. Note: The first filter object must specify filter_type
/// as 'and'. You cannot follow an 'or' with another 'and'.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Billing group UUID to filter by
    /// </summary>
    public string? BillingGroup {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "billing_group"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("billing_group", value);
        }
    }

    /// <summary>
    /// Called line identification (destination number)
    /// </summary>
    public string? Cld {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cld"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cld", value);
        }
    }

    /// <summary>
    /// Filter type for CLD matching
    /// </summary>
    public ApiEnum<string, CldFilter>? CldFilter {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CldFilter>>(
                "cld_filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cld_filter", value);
        }
    }

    /// <summary>
    /// Calling line identification (caller ID)
    /// </summary>
    public string? Cli {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cli"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cli", value);
        }
    }

    /// <summary>
    /// Filter type for CLI matching
    /// </summary>
    public ApiEnum<string, CliFilter>? CliFilter {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CliFilter>>(
                "cli_filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cli_filter", value);
        }
    }

    /// <summary>
    /// Logical operator for combining filters
    /// </summary>
    public ApiEnum<string, FilterType>? FilterType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FilterType>>(
                "filter_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("filter_type", value);
        }
    }

    /// <summary>
    /// Tag name to filter by
    /// </summary>
    public string? TagsList {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tags_list"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tags_list", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BillingGroup;
        _ = this.Cld;
        this.CldFilter?.Validate();
        _ = this.Cli;
        this.CliFilter?.Validate();
        this.FilterType?.Validate();
        _ = this.TagsList;
    }

    public Filter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter (Filter filter) : base(filter)
    {  }
    #pragma warning restore CS8618

    public Filter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter type for CLD matching
/// </summary>
[JsonConverter(typeof(CldFilterConverter))]
public enum CldFilter
{
    Contains, StartsWith, EndsWith
}sealed class CldFilterConverter : JsonConverter<CldFilter>
{
    public override CldFilter Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "contains"=>CldFilter.Contains,
            "starts_with"=>CldFilter.StartsWith,
            "ends_with"=>CldFilter.EndsWith,
            _ =>(CldFilter)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, CldFilter value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CldFilter.Contains=>"contains",
            CldFilter.StartsWith=>"starts_with",
            CldFilter.EndsWith=>"ends_with",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Filter type for CLI matching
/// </summary>
[JsonConverter(typeof(CliFilterConverter))]
public enum CliFilter
{
    Contains, StartsWith, EndsWith
}sealed class CliFilterConverter : JsonConverter<CliFilter>
{
    public override CliFilter Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "contains"=>CliFilter.Contains,
            "starts_with"=>CliFilter.StartsWith,
            "ends_with"=>CliFilter.EndsWith,
            _ =>(CliFilter)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, CliFilter value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CliFilter.Contains=>"contains",
            CliFilter.StartsWith=>"starts_with",
            CliFilter.EndsWith=>"ends_with",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Logical operator for combining filters
/// </summary>
[JsonConverter(typeof(FilterTypeConverter))]
public enum FilterType
{
    And, Or
}sealed class FilterTypeConverter : JsonConverter<FilterType>
{
    public override FilterType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "and"=>FilterType.And, "or"=>FilterType.Or, _ =>(FilterType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, FilterType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FilterType.And=>"and",
            FilterType.Or=>"or",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}