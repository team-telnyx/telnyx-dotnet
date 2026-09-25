using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Documents;

namespace Telnyx.Sdk.Models.DocumentLinks;

[JsonConverter(typeof(JsonModelConverter<DocumentLinkListResponse, DocumentLinkListResponseFromRaw>))]
public sealed record class DocumentLinkListResponse : JsonModel
{
    /// <summary>
    /// Identifies the resource.
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
    /// ISO 8601 formatted date-time indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
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

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <summary>
    /// Identifies the associated document.
    /// </summary>
    public string? DocumentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "document_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("document_id", value);
        }
    }

    /// <summary>
    /// The linked resource's record type.
    /// </summary>
    public string? LinkedRecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "linked_record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("linked_record_type", value);
        }
    }

    /// <summary>
    /// Identifies the linked resource.
    /// </summary>
    public string? LinkedResourceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "linked_resource_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("linked_resource_id", value);
        }
    }

    public static implicit operator DocServiceRecord (
        DocumentLinkListResponse documentLinkListResponse
    )=> new() {
        ID = documentLinkListResponse.ID,
        CreatedAt = documentLinkListResponse.CreatedAt,
        RecordType = documentLinkListResponse.RecordType,
        UpdatedAt = documentLinkListResponse.UpdatedAt
    } ;

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.RecordType;
        _ = this.UpdatedAt;
        _ = this.DocumentID;
        _ = this.LinkedRecordType;
        _ = this.LinkedResourceID;
    }

    public DocumentLinkListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentLinkListResponse (
        DocumentLinkListResponse documentLinkListResponse
    ) : base(documentLinkListResponse)
    {  }
    #pragma warning restore CS8618

    public DocumentLinkListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentLinkListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DocumentLinkListResponseFromRaw.FromRawUnchecked"/>
    public static DocumentLinkListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DocumentLinkListResponseFromRaw : IFromRawJson<DocumentLinkListResponse>
{
    /// <inheritdoc/>
    public DocumentLinkListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DocumentLinkListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<global::Telnyx.Sdk.Models.DocumentLinks.IntersectionMember1, global::Telnyx.Sdk.Models.DocumentLinks.IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    /// <summary>
    /// Identifies the associated document.
    /// </summary>
    public string? DocumentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "document_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("document_id", value);
        }
    }

    /// <summary>
    /// The linked resource's record type.
    /// </summary>
    public string? LinkedRecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "linked_record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("linked_record_type", value);
        }
    }

    /// <summary>
    /// Identifies the linked resource.
    /// </summary>
    public string? LinkedResourceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "linked_resource_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("linked_resource_id", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
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
        _ = this.DocumentID;
        _ = this.LinkedRecordType;
        _ = this.LinkedResourceID;
        _ = this.RecordType;
    }

    public IntersectionMember1 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1 (
        global::Telnyx.Sdk.Models.DocumentLinks.IntersectionMember1 intersectionMember1
    ) : base(intersectionMember1)
    {  }
    #pragma warning restore CS8618

    public IntersectionMember1 (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="global::Telnyx.Sdk.Models.DocumentLinks.IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static global::Telnyx.Sdk.Models.DocumentLinks.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class IntersectionMember1FromRaw : IFromRawJson<global::Telnyx.Sdk.Models.DocumentLinks.IntersectionMember1>
{
    /// <inheritdoc/>
    public global::Telnyx.Sdk.Models.DocumentLinks.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>global::Telnyx.Sdk.Models.DocumentLinks.IntersectionMember1.FromRawUnchecked(rawData);
}