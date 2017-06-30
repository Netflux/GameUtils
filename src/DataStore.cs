using System.Collections.Concurrent;

namespace GameUtils
{
	public class DataStore
	{
		private static readonly DataStore _instance = new DataStore();
		private readonly ConcurrentDictionary<string, object> _store;

		/// <summary>
		/// Gets the singleton instance of the data store.
		/// </summary>
		public static DataStore Instance
		{
			get { return _instance; }
		}

		/// <summary>
		/// Gets the number of elements in the data store.
		/// </summary>
		public int Count
		{
			get { return _store.Count; }
		}

		private DataStore()
		{
			_store = new ConcurrentDictionary<string, object>();
		}

		/// <summary>
		/// Determines whether the data store contains the given key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>True if the key exists; Otherwise, false.</returns>
		public bool Contains(string key)
		{
			return _store.ContainsKey(key);
		}

		#region Data Manipulation Methods

		/// <summary>
		/// Clears all keys and values in the data store.
		/// </summary>
		public void Clear()
		{
			_store.Clear();
		}

		/// <summary>
		/// Adds the value with the given key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		/// <returns>True if the value was added; Otherwise, false.</returns>
		public bool Add(string key, object value)
		{
			return _store.TryAdd(key, value);
		}

		/// <summary>
		/// Gets the value with the given key.
		/// </summary>
		/// <typeparam name="T">The type of the value.</typeparam>
		/// <param name="key">The key of the value to get.</param>
		/// <returns>The value if found; Otherwise, default value of the type.</returns>
		public T Get<T>(string key)
		{
			object value;

			if (_store.TryGetValue(key, out value))
			{
				return (T) value;
			}
			else
			{
				return default(T);
			}
		}

		/// <summary>
		/// Removes the value with the given key.
		/// </summary>
		/// <param name="key">The key of the value to remove.</param>
		/// <returns>True if the value was removed; Otherwise, false.</returns>
		public bool Remove(string key)
		{
			object value;
			return _store.TryRemove(key, out value);
		}

		/// <summary>
		/// Updates the value with the given key.
		/// </summary>
		/// <param name="key">The key of the value to update.</param>
		/// <param name="value">The new value.</param>
		/// <returns>True if the value was updated; Otherwise, false.</returns>
		public bool Update(string key, object value)
		{
			object oldValue;

			if (_store.TryGetValue(key, out oldValue))
			{
				return _store.TryUpdate(key, value, oldValue);
			}
			else
			{
				return false;
			}
		}

		#endregion
	}
}
