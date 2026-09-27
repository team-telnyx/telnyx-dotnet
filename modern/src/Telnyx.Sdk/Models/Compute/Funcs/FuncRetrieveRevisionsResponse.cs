using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Compute.Funcs;

[JsonConverter(typeof(JsonModelConverter<FuncRetrieveRevisionsResponse, FuncRetrieveRevisionsResponseFromRaw>))]
public sealed record class FuncRetrieveRevisionsResponse : JsonModel
{
    public bool? Active {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    public DateTimeOffset? BuildOkAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "build_ok_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("build_ok_at", value);
        }
    }

    public string? BuildStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "build_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("build_status", value);
        }
    }

    public string? CommitSha {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "commit_sha"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("commit_sha", value);
        }
    }

    public string? DeployStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "deploy_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("deploy_status", value);
        }
    }

    public string? FailureReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "failure_reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("failure_reason", value);
        }
    }

    public string? FailureStage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "failure_stage"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("failure_stage", value);
        }
    }

    public string? Image {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "image"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("image", value);
        }
    }

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

    public string? RevisionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "revision_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("revision_id", value);
        }
    }

    public DateTimeOffset? ShippedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "shipped_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shipped_at", value);
        }
    }

    public string? ShippedBy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "shipped_by"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shipped_by", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Active;
        _ = this.BuildOkAt;
        _ = this.BuildStatus;
        _ = this.CommitSha;
        _ = this.DeployStatus;
        _ = this.FailureReason;
        _ = this.FailureStage;
        _ = this.Image;
        _ = this.RecordType;
        _ = this.RevisionID;
        _ = this.ShippedAt;
        _ = this.ShippedBy;
    }

    public FuncRetrieveRevisionsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FuncRetrieveRevisionsResponse (
        FuncRetrieveRevisionsResponse funcRetrieveRevisionsResponse
    ) : base(funcRetrieveRevisionsResponse)
    {  }
    #pragma warning restore CS8618

    public FuncRetrieveRevisionsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FuncRetrieveRevisionsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FuncRetrieveRevisionsResponseFromRaw.FromRawUnchecked"/>
    public static FuncRetrieveRevisionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FuncRetrieveRevisionsResponseFromRaw : IFromRawJson<FuncRetrieveRevisionsResponse>
{
    /// <inheritdoc/>
    public FuncRetrieveRevisionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FuncRetrieveRevisionsResponse.FromRawUnchecked(rawData);
}