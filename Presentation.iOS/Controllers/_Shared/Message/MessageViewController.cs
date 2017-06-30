using System;
using CoreGraphics;
using Presentation.iOS._Shared;
using UIKit;

namespace Presentation.iOS.Message
{
	public partial class MessageViewController : BaseViewController
	{

		public event EventHandler OkClicked;

		public UIViewController Controller;
		public string Message;
		public string TitleButtonOne;
		public string TitleButtonTwo;
		public bool IsNotification;

		public MessageViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			LoadMessageView();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}

		private void LoadMessageView()
		{

			lblMessage.Text = Message;

			nfloat midbutton = btnTwo.Frame.Size.Width / 2;
			nfloat center = btnTwo.Superview.Frame.Size.Width / 2 - midbutton;
			btnOne.Hidden = false;
			btnTwo.Hidden = false;
			btnOne.SetTitle(TitleButtonOne, UIControlState.Normal);
			btnTwo.SetTitle(TitleButtonTwo, UIControlState.Normal);

			if (TitleButtonOne == "")
			{
				btnOne.Hidden = true;
				btnTwo.Frame = new CGRect(center, btnTwo.Frame.Location.Y, btnTwo.Frame.Size.Width, btnTwo.Frame.Size.Height);
			}
			if (TitleButtonTwo == "")
			{
				btnTwo.Hidden = true;
				btnOne.Frame = new CGRect(center, btnOne.Frame.Location.Y, btnOne.Frame.Size.Width, btnOne.Frame.Size.Height);
			}

			if (IsNotification == true)
			{
				imgMessage.Image = UIImage.FromBundle("iconOk.png");
			}
			else
			{
				imgMessage.Image = UIImage.FromBundle("iconInfo.png");
			}

			btnOne.TouchUpInside -= OkActionClicked;
			btnTwo.TouchUpInside -= CancelActionClicked;

			btnOne.TouchUpInside += OkActionClicked;
			btnTwo.TouchUpInside += CancelActionClicked;

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}

		public void OkActionClicked(object sender, EventArgs e)
		{
			MessagePopup.RemoveMessage(Controller);
			if (OkClicked != null)
			{
				OkClicked(sender, e);
			}
		}

		public void CancelActionClicked(object sender, EventArgs e)
		{
			MessagePopup.RemoveMessage(Controller);
		}

	}
}


