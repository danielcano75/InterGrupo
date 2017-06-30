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

namespace Presentation.iOS.Prospects
{
    [Register ("ProspectViewController")]
    partial class ProspectViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSave { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView svProspect { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAddress { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCity { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtId { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtLastName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNeighborhood { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPhoneNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtSection { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtZone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView txvObservation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView vProspect { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnSave != null) {
                btnSave.Dispose ();
                btnSave = null;
            }

            if (svProspect != null) {
                svProspect.Dispose ();
                svProspect = null;
            }

            if (txtAddress != null) {
                txtAddress.Dispose ();
                txtAddress = null;
            }

            if (txtCity != null) {
                txtCity.Dispose ();
                txtCity = null;
            }

            if (txtId != null) {
                txtId.Dispose ();
                txtId = null;
            }

            if (txtLastName != null) {
                txtLastName.Dispose ();
                txtLastName = null;
            }

            if (txtName != null) {
                txtName.Dispose ();
                txtName = null;
            }

            if (txtNeighborhood != null) {
                txtNeighborhood.Dispose ();
                txtNeighborhood = null;
            }

            if (txtPhoneNumber != null) {
                txtPhoneNumber.Dispose ();
                txtPhoneNumber = null;
            }

            if (txtSection != null) {
                txtSection.Dispose ();
                txtSection = null;
            }

            if (txtZone != null) {
                txtZone.Dispose ();
                txtZone = null;
            }

            if (txvObservation != null) {
                txvObservation.Dispose ();
                txvObservation = null;
            }

            if (vProspect != null) {
                vProspect.Dispose ();
                vProspect = null;
            }
        }
    }
}