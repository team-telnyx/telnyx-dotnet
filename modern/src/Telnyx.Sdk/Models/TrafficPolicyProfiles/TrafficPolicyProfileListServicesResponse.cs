using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TrafficPolicyProfiles;

[JsonConverter(typeof(JsonModelConverter<TrafficPolicyProfileListServicesResponse, TrafficPolicyProfileListServicesResponseFromRaw>))]
public sealed record class TrafficPolicyProfileListServicesResponse : JsonModel
{
    /// <summary>
    /// The service identifier.
    /// </summary>
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

    /// <summary>
    /// The group the service belongs to.
    /// </summary>
    public string? Group {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "group"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("group", value);
        }
    }

    /// <summary>
    /// The name of the service.
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

    public string? ResourceType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "resource_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("resource_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Group;
        _ = this.Name;
        _ = this.ResourceType;
    }

    public TrafficPolicyProfileListServicesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrafficPolicyProfileListServicesResponse (
        TrafficPolicyProfileListServicesResponse trafficPolicyProfileListServicesResponse
    ) : base(trafficPolicyProfileListServicesResponse)
    {  }
    #pragma warning restore CS8618

    public TrafficPolicyProfileListServicesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TrafficPolicyProfileListServicesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TrafficPolicyProfileListServicesResponseFromRaw.FromRawUnchecked"/>
    public static TrafficPolicyProfileListServicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TrafficPolicyProfileListServicesResponseFromRaw : IFromRawJson<TrafficPolicyProfileListServicesResponse>
{
    /// <inheritdoc/>
    public TrafficPolicyProfileListServicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TrafficPolicyProfileListServicesResponse.FromRawUnchecked(rawData);
}