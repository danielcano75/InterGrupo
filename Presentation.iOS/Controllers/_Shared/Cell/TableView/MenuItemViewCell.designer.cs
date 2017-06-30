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
    [Register ("MenuItemViewCell")]
    partial class MenuItemViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgSection { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblSection { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgSection != null) {
                imgSection.Dispose ();
                imgSection = null;
            }

            if (lblSection != null) {
                lblSection.Dispose ();
                lblSection = null;
            }
        }
    }
}