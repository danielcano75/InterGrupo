using System;
using CoreGraphics;
using Domain.Models;
using Presentation.iOS._Shared;
using Presentation.iOS.Classes.Controlls;
using Presentation.iOS.Classes.Controlls.TableView;
using UIKit;

namespace Presentation.iOS.Login
{
	public partial class LoginViewController : BaseViewController
	{

        private TextFieldDelegate _txtDelegate;

		public LoginViewController(IntPtr handle) : base (handle)
        {
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
            ConfigureLogin();
		}

        private void ConfigureLogin()
        {
			txtEmail.Text = string.Empty;
			txtPassword.Text = string.Empty;

            btnLogin.TouchUpInside -= LoginClickedAsync;
            btnLogin.TouchUpInside += LoginClickedAsync;

			_txtDelegate = new TextFieldDelegate();

			_txtDelegate.GetEditingStarted -= TextFieldDidBeginEditing;
			_txtDelegate.GetEditingEnded -= TextFieldDidEndEditing;
			_txtDelegate.GetShouldReturn -= TextFieldShouldReturn;

			_txtDelegate.GetEditingStarted += TextFieldDidBeginEditing;
			_txtDelegate.GetEditingEnded += TextFieldDidEndEditing;
			_txtDelegate.GetShouldReturn += TextFieldShouldReturn;

            txtEmail.Delegate = _txtDelegate;
			txtPassword.Delegate = _txtDelegate;

        }

        private async void  LoginClickedAsync(object sender, EventArgs e)
        {
            txtEmail.ResignFirstResponder();
			txtPassword.ResignFirstResponder();
            try
            {
                using (var loading = new LoadingHUD(this)) 
                {
                    var login = new LoginModel() 
                    {   
                        email = txtEmail.Text,
                        password = txtPassword.Text
                    };
                    var success = await Services.UserService.LoginAsync(login);
                    if (success)
                    {
                        this.PerformSegue("Root", this);
                    }
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
			svLogin.SetContentOffset(new CGPoint(0, 0), true);
			return true;
		}

		private void TextFieldDidEndEditing(UITextField textField)
		{
			svLogin.SetContentOffset(new CGPoint(0, textField.Frame.Location.Y - 120), true);
		}

		private void TextFieldDidBeginEditing(UITextField textField)
		{
			svLogin.SetContentOffset(new CGPoint(0, textField.Frame.Location.Y - 120), true);
		}

	}
}

