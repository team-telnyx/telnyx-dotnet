using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Compute.Funcs;

[JsonConverter(typeof(JsonModelConverter<LogsMeta, LogsMetaFromRaw>))]
public sealed record class LogsMeta : JsonModel
{
    public bool? HasMore {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "has_more"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("has_more", value);
        }
    }

    public bool? Partial {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "partial"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("partial", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasMore;
        _ = this.Partial;
    }

    public LogsMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LogsMeta (LogsMeta logsMeta) : base(logsMeta)
    {  }
    #pragma warning restore CS8618

    public LogsMeta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LogsMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LogsMetaFromRaw.FromRawUnchecked"/>
    public static LogsMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class LogsMetaFromRaw : IFromRawJson<LogsMeta>
{
    /// <inheritdoc/>
    public LogsMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LogsMeta.FromRawUnchecked(rawData);
}