using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.FineTuning.Jobs;

/// <summary>
/// Creates a new fine-tuning job that trains a model on the provided dataset, and
/// returns the created job.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class JobCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The base model that is being fine-tuned.
    /// </summary>
    public required string Model {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "model"
            );
        }
        init { this._rawBodyData.Set("model", value); }
    }

    /// <summary>
    /// The storage bucket or object used for training.
    /// </summary>
    public required string TrainingFile {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "training_file"
            );
        }
        init { this._rawBodyData.Set("training_file", value); }
    }

    /// <summary>
    /// The hyperparameters used for the fine-tuning job.
    /// </summary>
    public Hyperparameters? Hyperparameters {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Hyperparameters>(
                "hyperparameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("hyperparameters", value);
        }
    }

    /// <summary>
    /// Optional suffix to append to the fine tuned model's name.
    /// </summary>
    public string? Suffix {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "suffix"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("suffix", value);
        }
    }

    public JobCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobCreateParams (JobCreateParams jobCreateParams) : base(
        jobCreateParams
    )
    { this._rawBodyData = new(jobCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public JobCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    JobCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static JobCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(JobCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/ai/fine_tuning/jobs"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// The hyperparameters used for the fine-tuning job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Hyperparameters, HyperparametersFromRaw>))]
public sealed record class Hyperparameters : JsonModel
{
    /// <summary>
    /// The number of epochs to train the model for. An epoch refers to one full cycle
    /// through the training dataset. 'auto' decides the optimal number of epochs
    /// based on the size of the dataset. If setting the number manually, we support
    /// any number between 1 and 50 epochs.
    /// </summary>
    public long? NEpochs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "n_epochs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("n_epochs", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.NEpochs; }

    public Hyperparameters ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Hyperparameters (Hyperparameters hyperparameters) : base(
        hyperparameters
    )
    {  }
    #pragma warning restore CS8618

    public Hyperparameters (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Hyperparameters (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HyperparametersFromRaw.FromRawUnchecked"/>
    public static Hyperparameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class HyperparametersFromRaw : IFromRawJson<Hyperparameters>
{
    /// <inheritdoc/>
    public Hyperparameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Hyperparameters.FromRawUnchecked(rawData);
}