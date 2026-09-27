using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls;

[JsonConverter(typeof(JsonModelConverter<CallCallsResponse, CallCallsResponseFromRaw>))]
public sealed record class CallCallsResponse : JsonModel
{
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public string? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.From;
        _ = this.Status;
        _ = this.To;
    }

    public CallCallsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallCallsResponse (CallCallsResponse callCallsResponse) : base(
        callCallsResponse
    )
    {  }
    #pragma warning restore CS8618

    public CallCallsResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallCallsResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallCallsResponseFromRaw.FromRawUnchecked"/>
    public static CallCallsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallCallsResponseFromRaw : IFromRawJson<CallCallsResponse>
{
    /// <inheritdoc/>
    public CallCallsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallCallsResponse.FromRawUnchecked(rawData);
}