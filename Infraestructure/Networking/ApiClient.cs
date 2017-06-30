using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using Common.Dependencies.Networking;
using Common.Dependencies.Preferences;
using System.Net.Http.Headers;
using Common.Exceptions;
using Constants;
using Common;

namespace Infraestructure.Networking
{
	public class ApiClient : IDisposable
	{

		#region Variables Privadas

		protected INetworkDependency NetworkDependency { get; private set; }
		protected HttpClient Client { get; private set; }
		protected String Token { get; private set; }
		protected IUserPreferences UserPreferences { get; private set; }

		#endregion

		#region Propiedades Publicas

		public string BaseUrl
		{
			get;
			set;
		}

		#endregion

		public ApiClient(string baseUrl, INetworkDependency networkDependency, IUserPreferences userPreferences)
		{
			this.BaseUrl = baseUrl;
			this.Client = CreateClient();
			this.NetworkDependency = networkDependency;
			this.UserPreferences = userPreferences;
		}

		#region Metodos Publicos

		public string GetToken()
		{
            string token = UserPreferences.GetStoredStringValue(GlobalConfig.TOKEN);
			if (token == null)
			{
				token = "";
			}
			return token;
		}

		#region Metodos Privados

		protected async Task<T> CastResponseAsync<T>(HttpResponseMessage response)
		{

			T result = default(T);

			//Revisamos si hay problemas en la respuesta y no es 200 en el HTTP
			if (response.IsSuccessStatusCode == false)
			{
				throw new WSErrorException(Messages.ErrorServer);
			}

			JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
			{
				DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
			};

			var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
			result = await Task.Run(() => JsonConvert.DeserializeObject<T>(jsonString, microsoftDateFormatSettings)).ConfigureAwait(false);

			return result;
		}

		#endregion


		private HttpClient CreateClient()
		{



			var handler = new ModernHttpClient.NativeMessageHandler()
			{
				UseProxy = true,
				Proxy = System.Net.HttpWebRequest.DefaultWebProxy
			};


			Uri uri = new Uri(BaseUrl);




			var httpClient = new HttpClient(handler)
			{
				BaseAddress = uri,
			};

			httpClient.Timeout = TimeSpan.FromMinutes(Constants.GlobalConfig.NETWORK_TIMEOUT);
			httpClient.DefaultRequestHeaders.Accept.Clear();

			return httpClient;
		}

		#endregion

		#region IDisposable implementation
		public void Dispose()
		{
			this.Client.Dispose();
		}
		#endregion
	}
}

