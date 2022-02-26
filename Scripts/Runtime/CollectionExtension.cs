using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AudioBox.Compression
{
	public static class CollectionExtension
	{
		public static string GetString(this IDictionary<string, object> _Data, string _Key, string _Default = null)
		{
			if (_Data.ContainsKey(_Key))
				return (string)_Data[_Key];
			return _Default;
		}

		public static int GetInt(this IDictionary<string, object> _Data, string _Key, int _Default = 0)
		{
			if (_Data.ContainsKey(_Key))
				return (int)_Data[_Key];
			return _Default;
		}

		public static float GetFloat(this IDictionary<string, object> _Data, string _Key, float _Default = 0)
		{
			if (_Data.ContainsKey(_Key))
				return (float)_Data[_Key];
			return _Default;
		}

		public static long GetLong(this IDictionary<string, object> _Data, string _Key, long _Default = 0)
		{
			if (_Data.ContainsKey(_Key))
				return (long)_Data[_Key];
			return _Default;
		}

		public static bool GetBool(this IDictionary<string, object> _Data, string _Key, bool _Default = false)
		{
			if (_Data.ContainsKey(_Key))
				return (bool)_Data[_Key];
			return _Default;
		}

		public static double GetDouble(this IDictionary<string, object> _Data, string _Key, double _Default = 0)
		{
			if (_Data.ContainsKey(_Key))
				return (double)_Data[_Key];
			return _Default;
		}

		public static T GetEnum<T>(this IDictionary<string, object> _Data, string _Key, T _Default = default) where T : Enum
		{
			if (_Data.ContainsKey(_Key))
				return (T)_Data[_Key];
			return _Default;
		}

		public static IList GetList(this IDictionary<string, object> _Data, string _Key, IList _Default = null)
		{
			if (_Data.ContainsKey(_Key))
				return (IList)_Data[_Key];
			return _Default;
		}

		public static IDictionary<string, object> GetDictionary(IDictionary<string, object> _Data, string _Key, IDictionary<string, object> _Default = null)
		{
			if (_Data.ContainsKey(_Key))
				return (IDictionary<string, object>)_Data[_Key];
			return _Default;
		}

		public static string GenerateUniqueID<T>(this ICollection<T> _List, string _ID, Func<T, string> _Selector)
		{
			if (_List.All(_Snapshot => _Selector(_Snapshot) != _ID))
				return _ID;
			
			const int limit = 100;
			
			int    index = 1;
			string id    = _ID;
			while (true)
			{
				if (_List.All(_Snapshot => _Selector(_Snapshot) != _ID))
					return id;
				
				id = $"{_ID} [{index:00}]";
				
				index++;
				
				if (index >= limit)
					return id;
			}
		}
	}
}