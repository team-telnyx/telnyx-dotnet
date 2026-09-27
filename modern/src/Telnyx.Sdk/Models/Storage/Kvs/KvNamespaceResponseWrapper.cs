using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Kvs;

[JsonConverter(typeof(JsonModelConverter<KvNamespaceResponseWrapper, KvNamespaceResponseWrapperFromRaw>))]
public sealed record class KvNamespaceResponseWrapper : JsonModel
{
    public KvNamespace? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<KvNamespace>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public KvNamespaceResponseWrapper ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public KvNamespaceResponseWrapper (
        KvNamespaceResponseWrapper kvNamespaceResponseWrapper
    ) : base(kvNamespaceResponseWrapper)
    {  }
    #pragma warning restore CS8618

    public KvNamespaceResponseWrapper (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    KvNamespaceResponseWrapper (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="KvNamespaceResponseWrapperFromRaw.FromRawUnchecked"/>
    public static KvNamespaceResponseWrapper FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class KvNamespaceResponseWrapperFromRaw : IFromRawJson<KvNamespaceResponseWrapper>
{
    /// <inheritdoc/>
    public KvNamespaceResponseWrapper FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>KvNamespaceResponseWrapper.FromRawUnchecked(rawData);
}