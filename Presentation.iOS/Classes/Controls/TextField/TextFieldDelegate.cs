using System;
using UIKit;
using Foundation;

namespace Presentation.iOS.Classes.Controlls.TableView
{
	public class TextFieldDelegate : UITextFieldDelegate
	{

		public delegate void TextFieldDidEndEditing (UITextField textField);
		public delegate void TextFieldDidBeginEditing (UITextField textField);
		public delegate bool TextFieldShouldReturn (UITextField textField);
		public delegate bool TextFieldShouldChange (UITextField textField, NSRange range, string replacementString);

		public event TextFieldDidEndEditing GetEditingEnded;
		public event TextFieldDidBeginEditing GetEditingStarted;
		public event TextFieldShouldReturn GetShouldReturn;
		public event TextFieldShouldChange GetShouldChange;

		public TextFieldDelegate ()
		{
		}

		public override  bool ShouldReturn (UITextField textField) {
			textField.ResignFirstResponder ();
			bool rtnbool = GetShouldReturn (textField);
			return true;
		}

		public override void EditingEnded (UITextField textField) {
			if (GetEditingEnded != null) {
				GetEditingEnded (textField);
			}
		}

		public override void EditingStarted (UITextField textField) {
			if (GetEditingStarted != null) {
				GetEditingStarted (textField);
			}
		}

		public override bool ShouldChangeCharacters (UITextField textField, NSRange range, string replacementString)
		{
			if (GetShouldChange != null) {
				bool isChange = GetShouldChange (textField, range, replacementString);
				return isChange;
			}
			return true;
		}

	}
}

