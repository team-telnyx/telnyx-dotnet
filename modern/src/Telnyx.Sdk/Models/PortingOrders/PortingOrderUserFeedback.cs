using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrderUserFeedback, PortingOrderUserFeedbackFromRaw>))]
public sealed record class PortingOrderUserFeedback : JsonModel
{
    /// <summary>
    /// A comment related to the customer rating.
    /// </summary>
    public string? UserComment {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_comment"
            );
        }
        init { this._rawData.Set("user_comment", value); }
    }

    /// <summary>
    /// Once an order is ported, cancellation is requested or the request is cancelled,
    /// the user may rate their experience
    /// </summary>
    public long? UserRating {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "user_rating"
            );
        }
        init { this._rawData.Set("user_rating", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UserComment;
        _ = this.UserRating;
    }

    public PortingOrderUserFeedback ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderUserFeedback (
        PortingOrderUserFeedback portingOrderUserFeedback
    ) : base(portingOrderUserFeedback)
    {  }
    #pragma warning restore CS8618

    public PortingOrderUserFeedback (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderUserFeedback (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderUserFeedbackFromRaw.FromRawUnchecked"/>
    public static PortingOrderUserFeedback FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderUserFeedbackFromRaw : IFromRawJson<PortingOrderUserFeedback>
{
    /// <inheritdoc/>
    public PortingOrderUserFeedback FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderUserFeedback.FromRawUnchecked(rawData);
}