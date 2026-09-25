namespace Telnyx.Sdk.Core;

static class JsonElementEquality
{
    // Behavioral reference: dotnet/runtime v9.0.9 JsonElement.DeepEquals and
    // JsonHelpers.AreEqualJsonNumbers. Uses only the STJ8 public API surface.
    public static bool DeepEquals(System.Text.Json.JsonElement left, System.Text.Json.JsonElement right)
    {
      System.Runtime.CompilerServices.RuntimeHelpers.EnsureSufficientExecutionStack();
      // The framework rejects uninitialized elements, including undefined vs undefined.
      if (left.ValueKind == System.Text.Json.JsonValueKind.Undefined)
        throw new System.InvalidOperationException();
      if (right.ValueKind == System.Text.Json.JsonValueKind.Undefined)
        throw new System.InvalidOperationException();
      if (left.ValueKind != right.ValueKind) return false;
      switch (left.ValueKind)
      {
        case System.Text.Json.JsonValueKind.Null:
        case System.Text.Json.JsonValueKind.True:
        case System.Text.Json.JsonValueKind.False:
          return true;
        case System.Text.Json.JsonValueKind.String:
          return System.String.Equals(left.GetString(), right.GetString(), System.StringComparison.Ordinal);
        case System.Text.Json.JsonValueKind.Number:
          return NormalizeNumber(left.GetRawText()) == NormalizeNumber(right.GetRawText());
        case System.Text.Json.JsonValueKind.Array:
          if (left.GetArrayLength() != right.GetArrayLength()) return false;
          var items = right.EnumerateArray();
          foreach (var item in left.EnumerateArray())
          {
            if (!items.MoveNext() || !DeepEquals(item, items.Current)) return false;
          }
          return true;
        default:
          // Match the framework's count short-circuit before visiting property values.
          int leftCount = 0, rightCount = 0;
          foreach (var property in left.EnumerateObject()) leftCount++;
          foreach (var property in right.EnumerateObject()) rightCount++;
          if (leftCount != rightCount) return false;
          // Duplicate names are ordered queues, not last-property-wins dictionaries.
          var properties = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.Queue<System.Text.Json.JsonElement>>(System.StringComparer.Ordinal);
          int remaining = 0;
          foreach (var property in right.EnumerateObject())
          {
            if (!properties.TryGetValue(property.Name, out var values))
              properties.Add(property.Name, values = new System.Collections.Generic.Queue<System.Text.Json.JsonElement>());
            values.Enqueue(property.Value);
            remaining++;
          }
          foreach (var property in left.EnumerateObject())
          {
            if (!properties.TryGetValue(property.Name, out var values) || values.Count == 0 || !DeepEquals(property.Value, values.Dequeue())) return false;
            remaining--;
          }
          return remaining == 0;
      }
    }

    private static string NormalizeNumber(string text)
    {
      bool negative = text[0] == '-';
      if (negative) text = text.Substring(1);
      int exponent = 0;
      int e = text.IndexOfAny(new[] { 'e', 'E' });
      if (e >= 0)
      {
        // Match STJ9's explicit Int32 exponent limit, including its exception.
        if (!System.Int32.TryParse(text.Substring(e + 1), System.Globalization.NumberStyles.AllowLeadingSign, System.Globalization.CultureInfo.InvariantCulture, out exponent))
          throw new System.ArgumentOutOfRangeException("exponent");
        text = text.Substring(0, e);
      }
      int dot = text.IndexOf('.');
      int fractionalLength = dot < 0 ? 0 : text.Length - dot - 1;
      string digits = dot < 0 ? text : text.Remove(dot, 1);
      int start = 0;
      while (start < digits.Length && digits[start] == '0') start++;
      if (start == digits.Length) return "0";
      int end = digits.Length;
      while (digits[end - 1] == '0') end--;
      // STJ9 uses unchecked Int32 normalization even at the exponent boundaries.
      // Do not use double/decimal: they round large significands or overflow.
      exponent = unchecked(exponent - fractionalLength + digits.Length - end);
      return (negative ? "-" : "") + digits.Substring(start, end - start) + "e" + exponent.ToString(System.Globalization.CultureInfo.InvariantCulture);
    }
}