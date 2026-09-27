using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailInboxes.Filters;

[JsonConverter(typeof(JsonModelConverter<InboxFilters, InboxFiltersFromRaw>))]
public sealed record class InboxFilters : JsonModel
{
    public required IReadOnlyList<string> Allowlist {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "allowlist"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "allowlist",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<string> Blocklist {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "blocklist"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "blocklist",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Allowlist;
        _ = this.Blocklist;
        this.RecordType.Validate();
    }

    public InboxFilters ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboxFilters (InboxFilters inboxFilters) : base(inboxFilters)
    {  }
    #pragma warning restore CS8618

    public InboxFilters (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboxFilters (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboxFiltersFromRaw.FromRawUnchecked"/>
    public static InboxFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InboxFiltersFromRaw : IFromRawJson<InboxFilters>
{
    /// <inheritdoc/>
    public InboxFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboxFilters.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    EmailInboxFilters
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email_inbox_filters"=>RecordType.EmailInboxFilters,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.EmailInboxFilters=>"email_inbox_filters",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}