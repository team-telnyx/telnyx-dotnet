using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<MessagingError, MessagingErrorFromRaw>))]
public sealed record class MessagingError : JsonModel
{
    public required string Code {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "code"
            );
        }
        init { this._rawData.Set("code", value); }
    }

    public required string Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "title"
            );
        }
        init { this._rawData.Set("title", value); }
    }

    public string? Detail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "detail"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("detail", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "meta",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public MessagingErrorSource? Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingErrorSource>(
                "source"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Title;
        _ = this.Detail;
        _ = this.Meta;
        this.Source?.Validate();
    }

    public MessagingError ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingError (MessagingError messagingError) : base(messagingError)
    {  }
    #pragma warning restore CS8618

    public MessagingError (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingError (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingErrorFromRaw.FromRawUnchecked"/>
    public static MessagingError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingErrorFromRaw : IFromRawJson<MessagingError>
{
    /// <inheritdoc/>
    public MessagingError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MessagingErrorSource, MessagingErrorSourceFromRaw>))]
public sealed record class MessagingErrorSource : JsonModel
{
    /// <summary>
    /// Indicates which query parameter caused the error.
    /// </summary>
    public string? Parameter {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "parameter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("parameter", value);
        }
    }

    /// <summary>
    /// JSON pointer (RFC6901) to the offending entity.
    /// </summary>
    public string? Pointer {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "pointer"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pointer", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Parameter;
        _ = this.Pointer;
    }

    public MessagingErrorSource ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingErrorSource (
        MessagingErrorSource messagingErrorSource
    ) : base(messagingErrorSource)
    {  }
    #pragma warning restore CS8618

    public MessagingErrorSource (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingErrorSource (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingErrorSourceFromRaw.FromRawUnchecked"/>
    public static MessagingErrorSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessagingErrorSourceFromRaw : IFromRawJson<MessagingErrorSource>
{
    /// <inheritdoc/>
    public MessagingErrorSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingErrorSource.FromRawUnchecked(rawData);
}