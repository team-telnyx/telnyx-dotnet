using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

[JsonConverter(typeof(JsonModelConverter<BrandGetFeedbackResponse, BrandGetFeedbackResponseFromRaw>))]
public sealed record class BrandGetFeedbackResponse : JsonModel
{
    /// <summary>
    /// ID of the brand being queried about
    /// </summary>
    public required string BrandID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "brandId"
            );
        }
        init { this._rawData.Set("brandId", value); }
    }

    /// <summary>
    /// A list of reasons why brand creation/revetting didn't go as planned
    /// </summary>
    public required IReadOnlyList<Category> Category {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Category>>(
                "category"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Category>>(
                "category",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandID;
        foreach (var item in this.Category)
        {
            item.Validate();
        }
    }

    public BrandGetFeedbackResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandGetFeedbackResponse (
        BrandGetFeedbackResponse brandGetFeedbackResponse
    ) : base(brandGetFeedbackResponse)
    {  }
    #pragma warning restore CS8618

    public BrandGetFeedbackResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandGetFeedbackResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandGetFeedbackResponseFromRaw.FromRawUnchecked"/>
    public static BrandGetFeedbackResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BrandGetFeedbackResponseFromRaw : IFromRawJson<BrandGetFeedbackResponse>
{
    /// <inheritdoc/>
    public BrandGetFeedbackResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandGetFeedbackResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Category, CategoryFromRaw>))]
public sealed record class Category : JsonModel
{
    /// <summary>
    /// One of `TAX_ID`, `STOCK_SYMBOL`, `GOVERNMENT_ENTITY`, `NONPROFIT`, and `OTHERS`
    /// </summary>
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
    /// Long-form description of the feedback with additional information
    /// </summary>
    public required string Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Human-readable version of the `id` field
    /// </summary>
    public required string DisplayName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "displayName"
            );
        }
        init { this._rawData.Set("displayName", value); }
    }

    /// <summary>
    /// List of relevant fields in the originally-submitted brand json
    /// </summary>
    public required IReadOnlyList<string> Fields {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "fields"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "fields",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.Fields;
    }

    public Category ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Category (Category category) : base(category)
    {  }
    #pragma warning restore CS8618

    public Category (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Category (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CategoryFromRaw.FromRawUnchecked"/>
    public static Category FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CategoryFromRaw : IFromRawJson<Category>
{
    /// <inheritdoc/>
    public Category FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Category.FromRawUnchecked(rawData);
}