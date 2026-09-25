using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SpeechToText;

/// <summary>
/// List of supported STT providers and models.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SpeechToTextListProvidersResponse, SpeechToTextListProvidersResponseFromRaw>))]
public sealed record class SpeechToTextListProvidersResponse : JsonModel
{
    public required IReadOnlyList<Data> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Data>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Meta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public SpeechToTextListProvidersResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpeechToTextListProvidersResponse (
        SpeechToTextListProvidersResponse speechToTextListProvidersResponse
    ) : base(speechToTextListProvidersResponse)
    {  }
    #pragma warning restore CS8618

    public SpeechToTextListProvidersResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeechToTextListProvidersResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SpeechToTextListProvidersResponseFromRaw.FromRawUnchecked"/>
    public static SpeechToTextListProvidersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SpeechToTextListProvidersResponseFromRaw : IFromRawJson<SpeechToTextListProvidersResponse>
{
    /// <inheritdoc/>
    public SpeechToTextListProvidersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SpeechToTextListProvidersResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A (provider, model) tuple along with the service surfaces it supports. Each entry
/// in `service_types` describes one surface and the languages accepted on it.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Whether this model runs on Telnyx-hosted infrastructure (`true`) or is provided
    /// by a third-party vendor (`false`).
    /// </summary>
    public required bool Hosted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "hosted"
            );
        }
        init { this._rawData.Set("hosted", value); }
    }

    /// <summary>
    /// Provider-scoped model name.
    /// </summary>
    public required string Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "model"
            );
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// STT provider name.
    /// </summary>
    public required string Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "provider"
            );
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Service surfaces this (provider, model) supports. When the request filters
    /// by `service_type`, only the matching nested entry is returned for each matching model.
    /// </summary>
    public required IReadOnlyList<ServiceType> ServiceTypes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ServiceType>>(
                "service_types"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ServiceType>>(
                "service_types",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Hosted;
        _ = this.Model;
        _ = this.Provider;
        foreach (var item in this.ServiceTypes)
        {
            item.Validate();
        }
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
}/// <summary>
/// A supported service surface for a given (provider, model), along with the language
/// codes accepted on that surface. Language support can differ per surface — for
/// example, a model may accept a narrower language set for streaming than for file transcription.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ServiceType, ServiceTypeFromRaw>))]
public sealed record class ServiceType : JsonModel
{
    /// <summary>
    /// Languages accepted on this service surface, in the provider's native code
    /// format. `auto` indicates the provider performs language detection.
    /// </summary>
    public required IReadOnlyList<string> Languages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "languages"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "languages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Service surface a model is available on. `ai_assistant` is the STT surface
    /// configured via Call Control voice-assistant transcription; it covers both
    /// live-streaming and non-streaming/batch models (matching the `TranscriptionConfig.model`
    /// enum on `call-control` voice assistants).
    /// </summary>
    public required ApiEnum<string, SttServiceType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SttServiceType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Languages;
        this.Type.Validate();
    }

    public ServiceType ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ServiceType (ServiceType serviceType) : base(serviceType)
    {  }
    #pragma warning restore CS8618

    public ServiceType (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ServiceType (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ServiceTypeFromRaw.FromRawUnchecked"/>
    public static ServiceType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ServiceTypeFromRaw : IFromRawJson<ServiceType>
{
    /// <inheritdoc/>
    public ServiceType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ServiceType.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    /// <summary>
    /// Total number of entries returned.
    /// </summary>
    public required long Total {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total"
            );
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Total; }

    public Meta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta (Meta meta) : base(meta)
    {  }
    #pragma warning restore CS8618

    public Meta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Meta (long total) : this()
    { this.Total = total; }
}class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Meta.FromRawUnchecked(rawData);
}