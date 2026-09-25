using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CallReasons;

/// <summary>
/// Pre-vetted call-reason library entry.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallReasonListResponse, CallReasonListResponseFromRaw>))]
public sealed record class CallReasonListResponse : JsonModel
{
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public string? Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        _ = this.Reason;
    }

    public CallReasonListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallReasonListResponse (
        CallReasonListResponse callReasonListResponse
    ) : base(callReasonListResponse)
    {  }
    #pragma warning restore CS8618

    public CallReasonListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallReasonListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallReasonListResponseFromRaw.FromRawUnchecked"/>
    public static CallReasonListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallReasonListResponseFromRaw : IFromRawJson<CallReasonListResponse>
{
    /// <inheritdoc/>
    public CallReasonListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallReasonListResponse.FromRawUnchecked(rawData);
}