using System;
using Common.Dependencies.Preferences;
using Foundation;

namespace Presentation.iOS.Classes.DependencyClients
{
	public class UserPreferences: IUserPreferences
	{
		public UserPreferences()
		{
		}


		#region IUserPreferences implementation

		public void StoreIntValue(string key, int value)
		{
			NSUserDefaults.StandardUserDefaults.SetInt(value, key);
			NSUserDefaults.StandardUserDefaults.Synchronize();
		}

		public void StoreStringValue(string key, string value)
		{
			NSUserDefaults.StandardUserDefaults.SetString(value, key);
			NSUserDefaults.StandardUserDefaults.Synchronize();
		}

		public int GetStoredIntValue(string key)
		{
			string storeStr = NSUserDefaults.StandardUserDefaults.IntForKey(key).ToString();
			int storeInt = Int32.Parse(storeStr);
			return storeInt;
		}

		public string GetStoredStringValue(string key)
		{
			return NSUserDefaults.StandardUserDefaults.StringForKey(key);
		}

		public void StoreBoolValue(string key, bool value)
		{
			NSUserDefaults.StandardUserDefaults.SetBool(value, key);
			NSUserDefaults.StandardUserDefaults.Synchronize();
		}

		public bool GetStoreBoolValue(string key)
		{
			return NSUserDefaults.StandardUserDefaults.BoolForKey(key);
		}

		#endregion

	}
}

