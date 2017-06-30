using System;
using CoreGraphics;
using Presentation.iOS.Controllers._Shared.Services;
using UIKit;

namespace Presentation.iOS._Shared
{
    public partial class BaseViewController : UIViewController
    {

		private ServiceFactory _services;
		public ServiceFactory Services
		{
			get
			{
				if (_services == null)
				{
					_services = new ServiceFactory();
				}
				return _services;
			}
		}

		private UIStoryboard _mainStoryboard;
		public UIStoryboard MainStoryBoard
		{
			get
			{
				if (_mainStoryboard == null)
				{
					_mainStoryboard = UIStoryboard.FromName("Main", null);
				}
				return _mainStoryboard;
			}
		}


		public BaseViewController(IntPtr handle) : base (handle)
        {
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

		public void SetBarButtonItem()
		{

			UIBarButtonItem[] items = new UIBarButtonItem[1];
			// AGREGAMOS EL BOTON DEL MEÚN
			UIImage imgMenu = UIImage.FromBundle("iconMenu.png");
			UIButton btnMenu = new UIButton();
			btnMenu.Frame = new CGRect(0, 0, imgMenu.Size.Width, imgMenu.Size.Height);
			btnMenu.SetImage(imgMenu, UIControlState.Normal);
			btnMenu.TouchUpInside -= ShowMenuClicked;
			btnMenu.TouchUpInside += ShowMenuClicked;
			items[0] = new UIBarButtonItem();
			items[0].CustomView = btnMenu;

            this.NavigationItem.SetLeftBarButtonItems(items, true);

		}

        private void ShowMenuClicked(object sender, EventArgs e)
        {
            RootViewController.StaticSidebarController.ToggleMenu();
        }

		public void SetHiddenBackButton()
		{
			this.NavigationItem.SetHidesBackButton(true, false);
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}

