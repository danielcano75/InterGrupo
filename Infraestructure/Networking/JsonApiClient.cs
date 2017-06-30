using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Common.Dependencies.Networking;
using Common.Dependencies.Preferences;
using Common.Exceptions;
using Newtonsoft.Json;

namespace Infraestructure.Networking
{
	public class JsonApiClient : ApiClient
	{

		#region Propiedades Publicas

		public string BaseUrl
		{
			get;
			set;
		}

		#endregion

		public JsonApiClient(string baseUrl, INetworkDependency networkDependency, IUserPreferences userPreferences) : base(baseUrl, networkDependency, userPreferences)
		{
		}

		#region Metodos Publicos

		public virtual async Task<T> POSTAsync<T>(string relativeUrl, object postData/*, bool useToken = false*/)
		{
			if (NetworkDependency.IsConnected() == false)
			{
				throw new NoInternetException();
			}


			JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
			{
				DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
			};

			//Organizamos la petición
			object dataToParse = postData ?? string.Empty;
			string jsonString = JsonConvert.SerializeObject(dataToParse, microsoftDateFormatSettings).ToString();
			StringContent postDataContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

			//Realizamos la petición
			HttpResponseMessage response;
			var result = default(T);


			try
			{
				response = await this.Client.PostAsync(relativeUrl, postDataContent);
				result = await CastResponseAsync<T>(response);
			}
			catch (NoAuthException ex)
			{
				throw new NoAuthException(ex.Message);
			}
			catch (Exception ex)
			{
				throw new WSErrorException(ex.Message);
			}

            return result;

		}

		public async Task<T> GetAsync<T>(string apiUrl, bool useToken = false)
		{

			if (NetworkDependency.IsConnected() == false)
			{
				throw new NoInternetException();
			}

			HttpResponseMessage response = default(HttpResponseMessage);
			var result = default(T);

			if (useToken)
			{
                this.Client.DefaultRequestHeaders.Add("Token", GetToken());
			}

			try
			{
				response = await this.Client.GetAsync(apiUrl);
				result = await CastResponseAsync<T>(response);
			}
			catch (NoAuthException ex)
			{
				throw new NoAuthException(ex.Message);
			}
			catch (Exception ex)
			{
				throw new WSErrorException(ex.Message);
			}

            return result;

		}

		#endregion
	}
}
