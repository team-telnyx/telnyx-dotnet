using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.WebhookDeliveries;

/// <summary>
/// Lists webhook_deliveries for the authenticated user
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WebhookDeliveryListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[status][eq],
    /// filter[event_type], filter[webhook][contains], filter[attempts][contains],
    /// filter[started_at][gte], filter[started_at][lte], filter[finished_at][gte], filter[finished_at][lte]
    /// </summary>
    public Filter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Filter>(
                "filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter", value);
        }
    }

    public long? PageNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[number]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[number]", value);
        }
    }

    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[size]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[size]", value);
        }
    }

    public WebhookDeliveryListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookDeliveryListParams (
        WebhookDeliveryListParams webhookDeliveryListParams
    ) : base(webhookDeliveryListParams)
    {  }
    #pragma warning restore CS8618

    public WebhookDeliveryListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookDeliveryListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WebhookDeliveryListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(WebhookDeliveryListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/webhook_deliveries"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// Consolidated filter parameter (deepObject style). Originally: filter[status][eq],
/// filter[event_type], filter[webhook][contains], filter[attempts][contains], filter[started_at][gte],
/// filter[started_at][lte], filter[finished_at][gte], filter[finished_at][lte]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    public Attempts? Attempts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Attempts>(
                "attempts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("attempts", value);
        }
    }

    /// <summary>
    /// Return only webhook_deliveries matching the given value of `event_type`. Accepts
    /// multiple values separated by a `,`.
    /// </summary>
    public string? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "event_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("event_type", value);
        }
    }

    public FinishedAt? FinishedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FinishedAt>(
                "finished_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("finished_at", value);
        }
    }

    public StartedAt? StartedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StartedAt>(
                "started_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("started_at", value);
        }
    }

    public Status? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Status>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public Webhook? Webhook {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Webhook>(
                "webhook"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Attempts?.Validate();
        _ = this.EventType;
        this.FinishedAt?.Validate();
        this.StartedAt?.Validate();
        this.Status?.Validate();
        this.Webhook?.Validate();
    }

    public Filter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter (Filter filter) : base(filter)
    {  }
    #pragma warning restore CS8618

    public Filter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attempts, AttemptsFromRaw>))]
public sealed record class Attempts : JsonModel
{
    /// <summary>
    /// Return only webhook_deliveries whose `attempts` component contains the given text
    /// </summary>
    public string? Contains {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "contains"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("contains", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Contains; }

    public Attempts ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Attempts (Attempts attempts) : base(attempts)
    {  }
    #pragma warning restore CS8618

    public Attempts (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Attempts (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AttemptsFromRaw.FromRawUnchecked"/>
    public static Attempts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AttemptsFromRaw : IFromRawJson<Attempts>
{
    /// <inheritdoc/>
    public Attempts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Attempts.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FinishedAt, FinishedAtFromRaw>))]
public sealed record class FinishedAt : JsonModel
{
    /// <summary>
    /// Return only webhook_deliveries whose delivery finished later than or at given
    /// ISO 8601 datetime
    /// </summary>
    public string? Gte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "gte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gte", value);
        }
    }

    /// <summary>
    /// Return only webhook_deliveries whose delivery finished earlier than or at
    /// given ISO 8601 datetime
    /// </summary>
    public string? Lte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "lte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lte", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Gte;
        _ = this.Lte;
    }

    public FinishedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FinishedAt (FinishedAt finishedAt) : base(finishedAt)
    {  }
    #pragma warning restore CS8618

    public FinishedAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FinishedAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FinishedAtFromRaw.FromRawUnchecked"/>
    public static FinishedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FinishedAtFromRaw : IFromRawJson<FinishedAt>
{
    /// <inheritdoc/>
    public FinishedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FinishedAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<StartedAt, StartedAtFromRaw>))]
public sealed record class StartedAt : JsonModel
{
    /// <summary>
    /// Return only webhook_deliveries whose delivery started later than or at given
    /// ISO 8601 datetime
    /// </summary>
    public string? Gte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "gte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gte", value);
        }
    }

    /// <summary>
    /// Return only webhook_deliveries whose delivery started earlier than or at
    /// given ISO 8601 datetime
    /// </summary>
    public string? Lte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "lte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lte", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Gte;
        _ = this.Lte;
    }

    public StartedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public StartedAt (StartedAt startedAt) : base(startedAt)
    {  }
    #pragma warning restore CS8618

    public StartedAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    StartedAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StartedAtFromRaw.FromRawUnchecked"/>
    public static StartedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class StartedAtFromRaw : IFromRawJson<StartedAt>
{
    /// <inheritdoc/>
    public StartedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>StartedAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Status, StatusFromRaw>))]
public sealed record class Status : JsonModel
{
    /// <summary>
    /// Return only webhook_deliveries matching the given `status`
    /// </summary>
    public ApiEnum<string, Eq>? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Eq>>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Eq?.Validate(); }

    public Status ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Status (Status status) : base(status)
    {  }
    #pragma warning restore CS8618

    public Status (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Status (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StatusFromRaw.FromRawUnchecked"/>
    public static Status FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class StatusFromRaw : IFromRawJson<Status>
{
    /// <inheritdoc/>
    public Status FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Status.FromRawUnchecked(rawData);
}

/// <summary>
/// Return only webhook_deliveries matching the given `status`
/// </summary>
[JsonConverter(typeof(EqConverter))]
public enum Eq
{
    Delivered, Failed
}

sealed class EqConverter : JsonConverter<Eq>
{
    public override Eq Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "delivered"=>Eq.Delivered, "failed"=>Eq.Failed, _ =>(Eq)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Eq value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Eq.Delivered=>"delivered",
            Eq.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Webhook, WebhookFromRaw>))]
public sealed record class Webhook : JsonModel
{
    /// <summary>
    /// Return only webhook deliveries whose `webhook` component contains the given text
    /// </summary>
    public string? Contains {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "contains"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("contains", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Contains; }

    public Webhook ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Webhook (Webhook webhook) : base(webhook)
    {  }
    #pragma warning restore CS8618

    public Webhook (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Webhook (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookFromRaw.FromRawUnchecked"/>
    public static Webhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WebhookFromRaw : IFromRawJson<Webhook>
{
    /// <inheritdoc/>
    public Webhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Webhook.FromRawUnchecked(rawData);
}