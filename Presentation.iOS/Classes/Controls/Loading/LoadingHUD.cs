using System;
using CoreGraphics;
using Foundation;
using MBProgressHUD;
using SDWebImage;
using UIKit;

namespace Presentation.iOS.Classes.Controlls
{
	public class LoadingHUD : IDisposable
	{

		private MTMBProgressHUD _hud;

		public LoadingHUD(UIViewController controller)
		{

			UIView view = controller.NavigationController != null ? controller.NavigationController.View : controller.View;

			_hud = new MTMBProgressHUD(view)
			{
				RemoveFromSuperViewOnHide = true
			};

			_hud.Mode = MBProgressHUDMode.CustomView;
			_hud.DimBackground = true;

			_hud.Square = true;
			_hud.LabelText = @"Cargando";
			_hud.Color = UIColor.White;
			_hud.LabelColor = UIColor.Black;


			view.AddSubview(_hud);

			UIImageView imageView = new UIImageView(CGRect.FromLTRB(0, 0, 37, 37));
			var url = NSBundle.MainBundle.GetUrlForResource("loading", "gif");
			imageView.SetImage(url);
			_hud.CustomView = imageView;

			_hud.Show(animated: true);

		}

		public void Dispose()
		{
			_hud.Hide(true);
		}
	}
}

