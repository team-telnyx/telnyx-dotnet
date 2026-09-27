using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

[JsonConverter(typeof(JsonModelConverter<Url, UrlFromRaw>))]
public sealed record class Url : JsonModel
{
    public required string UrlValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "url"
            );
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.UrlValue; }

    public Url ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Url (Url url) : base(url)
    {  }
    #pragma warning restore CS8618

    public Url (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Url (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UrlFromRaw.FromRawUnchecked"/>
    public static Url FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Url (string urlValue) : this()
    { this.UrlValue = urlValue; }
}

class UrlFromRaw : IFromRawJson<Url>
{
    /// <inheritdoc/>
    public Url FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Url.FromRawUnchecked(rawData);
}