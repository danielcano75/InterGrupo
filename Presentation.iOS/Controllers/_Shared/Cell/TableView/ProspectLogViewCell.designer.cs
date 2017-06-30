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
    [Register ("ProspectLogViewCell")]
    partial class ProspectLogViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblId { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblProspectId { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblDate != null) {
                lblDate.Dispose ();
                lblDate = null;
            }

            if (lblId != null) {
                lblId.Dispose ();
                lblId = null;
            }

            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (lblProspectId != null) {
                lblProspectId.Dispose ();
                lblProspectId = null;
            }
        }
    }
}