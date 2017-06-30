using Foundation;
using System;
using UIKit;
using Presentation.iOS._Shared;
using Constants;

namespace Presentation.iOS
{
    public partial class LandingViewController : BaseViewController
    {
        public LandingViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad(); 
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            ValidateUser();
        }

        private void ValidateUser()
        {
            string token = Services.Preferences.GetStoredStringValue(GlobalConfig.TOKEN);
            if(string.IsNullOrEmpty(token)) 
            {
                this.PerformSegue("Login", this);
            } else {
                this.PerformSegue("Root", this);
            }
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }
    }
}