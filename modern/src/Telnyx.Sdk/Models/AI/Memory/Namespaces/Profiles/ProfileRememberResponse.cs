using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles;

[JsonConverter(typeof(JsonModelConverter<ProfileRememberResponse, ProfileRememberResponseFromRaw>))]
public sealed record class ProfileRememberResponse : JsonModel
{
    public required ProfileRememberResponseData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProfileRememberResponseData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public ProfileRememberResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRememberResponse (
        ProfileRememberResponse profileRememberResponse
    ) : base(profileRememberResponse)
    {  }
    #pragma warning restore CS8618

    public ProfileRememberResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRememberResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRememberResponseFromRaw.FromRawUnchecked"/>
    public static ProfileRememberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ProfileRememberResponse (ProfileRememberResponseData data) : this()
    { this.Data = data; }
}

class ProfileRememberResponseFromRaw : IFromRawJson<ProfileRememberResponse>
{
    /// <inheritdoc/>
    public ProfileRememberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProfileRememberResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ProfileRememberResponseData, ProfileRememberResponseDataFromRaw>))]
public sealed record class ProfileRememberResponseData : JsonModel
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
        _ = this.SourceID;
    }

    public ProfileRememberResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRememberResponseData (
        ProfileRememberResponseData profileRememberResponseData
    ) : base(profileRememberResponseData)
    {  }
    #pragma warning restore CS8618

    public ProfileRememberResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRememberResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRememberResponseDataFromRaw.FromRawUnchecked"/>
    public static ProfileRememberResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ProfileRememberResponseDataFromRaw : IFromRawJson<ProfileRememberResponseData>
{
    /// <inheritdoc/>
    public ProfileRememberResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProfileRememberResponseData.FromRawUnchecked(rawData);
}