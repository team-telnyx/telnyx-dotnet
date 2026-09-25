using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MeetingSessions.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionAcceptedResponse, ActionAcceptedResponseFromRaw>))]
public sealed record class ActionAcceptedResponse : JsonModel
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

    public ActionAcceptedResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionAcceptedResponse (
        ActionAcceptedResponse actionAcceptedResponse
    ) : base(actionAcceptedResponse)
    {  }
    #pragma warning restore CS8618

    public ActionAcceptedResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionAcceptedResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionAcceptedResponseFromRaw.FromRawUnchecked"/>
    public static ActionAcceptedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ActionAcceptedResponse (Data data) : this()
    { this.Data = data; }
}

class ActionAcceptedResponseFromRaw : IFromRawJson<ActionAcceptedResponse>
{
    /// <inheritdoc/>
    public ActionAcceptedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionAcceptedResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public required bool Accepted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "accepted"
            );
        }
        init { this._rawData.Set("accepted", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Accepted; }

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

    [SetsRequiredMembers]
    public Data (bool accepted) : this()
    { this.Accepted = accepted; }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}