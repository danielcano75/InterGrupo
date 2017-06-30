using System;
using Common.Dependencies.SQL;
using SQLite.Net;
using System.IO;
using SQLite.Net.Platform.XamarinIOS;
using Configuration;
using Constants;

namespace Presentation.iOS.Classes.DependencyClients
{
	public class SQLiteConnectionClient : ISQLiteConnectionDependency
	{

		private static SQLiteConnection _connection;

		public SQLiteConnectionClient ()
		{
		}

		#region ISQLiteConnectionDependency implementation

		public SQLiteConnection GetConnection ()
		{
			if (_connection == null) {
				string folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				string databaseFileName = Path.Combine (folder, GlobalConfig.DATABASE_NAME);
				var platform = new SQLitePlatformIOS ();
				_connection = new SQLiteConnection(platform,databaseFileName);
			}
			return _connection;
		}

		#endregion
	}
}

