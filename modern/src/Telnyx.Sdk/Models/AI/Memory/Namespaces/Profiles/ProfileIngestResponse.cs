using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles;

[JsonConverter(typeof(JsonModelConverter<ProfileIngestResponse, ProfileIngestResponseFromRaw>))]
public sealed record class ProfileIngestResponse : JsonModel
{
    public required ProfileIngestResponseData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProfileIngestResponseData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public ProfileIngestResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileIngestResponse (
        ProfileIngestResponse profileIngestResponse
    ) : base(profileIngestResponse)
    {  }
    #pragma warning restore CS8618

    public ProfileIngestResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileIngestResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProfileIngestResponseFromRaw.FromRawUnchecked"/>
    public static ProfileIngestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ProfileIngestResponse (ProfileIngestResponseData data) : this()
    { this.Data = data; }
}

class ProfileIngestResponseFromRaw : IFromRawJson<ProfileIngestResponse>
{
    /// <inheritdoc/>
    public ProfileIngestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProfileIngestResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ProfileIngestResponseData, ProfileIngestResponseDataFromRaw>))]
public sealed record class ProfileIngestResponseData : JsonModel
{
    public required string OperationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "operation_id"
            );
        }
        init { this._rawData.Set("operation_id", value); }
    }

    public required string ProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "profile_id"
            );
        }
        init { this._rawData.Set("profile_id", value); }
    }

    public required string SessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "session_id"
            );
        }
        init { this._rawData.Set("session_id", value); }
    }

    /// <summary>
    /// Identifies one source within its profile: an ingested session, or one remembered
    /// fact. Returned by `ingest` and `remember` when the write is accepted. Re-ingesting
    /// a session keeps its source id.
    /// </summary>
    public required string SourceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "source_id"
            );
        }
        init { this._rawData.Set("source_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OperationID;
        _ = this.ProfileID;
        _ = this.SessionID;
        _ = this.SourceID;
    }

    public ProfileIngestResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileIngestResponseData (
        ProfileIngestResponseData profileIngestResponseData
    ) : base(profileIngestResponseData)
    {  }
    #pragma warning restore CS8618

    public ProfileIngestResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileIngestResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProfileIngestResponseDataFromRaw.FromRawUnchecked"/>
    public static ProfileIngestResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ProfileIngestResponseDataFromRaw : IFromRawJson<ProfileIngestResponseData>
{
    /// <inheritdoc/>
    public ProfileIngestResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProfileIngestResponseData.FromRawUnchecked(rawData);
}