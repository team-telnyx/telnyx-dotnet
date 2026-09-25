using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Portouts.Comments;

[JsonConverter(typeof(JsonModelConverter<PortoutComment, PortoutCommentFromRaw>))]
public sealed record class PortoutComment : JsonModel
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

    /// <summary>
    /// Comment body
    /// </summary>
    public required string Body {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "body"
            );
        }
        init { this._rawData.Set("body", value); }
    }

    /// <summary>
    /// Comment creation timestamp in ISO 8601 format
    /// </summary>
    public required string CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Identifies the user who created the comment. Will be null if created by Telnyx Admin
    /// </summary>
    public required string UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "user_id"
            );
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <summary>
    /// Identifies the associated port request
    /// </summary>
    public string? PortoutID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "portout_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("portout_id", value);
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
        _ = this.ID;
        _ = this.Body;
        _ = this.CreatedAt;
        _ = this.UserID;
        _ = this.PortoutID;
        _ = this.RecordType;
    }

    public PortoutComment ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortoutComment (PortoutComment portoutComment) : base(portoutComment)
    {  }
    #pragma warning restore CS8618

    public PortoutComment (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortoutComment (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortoutCommentFromRaw.FromRawUnchecked"/>
    public static PortoutComment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortoutCommentFromRaw : IFromRawJson<PortoutComment>
{
    /// <inheritdoc/>
    public PortoutComment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortoutComment.FromRawUnchecked(rawData);
}