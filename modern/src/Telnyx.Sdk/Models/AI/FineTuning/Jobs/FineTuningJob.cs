using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.FineTuning.Jobs;

/// <summary>
/// The `fine_tuning.job` object represents a fine-tuning job that has been created
/// through the API.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FineTuningJob, FineTuningJobFromRaw>))]
public sealed record class FineTuningJob : JsonModel
{
    /// <summary>
    /// The name of the fine-tuned model that is being created.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The Unix timestamp (in seconds) for when the fine-tuning job was created.
    /// </summary>
    public required long CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The Unix timestamp (in seconds) for when the fine-tuning job was finished.
    /// The value will be null if the fine-tuning job is still running.
    /// </summary>
    public required long? FinishedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "finished_at"
            );
        }
        init { this._rawData.Set("finished_at", value); }
    }

    /// <summary>
    /// The hyperparameters used for the fine-tuning job.
    /// </summary>
    public required FineTuningJobHyperparameters Hyperparameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FineTuningJobHyperparameters>(
                "hyperparameters"
            );
        }
        init { this._rawData.Set("hyperparameters", value); }
    }

    /// <summary>
    /// The base model that is being fine-tuned.
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
    /// The organization that owns the fine-tuning job.
    /// </summary>
    public required string OrganizationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "organization_id"
            );
        }
        init { this._rawData.Set("organization_id", value); }
    }

    /// <summary>
    /// The current status of the fine-tuning job.
    /// </summary>
    public required ApiEnum<string, Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The total number of billable tokens processed by this fine-tuning job. The
    /// value will be null if the fine-tuning job is still running.
    /// </summary>
    public required long? TrainedTokens {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "trained_tokens"
            );
        }
        init { this._rawData.Set("trained_tokens", value); }
    }

    /// <summary>
    /// The storage bucket or object used for training.
    /// </summary>
    public required string TrainingFile {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "training_file"
            );
        }
        init { this._rawData.Set("training_file", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.FinishedAt;
        this.Hyperparameters.Validate();
        _ = this.Model;
        _ = this.OrganizationID;
        this.Status.Validate();
        _ = this.TrainedTokens;
        _ = this.TrainingFile;
    }

    public FineTuningJob ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FineTuningJob (FineTuningJob fineTuningJob) : base(fineTuningJob)
    {  }
    #pragma warning restore CS8618

    public FineTuningJob (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FineTuningJob (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FineTuningJobFromRaw.FromRawUnchecked"/>
    public static FineTuningJob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FineTuningJobFromRaw : IFromRawJson<FineTuningJob>
{
    /// <inheritdoc/>
    public FineTuningJob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FineTuningJob.FromRawUnchecked(rawData);
}

/// <summary>
/// The hyperparameters used for the fine-tuning job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FineTuningJobHyperparameters, FineTuningJobHyperparametersFromRaw>))]
public sealed record class FineTuningJobHyperparameters : JsonModel
{
    /// <summary>
    /// The number of epochs to train the model for. An epoch refers to one full cycle
    /// through the training dataset.
    /// </summary>
    public required long NEpochs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "n_epochs"
            );
        }
        init { this._rawData.Set("n_epochs", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.NEpochs; }

    public FineTuningJobHyperparameters ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FineTuningJobHyperparameters (
        FineTuningJobHyperparameters fineTuningJobHyperparameters
    ) : base(fineTuningJobHyperparameters)
    {  }
    #pragma warning restore CS8618

    public FineTuningJobHyperparameters (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FineTuningJobHyperparameters (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FineTuningJobHyperparametersFromRaw.FromRawUnchecked"/>
    public static FineTuningJobHyperparameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public FineTuningJobHyperparameters (long nEpochs) : this()
    { this.NEpochs = nEpochs; }
}class FineTuningJobHyperparametersFromRaw : IFromRawJson<FineTuningJobHyperparameters>
{
    /// <inheritdoc/>
    public FineTuningJobHyperparameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FineTuningJobHyperparameters.FromRawUnchecked(rawData);
}/// <summary>
/// The current status of the fine-tuning job.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Queued, Running, Succeeded, Failed, Cancelled
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued"=>Status.Queued,
            "running"=>Status.Running,
            "succeeded"=>Status.Succeeded,
            "failed"=>Status.Failed,
            "cancelled"=>Status.Cancelled,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Queued=>"queued",
            Status.Running=>"running",
            Status.Succeeded=>"succeeded",
            Status.Failed=>"failed",
            Status.Cancelled=>"cancelled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}