using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Texml;

[JsonConverter(typeof(JsonModelConverter<TexmlInitiateAICallResponse, TexmlInitiateAICallResponseFromRaw>))]
public sealed record class TexmlInitiateAICallResponse : JsonModel
{
    public string? CallSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_sid", value);
        }
    }

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
        _ = this.CallSid;
        _ = this.From;
        _ = this.Status;
        _ = this.To;
    }

    public TexmlInitiateAICallResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlInitiateAICallResponse (
        TexmlInitiateAICallResponse texmlInitiateAICallResponse
    ) : base(texmlInitiateAICallResponse)
    {  }
    #pragma warning restore CS8618

    public TexmlInitiateAICallResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlInitiateAICallResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlInitiateAICallResponseFromRaw.FromRawUnchecked"/>
    public static TexmlInitiateAICallResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TexmlInitiateAICallResponseFromRaw : IFromRawJson<TexmlInitiateAICallResponse>
{
    /// <inheritdoc/>
    public TexmlInitiateAICallResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlInitiateAICallResponse.FromRawUnchecked(rawData);
}