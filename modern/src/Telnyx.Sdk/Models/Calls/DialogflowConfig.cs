using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls;

[JsonConverter(typeof(JsonModelConverter<DialogflowConfig, DialogflowConfigFromRaw>))]
public sealed record class DialogflowConfig : JsonModel
{
    /// <summary>
    /// Enable sentiment analysis from Dialogflow.
    /// </summary>
    public bool? AnalyzeSentiment {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "analyze_sentiment"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("analyze_sentiment", value);
        }
    }

    /// <summary>
    /// Enable partial automated agent reply from Dialogflow.
    /// </summary>
    public bool? PartialAutomatedAgentReply {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "partial_automated_agent_reply"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("partial_automated_agent_reply", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AnalyzeSentiment;
        _ = this.PartialAutomatedAgentReply;
    }

    public DialogflowConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DialogflowConfig (DialogflowConfig dialogflowConfig) : base(
        dialogflowConfig
    )
    {  }
    #pragma warning restore CS8618

    public DialogflowConfig (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DialogflowConfig (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DialogflowConfigFromRaw.FromRawUnchecked"/>
    public static DialogflowConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DialogflowConfigFromRaw : IFromRawJson<DialogflowConfig>
{
    /// <inheritdoc/>
    public DialogflowConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DialogflowConfig.FromRawUnchecked(rawData);
}