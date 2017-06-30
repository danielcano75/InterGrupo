using System;
using System.Collections.Generic;
using CoreGraphics;
using Domain.Models;
using Presentation.iOS._Shared;
using Presentation.iOS.Classes.Controlls;
using Presentation.iOS.Classes.Controlls.TableView;
using UIKit;

namespace Presentation.iOS.Prospects
{
	public partial class ProspectViewController : BaseViewController
	{
        public ProspectModel Prospect;

        private TextFieldDelegate _txtDelegate;
        private TextViewDelegate _textViewDelegate;
        private List<UITextField> _txtFields;

		public ProspectViewController(IntPtr handle) : base (handle)
        {
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
            this.Title = Prospect.name;
            svProspect.ContentSize = new CGSize(vProspect.Frame.Size.Width, vProspect.Frame.Size.Height);
            ConfigureControlls();
            ConfigureProspect();
		}

        private void ConfigureProspect()
        {
            txtId.Text = Prospect.id;
            txtName.Text = Prospect.name;
            txtLastName.Text = Prospect.surname;
            txtPhoneNumber.Text = Prospect.telephone;
            txtAddress.Text = Prospect.address;
            txtZone.Text = Prospect.zoneCode;
            txtSection.Text = Prospect.sectionCode;
            txtCity.Text = Prospect.cityCode;
            txtNeighborhood.Text = Prospect.neighborhoodCode;
            txvObservation.Text = Prospect.observation;
        }

        private void ConfigureControlls()
        {
            _txtFields = new List<UITextField>() { txtId, txtName, txtLastName, txtPhoneNumber, txtAddress, txtZone, txtSection, txtCity, txtNeighborhood };
            
            _txtDelegate = new TextFieldDelegate();
            _textViewDelegate = new TextViewDelegate();

            _txtDelegate.GetEditingStarted -= TextFieldDidBeginEditing;
            _txtDelegate.GetEditingEnded -= TextFieldDidEndEditing;
            _txtDelegate.GetShouldReturn -= TextFieldShouldReturn;

            _txtDelegate.GetEditingStarted += TextFieldDidBeginEditing;
            _txtDelegate.GetEditingEnded += TextFieldDidEndEditing;
            _txtDelegate.GetShouldReturn += TextFieldShouldReturn;

			_textViewDelegate.GetEditingStarted -= TextFieldDidBeginEditing;
			_textViewDelegate.GetEditingEnded -= TextFieldDidEndEditing;
			_textViewDelegate.GetShouldReturn -= TextViewShouldReturn;

			_textViewDelegate.GetEditingStarted += TextFieldDidBeginEditing;
			_textViewDelegate.GetEditingEnded += TextFieldDidEndEditing;
			_textViewDelegate.GetShouldReturn += TextViewShouldReturn;

            foreach (var txtField in _txtFields)
            {
                txtField.Delegate = _txtDelegate;
            }
            txvObservation.Delegate = _textViewDelegate;

            btnSave.TouchUpInside -= SaveClicked;
            btnSave.TouchUpInside += SaveClicked;
        }

        private void SaveClicked(object sender, EventArgs e)
        {
			foreach (var txtField in _txtFields)
			{
                txtField.ResignFirstResponder();
			}
            txvObservation.ResignFirstResponder();
			Prospect.name = txtName.Text;
			Prospect.surname = txtLastName.Text;
			Prospect.telephone = txtPhoneNumber.Text;
			Prospect.address = txtAddress.Text;
			Prospect.zoneCode = txtZone.Text;
			Prospect.sectionCode = txtSection.Text;
			Prospect.cityCode = txtCity.Text;
			Prospect.neighborhoodCode = txtNeighborhood.Text;
			Prospect.observation = txvObservation.Text;
            try
            {
                using(var loading = new LoadingHUD(this)) 
                {
                    Prospect = Services.ProspectService.UpdateProspect(Prospect);
                    ConfigureProspect();
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.Handle(ex, this);
            }
        }

        public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}

		private bool TextFieldShouldReturn(UITextField textField)
		{
			textField.ResignFirstResponder();
            svProspect.SetContentOffset(new CGPoint(0, 0), true);
			return true;
		}

		private void TextFieldDidEndEditing(UITextField textField)
		{
			svProspect.SetContentOffset(new CGPoint(0, textField.Frame.Location.Y - 60), true);
		}

		private void TextFieldDidBeginEditing(UITextField textField)
		{
			svProspect.SetContentOffset(new CGPoint(0, textField.Frame.Location.Y - 60), true);
		}

		public void TextFieldDidBeginEditing(UITextView textView)
		{
		}

		public void TextFieldDidEndEditing(UITextView textView)
		{
			svProspect.SetContentOffset(new CGPoint(0, textView.Frame.Location.Y - 60), true);
		}

		public bool TextViewShouldReturn(UITextView textView)
		{
			svProspect.SetContentOffset(new CGPoint(0, textView.Frame.Location.Y - 60), true);
			return true;
		}


	}
}

