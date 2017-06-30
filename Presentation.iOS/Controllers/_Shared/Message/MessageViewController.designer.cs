// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Presentation.iOS.Message
{
    [Register ("MessageViewController")]
    partial class MessageViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnOne { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnTwo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgMessage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblMessage { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnOne != null) {
                btnOne.Dispose ();
                btnOne = null;
            }

            if (btnTwo != null) {
                btnTwo.Dispose ();
                btnTwo = null;
            }

            if (imgMessage != null) {
                imgMessage.Dispose ();
                imgMessage = null;
            }

            if (lblMessage != null) {
                lblMessage.Dispose ();
                lblMessage = null;
            }
        }
    }
}