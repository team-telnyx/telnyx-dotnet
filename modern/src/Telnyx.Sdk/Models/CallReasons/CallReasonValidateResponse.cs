using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CallReasons;

[JsonConverter(typeof(JsonModelConverter<CallReasonValidateResponse, CallReasonValidateResponseFromRaw>))]
public sealed record class CallReasonValidateResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public CallReasonValidateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallReasonValidateResponse (
        CallReasonValidateResponse callReasonValidateResponse
    ) : base(callReasonValidateResponse)
    {  }
    #pragma warning restore CS8618

    public CallReasonValidateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallReasonValidateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallReasonValidateResponseFromRaw.FromRawUnchecked"/>
    public static CallReasonValidateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public CallReasonValidateResponse (Data data) : this()
    { this.Data = data; }
}

class CallReasonValidateResponseFromRaw : IFromRawJson<CallReasonValidateResponse>
{
    /// <inheritdoc/>
    public CallReasonValidateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallReasonValidateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// `true` when every supplied reason matches a pre-vetted entry in the call-reason
    /// library. When `true`, the DIR will sail through the call-reasons portion of vetting.
    /// </summary>
    public required bool AllPreApproved {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "all_pre_approved"
            );
        }
        init { this._rawData.Set("all_pre_approved", value); }
    }

    /// <summary>
    /// Subset of the input that does NOT match the pre-vetted library. The DIR can
    /// still be submitted with these - they will go through manual review.
    /// </summary>
    public required IReadOnlyList<string> NonApprovedReasons {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "non_approved_reasons"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "non_approved_reasons",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// `true` when at least one supplied reason is in `non_approved_reasons`. Equivalent
    /// to `non_approved_reasons.length &gt; 0` and the inverse of `all_pre_approved`.
    /// </summary>
    public required bool RequiresManualVetting {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "requires_manual_vetting"
            );
        }
        init { this._rawData.Set("requires_manual_vetting", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllPreApproved;
        _ = this.NonApprovedReasons;
        _ = this.RequiresManualVetting;
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
}