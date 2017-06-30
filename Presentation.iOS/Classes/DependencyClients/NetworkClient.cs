using System;
using Common.Dependencies.Networking;
using Presentation.iOS.Classes.Networking;

namespace Presentation.iOS.Classes.DependencyClients
{
	public class NetworkClient : INetworkDependency
	{
		public NetworkClient ()
		{
		}

		#region INetworkDependency implementation

		public bool IsConnected ()
		{
				if (Reachability.InternetConnectionStatus() == NetworkStatus.ReachableViaCarrierDataNetwork || 
					Reachability.InternetConnectionStatus() == NetworkStatus.ReachableViaWiFiNetwork) {
					return true;
				}
				return false;
		}

		#endregion
	}
}

