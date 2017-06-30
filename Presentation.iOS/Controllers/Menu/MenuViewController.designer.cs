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

namespace Presentation.iOS.Menu
{
    [Register ("MenuViewController")]
    partial class MenuViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblVersion { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tvSections { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView vMenu { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblVersion != null) {
                lblVersion.Dispose ();
                lblVersion = null;
            }

            if (tvSections != null) {
                tvSections.Dispose ();
                tvSections = null;
            }

            if (vMenu != null) {
                vMenu.Dispose ();
                vMenu = null;
            }
        }
    }
}