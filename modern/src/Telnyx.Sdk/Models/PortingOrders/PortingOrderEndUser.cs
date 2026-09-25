using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrderEndUser, PortingOrderEndUserFromRaw>))]
public sealed record class PortingOrderEndUser : JsonModel
{
    public PortingOrderEndUserAdmin? Admin {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrderEndUserAdmin>(
                "admin"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("admin", value);
        }
    }

    public PortingOrderEndUserLocation? Location {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrderEndUserLocation>(
                "location"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("location", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Admin?.Validate();
        this.Location?.Validate();
    }

    public PortingOrderEndUser ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderEndUser (PortingOrderEndUser portingOrderEndUser) : base(
        portingOrderEndUser
    )
    {  }
    #pragma warning restore CS8618

    public PortingOrderEndUser (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderEndUser (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderEndUserFromRaw.FromRawUnchecked"/>
    public static PortingOrderEndUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderEndUserFromRaw : IFromRawJson<PortingOrderEndUser>
{
    /// <inheritdoc/>
    public PortingOrderEndUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderEndUser.FromRawUnchecked(rawData);
}