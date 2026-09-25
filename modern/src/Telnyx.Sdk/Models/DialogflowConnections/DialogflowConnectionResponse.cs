using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.DialogflowConnections;

[JsonConverter(typeof(JsonModelConverter<DialogflowConnectionResponse, DialogflowConnectionResponseFromRaw>))]
public sealed record class DialogflowConnectionResponse : JsonModel
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

    public DialogflowConnectionResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DialogflowConnectionResponse (
        DialogflowConnectionResponse dialogflowConnectionResponse
    ) : base(dialogflowConnectionResponse)
    {  }
    #pragma warning restore CS8618

    public DialogflowConnectionResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DialogflowConnectionResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DialogflowConnectionResponseFromRaw.FromRawUnchecked"/>
    public static DialogflowConnectionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public DialogflowConnectionResponse (Data data) : this()
    { this.Data = data; }
}

class DialogflowConnectionResponseFromRaw : IFromRawJson<DialogflowConnectionResponse>
{
    /// <inheritdoc/>
    public DialogflowConnectionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DialogflowConnectionResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Uniquely identifies a Telnyx application (Call Control).
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_id", value);
        }
    }

    /// <summary>
    /// The id of a configured conversation profile on your Dialogflow account. (If
    /// you use Dialogflow CX, this param is required)
    /// </summary>
    public string? ConversationProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conversation_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conversation_profile_id", value);
        }
    }

    /// <summary>
    /// Which Dialogflow environment will be used.
    /// </summary>
    public string? Environment {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "environment"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("environment", value);
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

    /// <summary>
    /// The JSON map to connect your Dialoglow account.
    /// </summary>
    public string? ServiceAccount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "service_account"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("service_account", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConnectionID;
        _ = this.ConversationProfileID;
        _ = this.Environment;
        _ = this.RecordType;
        _ = this.ServiceAccount;
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