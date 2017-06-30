using System;
using Presentation.iOS.Menu;
using SidebarNavigation;
using UIKit;

namespace Presentation.iOS._Shared
{
	public partial class RootViewController : UIViewController
	{

		public static SidebarController StaticSidebarController { get; private set; }

		public RootViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			UIStoryboard main = UIStoryboard.FromName("Main", null);

			NavigationViewController navHome = (NavigationViewController)main.InstantiateViewController("NavigationViewProspect");
			MenuViewController menu = (MenuViewController)main.InstantiateViewController("MenuViewController");

			menu.NavController = navHome;

			StaticSidebarController = new SidebarController(this, navHome, menu);
			StaticSidebarController.HasShadowing = false;
			StaticSidebarController.MenuWidth = 283;
            StaticSidebarController.MenuLocation = SidebarController.MenuLocations.Left;

		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}
	}
}

