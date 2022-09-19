using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AudioBox.Compression
{
	public static class CollectionExtension
	{
		public static Color GetHtmlColor(this IDictionary<string, object> _Data, string _Key)
		{
			return _Data.GetHtmlColor(_Key, Color.white);
		}

		public static Color GetHtmlColor(this IDictionary<string, object> _Data, string _Key, Color _Default)
		{
			if (_Data.ContainsKey(_Key) && ColorUtility.TryParseHtmlString(Convert.ToString(_Data[_Key]), out Color color))
				return color;
			return _Default;
		}

		public static string GetString(this IDictionary<string, object> _Data, string _Key, string _Default = null)
		{
			if (_Data.ContainsKey(_Key))
				return Convert.ToString(_Data[_Key]);
			return _Default;
		}

		public static int GetInt(this IDictionary<string, object> _Data, string _Key, int _Default = 0)
		{
			if (_Data.ContainsKey(_Key))
				return Convert.ToInt32(_Data[_Key]);
			return _Default;
		}

		public static float GetFloat(this IDictionary<string, object> _Data, string _Key, float _Default = 0)
		{
			if (_Data.ContainsKey(_Key))
				return Convert.ToSingle(_Data[_Key]);
			return _Default;
		}

		public static long GetLong(this IDictionary<string, object> _Data, string _Key, long _Default = 0)
		{
			if (_Data.ContainsKey(_Key))
				return Convert.ToInt64(_Data[_Key]);
			return _Default;
		}

		public static bool GetBool(this IDictionary<string, object> _Data, string _Key, bool _Default = false)
		{
			if (_Data.ContainsKey(_Key))
				return Convert.ToBoolean(_Data[_Key]);
			return _Default;
		}

		public static double GetDouble(this IDictionary<string, object> _Data, string _Key, double _Default = 0)
		{
			if (_Data.ContainsKey(_Key))
				return Convert.ToDouble(_Data[_Key]);
			return _Default;
		}

		public static Color GetColor(this IDictionary<string, object> _Data, string _Name, string _Default = "#FFFFFFFF")
		{
			string color = _Data.GetString(_Name, _Default);
			
			return ColorUtility.TryParseHtmlString(color, out Color value) ? value : Color.white;
		}

		public static T GetEnum<T>(this IDictionary<string, object> _Data, string _Key, T _Default = default) where T : Enum
		{
			if (_Data.ContainsKey(_Key))
				return (T)Convert.ChangeType(_Data[_Key], typeof(T));
			return _Default;
		}

		public static IList<object> GetList(this IDictionary<string, object> _Data, string _Key, IList<object> _Default = null)
		{
			if (_Data.ContainsKey(_Key))
				return _Data[_Key] as IList<object>;
			return _Default;
		}

		public static IDictionary<string, object> GetDictionary(this IDictionary<string, object> _Data, string _Key, IDictionary<string, object> _Default = null)
		{
			if (_Data.ContainsKey(_Key))
				return _Data[_Key] as IDictionary<string, object>;
			return _Default;
		}

		public static IDictionary<string, object> GetDictionary(this IList<object> _Data, int _Index)
		{
			return _Data[_Index] as IDictionary<string, object>;
		}

		public static List<string> GetKeys(this IDictionary<string, object> _Data)
		{
			return _Data.Keys.ToList();
		}
	}
}
