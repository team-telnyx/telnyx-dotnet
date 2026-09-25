using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.ConversationalComponents;

[JsonConverter(typeof(JsonModelConverter<WhatsappConversationalComponent, WhatsappConversationalComponentFromRaw>))]
public sealed record class WhatsappConversationalComponent : JsonModel
{
    /// <summary>
    /// List of commands
    /// </summary>
    public IReadOnlyList<WhatsappConversationalComponentCommand>? Commands {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WhatsappConversationalComponentCommand>>(
                "commands"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WhatsappConversationalComponentCommand>?>(
                "commands",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of ice breakers
    /// </summary>
    public IReadOnlyList<string>? IceBreakers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "ice_breakers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "ice_breakers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Phone number in E164 format
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Commands ?? [])
        {
            item.Validate();
        }
        _ = this.IceBreakers;
        _ = this.PhoneNumber;
        _ = this.RecordType;
    }

    public WhatsappConversationalComponent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappConversationalComponent (
        WhatsappConversationalComponent whatsappConversationalComponent
    ) : base(whatsappConversationalComponent)
    {  }
    #pragma warning restore CS8618

    public WhatsappConversationalComponent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappConversationalComponent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappConversationalComponentFromRaw.FromRawUnchecked"/>
    public static WhatsappConversationalComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappConversationalComponentFromRaw : IFromRawJson<WhatsappConversationalComponent>
{
    /// <inheritdoc/>
    public WhatsappConversationalComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappConversationalComponent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<WhatsappConversationalComponentCommand, WhatsappConversationalComponentCommandFromRaw>))]
public sealed record class WhatsappConversationalComponentCommand : JsonModel
{
    public string? Command {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "command"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("command", value);
        }
    }

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Command;
        _ = this.Description;
    }

    public WhatsappConversationalComponentCommand ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappConversationalComponentCommand (
        WhatsappConversationalComponentCommand whatsappConversationalComponentCommand
    ) : base(whatsappConversationalComponentCommand)
    {  }
    #pragma warning restore CS8618

    public WhatsappConversationalComponentCommand (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappConversationalComponentCommand (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappConversationalComponentCommandFromRaw.FromRawUnchecked"/>
    public static WhatsappConversationalComponentCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WhatsappConversationalComponentCommandFromRaw : IFromRawJson<WhatsappConversationalComponentCommand>
{
    /// <inheritdoc/>
    public WhatsappConversationalComponentCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappConversationalComponentCommand.FromRawUnchecked(rawData);
}