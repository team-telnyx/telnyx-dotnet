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

[JsonConverter(typeof(JsonModelConverter<MutateInboxFiltersRequest, MutateInboxFiltersRequestFromRaw>))]
public sealed record class MutateInboxFiltersRequest : JsonModel
{
    public required IReadOnlyList<string> Entries {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "entries"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "entries",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The list to change.
    /// </summary>
    public required ApiEnum<string, MutateInboxFiltersRequestType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MutateInboxFiltersRequestType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Entries;
        this.Type.Validate();
    }

    public MutateInboxFiltersRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MutateInboxFiltersRequest (
        MutateInboxFiltersRequest mutateInboxFiltersRequest
    ) : base(mutateInboxFiltersRequest)
    {  }
    #pragma warning restore CS8618

    public MutateInboxFiltersRequest (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MutateInboxFiltersRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MutateInboxFiltersRequestFromRaw.FromRawUnchecked"/>
    public static MutateInboxFiltersRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MutateInboxFiltersRequestFromRaw : IFromRawJson<MutateInboxFiltersRequest>
{
    /// <inheritdoc/>
    public MutateInboxFiltersRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MutateInboxFiltersRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// The list to change.
/// </summary>
[JsonConverter(typeof(MutateInboxFiltersRequestTypeConverter))]
public enum MutateInboxFiltersRequestType
{
    Allowlist, Blocklist
}sealed class MutateInboxFiltersRequestTypeConverter : JsonConverter<MutateInboxFiltersRequestType>
{
    public override MutateInboxFiltersRequestType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allowlist"=>MutateInboxFiltersRequestType.Allowlist,
            "blocklist"=>MutateInboxFiltersRequestType.Blocklist,
            _ =>(MutateInboxFiltersRequestType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MutateInboxFiltersRequestType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MutateInboxFiltersRequestType.Allowlist=>"allowlist",
            MutateInboxFiltersRequestType.Blocklist=>"blocklist",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}