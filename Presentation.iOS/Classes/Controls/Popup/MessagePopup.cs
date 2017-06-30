using System;
using Presentation.iOS.Message;
using UIKit;

namespace Presentation.iOS
{
	public class MessagePopup
	{
		public MessagePopup()
		{
		}

		private static UIView _showedView;

		public static void ShowMessage(UIViewController controller, string message, string titlebuttontwo = "", string titlebuttonone = "", Action okAction = null)
		{
			var main = UIStoryboard.FromName("Main", null);
			var msgController = (MessageViewController)main.InstantiateViewController("MessageViewController");
			ConfigureMessage(main, msgController,controller, message, titlebuttontwo, titlebuttonone, okAction);
		}

		public static void ConfigureMessage(UIStoryboard main, MessageViewController msgController, UIViewController controller, string message, string titlebuttontwo = "", string titlebuttonone = "", Action okAction = null)
		{
			if (_showedView != null)
			{
				_showedView.RemoveFromSuperview();
			}

			msgController.Controller = controller;
			msgController.Message = message;
			msgController.TitleButtonOne = titlebuttonone;
			msgController.TitleButtonTwo = titlebuttontwo;
			if (okAction != null)
			{
				msgController.OkClicked += (sender, e) => { okAction(); };
			}

			var superView = (controller.NavigationController == null) ? controller.View : controller.NavigationController.View;

			_showedView = msgController.View;
			superView.AddSubview(msgController.View);
		}

		public static void RemoveMessage(UIViewController controller)
		{
			_showedView.RemoveFromSuperview();
		}

	}
}

