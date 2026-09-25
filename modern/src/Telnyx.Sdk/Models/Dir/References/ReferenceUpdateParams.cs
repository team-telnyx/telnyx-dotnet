using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Dir.References;

/// <summary>
/// Partially update one reference, addressed by the DIR id plus the reference's
/// type (business or financial) and slot.
///
/// <para>Cosmetic fields (full name, job title, organization, relationship, email)
/// are always editable. The phone number and timezone may only be changed while
/// a scheduled call has not yet been dialed; if a call is in progress or all attempts
/// are complete, those fields are locked. Changing the timezone reschedules any
/// pending call into the new local calling window.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ReferenceUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string DirID { get; init; }

    public required ApiEnum<string, RefType> RefType { get; init; }

    public long? Slot { get; init; }

    /// <summary>
    /// Reference contact email address.
    /// </summary>
    public string? Email {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "email"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("email", value);
        }
    }

    /// <summary>
    /// Full name of the reference contact.
    /// </summary>
    public string? FullName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "full_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("full_name", value);
        }
    }

    /// <summary>
    /// Job title of the reference contact.
    /// </summary>
    public string? JobTitle {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "job_title"
            );
        }
        init { this._rawBodyData.Set("job_title", value); }
    }

    /// <summary>
    /// Organization the reference contact belongs to.
    /// </summary>
    public string? Organization {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "organization"
            );
        }
        init { this._rawBodyData.Set("organization", value); }
    }

    /// <summary>
    /// Reference phone number in E.164 format.
    /// </summary>
    public string? PhoneE164 {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "phone_e164"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("phone_e164", value);
        }
    }

    /// <summary>
    /// How the reference contact is related to the registering business.
    /// </summary>
    public string? RelationshipToRegistrant {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "relationship_to_registrant"
            );
        }
        init { this._rawBodyData.Set("relationship_to_registrant", value); }
    }

    /// <summary>
    /// IANA timezone id for the reference.
    /// </summary>
    public string? Timezone {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "timezone"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("timezone", value);
        }
    }

    public ReferenceUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReferenceUpdateParams (
        ReferenceUpdateParams referenceUpdateParams
    ) : base(referenceUpdateParams)
    {
        this.DirID = referenceUpdateParams.DirID;
        this.RefType = referenceUpdateParams.RefType;
        this.Slot = referenceUpdateParams.Slot;

        this._rawBodyData = new(referenceUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ReferenceUpdateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReferenceUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string dirID,
        ApiEnum<string, RefType> refType,
        long slot
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.DirID = dirID;
        this.RefType = refType;
        this.Slot = slot;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ReferenceUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string dirID,
        ApiEnum<string, RefType> refType,
        long slot
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            dirID,
            refType,
            slot
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["DirID"] = JsonSerializer.SerializeToElement(this.DirID),
        ["RefType"] = JsonSerializer.SerializeToElement(this.RefType),
        ["Slot"] = JsonSerializer.SerializeToElement(this.Slot),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ReferenceUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.DirID.Equals(other.DirID)&&this.RefType.Equals(other.RefType)&&(this.Slot?.Equals(other.Slot) ?? other.Slot == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/dir/{0}/references/{1}/{2}",
            this.DirID,
            this.RefType.Raw(),
            this.Slot)
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
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

[JsonConverter(typeof(RefTypeConverter))]
public enum RefType
{
    Business, Financial
}

sealed class RefTypeConverter : JsonConverter<RefType>
{
    public override RefType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "business"=>RefType.Business,
            "financial"=>RefType.Financial,
            _ =>(RefType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RefType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RefType.Business=>"business",
            RefType.Financial=>"financial",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}