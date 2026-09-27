using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BotSignup;

/// <summary>
/// Status envelope used by the signup and magic-link flows.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SuccessResponse, SuccessResponseFromRaw>))]
public sealed record class SuccessResponse : JsonModel
{
    /// <summary>
    /// Human-readable status message.
    /// </summary>
    public required string Message {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "message"
            );
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// Whether the request was accepted.
    /// </summary>
    public required bool Success {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "success"
            );
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Success;
    }

    public SuccessResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SuccessResponse (SuccessResponse successResponse) : base(
        successResponse
    )
    {  }
    #pragma warning restore CS8618

    public SuccessResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SuccessResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SuccessResponseFromRaw.FromRawUnchecked"/>
    public static SuccessResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SuccessResponseFromRaw : IFromRawJson<SuccessResponse>
{
    /// <inheritdoc/>
    public SuccessResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SuccessResponse.FromRawUnchecked(rawData);
}