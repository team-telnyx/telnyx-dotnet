namespace Telnyx.net.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.Infrastructure;

    /// <summary>
    /// Telnyx List.
    /// </summary>
    /// <typeparam name="T">Object Type.</typeparam>

    [JsonArray]
    public class TelnyxCollection<T> : TelnyxEntity, IList<T>
    {
        public TelnyxCollection()
        {
            this.Data = new List<T>();
        }

        public T this[int index] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        /// <summary>
        /// Gets or sets a string describing the object type returned.
        /// </summary>
        [JsonProperty("object")]
        public string Object => typeof(T).Name;

        /// <summary>
        /// Gets or sets a list containing the actual response elements, paginated by any request parameters.
        /// </summary>
        [JsonProperty("data", ItemConverterType = typeof(TelnyxObjectConverter))]
        public List<T> Data { get; set; }

        /// <summary>
        /// Gets or sets metadata for list.
        /// </summary>
        [JsonProperty("meta")]
        public PageInfo PageInfo { get; set; }

        public int Count => this.Data.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            this.Data.Add(item);
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }
    }
}
