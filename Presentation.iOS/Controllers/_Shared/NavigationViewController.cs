using System;

using UIKit;

namespace Presentation.iOS._Shared
{
	public partial class NavigationViewController : UINavigationController
	{
		public NavigationViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
            UINavigationBar.Appearance.TintColor = UIColor.White;
			UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(0, 146, 203);
			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
			{
				Font = UIFont.FromName("Arial", 20)
			});
			this.NavigationBar.Translucent = false;
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

