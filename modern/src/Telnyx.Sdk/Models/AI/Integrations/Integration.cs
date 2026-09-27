using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Integrations;

[JsonConverter(typeof(JsonModelConverter<Integration, IntegrationFromRaw>))]
public sealed record class Integration : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required IReadOnlyList<string> AvailableTools {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "available_tools"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "available_tools",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    public required string DisplayName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "display_name"
            );
        }
        init { this._rawData.Set("display_name", value); }
    }

    public required string LogoUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "logo_url"
            );
        }
        init { this._rawData.Set("logo_url", value); }
    }

    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    public required ApiEnum<string, Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AvailableTools;
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.LogoUrl;
        _ = this.Name;
        this.Status.Validate();
    }

    public Integration ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Integration (Integration integration) : base(integration)
    {  }
    #pragma warning restore CS8618

    public Integration (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Integration (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationFromRaw.FromRawUnchecked"/>
    public static Integration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IntegrationFromRaw : IFromRawJson<Integration>
{
    /// <inheritdoc/>
    public Integration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Integration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Disconnected, Connected
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disconnected"=>Status.Disconnected,
            "connected"=>Status.Connected,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Disconnected=>"disconnected",
            Status.Connected=>"connected",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}