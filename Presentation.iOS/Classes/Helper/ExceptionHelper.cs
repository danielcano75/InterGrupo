using System;
using Autofac;
using UIKit;
using Domain;
using Common;

namespace Presentation.iOS
{

	public class ExceptionHelper
	{

		public ExceptionHelper ()
		{
		}


		public static void Handle (Exception e, UIViewController controller)
		{
			 
			string exceptionName = e.GetType ().Name;
			string exceptionMessage = e.Message;
		
			switch (exceptionName) {
			case "WSErrorException":
			case "NoInternetException":
			case "ServerException":
			case "UnknownException":
			case "TaskCanceledException":
			case "TimeOutException":
			case "InternalServerError":
			case "GeneralException":
				
                MessagePopup.ShowMessage (controller, exceptionMessage, "CERRAR");

				break;

			case "NoAuthException":
				
//				MessageHelper.ShowNotificationMessage (controller, title, exceptionMessage, 0, () => {
//					IUserService userService = ContainerConfiguration.Container.Resolve<IUserService> ();
//					UnregisterDeviceID (controller, userService);
//					userService.LogOut ();
//					controller.DismissModalViewController (true);
//				});

				break;

			default:
				throw e;

			}
				
		}


	}
}

