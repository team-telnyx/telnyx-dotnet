using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// A standalone scripted-message step in a flow, as supplied by clients.
///
/// <para>Unlike a prompt node, a speak node has no instructions or model — it isn't
/// an LLM turn. Reaching it delivers `message` to the user verbatim (with `{{variable}}`
/// interpolation), then routes via outgoing `llm` / `expression` edges.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SpeakNodeReq, SpeakNodeReqFromRaw>))]
public sealed record class SpeakNodeReq : JsonModel
{
    /// <summary>
    /// Caller-supplied unique identifier for this node within the flow.
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
    /// Message delivered to the user verbatim when the flow reaches this node. No
    /// LLM turn — the text is spoken/sent exactly as written. `{{variable}}` placeholders
    /// are interpolated from the conversation's dynamic variables; an unresolved
    /// placeholder renders as an empty string. After delivering, the flow routes
    /// via the node's outgoing `llm` / `expression` edges (commonly a single unconditional edge).
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
    /// Optional human-readable label, displayed in authoring UIs.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Optional canvas coordinates used by authoring UIs to lay out the graph. Ignored
    /// by the runtime; round-trips so frontends can persist graph layout across reloads.
    /// </summary>
    public NodePosition? Position {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NodePosition>(
                "position"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("position", value);
        }
    }

    /// <summary>
    /// Node kind discriminator. Always `speak` for a speak node.
    /// </summary>
    public ApiEnum<string, SpeakNodeReqType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SpeakNodeReqType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Message;
        _ = this.Name;
        this.Position?.Validate();
        this.Type?.Validate();
    }

    public SpeakNodeReq ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpeakNodeReq (SpeakNodeReq speakNodeReq) : base(speakNodeReq)
    {  }
    #pragma warning restore CS8618

    public SpeakNodeReq (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeakNodeReq (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SpeakNodeReqFromRaw.FromRawUnchecked"/>
    public static SpeakNodeReq FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SpeakNodeReqFromRaw : IFromRawJson<SpeakNodeReq>
{
    /// <inheritdoc/>
    public SpeakNodeReq FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SpeakNodeReq.FromRawUnchecked(rawData);
}

/// <summary>
/// Node kind discriminator. Always `speak` for a speak node.
/// </summary>
[JsonConverter(typeof(SpeakNodeReqTypeConverter))]
public enum SpeakNodeReqType
{
    Speak
}sealed class SpeakNodeReqTypeConverter : JsonConverter<SpeakNodeReqType>
{
    public override SpeakNodeReqType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "speak"=>SpeakNodeReqType.Speak, _ =>(SpeakNodeReqType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SpeakNodeReqType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SpeakNodeReqType.Speak=>"speak",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}