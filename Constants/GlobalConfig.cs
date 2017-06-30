using System;

namespace Constants
{
	public static class GlobalConfig
	{
		/**
		 * BASE DE DATOS
		 * */
		public static string DATABASE_NAME = "AppInterGrupo.db";
		/**
		 * ACCESS TOKEN
		 * SYNC PROSPECTS
		 * */
		public static string TOKEN = "AccessToken";
        public static string SYNC_PROSPECTS = "SyncProspects";

		/**
		 * REST API
		 * */

		public static string BASE_URL = "http://directotesting.igapps.co";

		/**
		 * SINCRONIZACION
		 * */
		public static int SYNC_INTERVAL = 500*1000;


        public static int NETWORK_TIMEOUT = 2;
	}
}

