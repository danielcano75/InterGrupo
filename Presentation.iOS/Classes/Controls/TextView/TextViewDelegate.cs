using System;
using UIKit;

namespace Presentation.iOS.Classes.Controlls.TableView
{
	public class TextViewDelegate : UITextViewDelegate
	{

		public delegate void TextViewDidEndEditing(UITextView textView);
		public delegate void TextViewDidBeginEditing(UITextView textView);
		public delegate bool TextViewShouldReturn(UITextView textView);

		public event TextViewDidEndEditing GetEditingEnded;
		public event TextViewDidBeginEditing GetEditingStarted;
		public event TextViewShouldReturn GetShouldReturn;

		public TextViewDelegate()
		{
		}

		public override void EditingEnded(UITextView textView)
		{
			if (GetEditingEnded != null)
			{
				GetEditingEnded(textView);
			}
		}

		public override void EditingStarted(UITextView textView)
		{
			if (GetEditingStarted != null)
			{
				GetEditingStarted(textView);
			}
		}

		public override bool ShouldEndEditing(UITextView textView)
		{
			if (GetShouldReturn != null)
			{
				GetShouldReturn(textView);
			}
			return true;
		}

	}
}

