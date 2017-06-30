// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Presentation.iOS.TableView
{
    [Register ("ProspectViewCell")]
    partial class ProspectViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgStatus { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblCitizenshipCard { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblLastName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNumberPhone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblStatus { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgStatus != null) {
                imgStatus.Dispose ();
                imgStatus = null;
            }

            if (lblCitizenshipCard != null) {
                lblCitizenshipCard.Dispose ();
                lblCitizenshipCard = null;
            }

            if (lblLastName != null) {
                lblLastName.Dispose ();
                lblLastName = null;
            }

            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (lblNumberPhone != null) {
                lblNumberPhone.Dispose ();
                lblNumberPhone = null;
            }

            if (lblStatus != null) {
                lblStatus.Dispose ();
                lblStatus = null;
            }
        }
    }
}