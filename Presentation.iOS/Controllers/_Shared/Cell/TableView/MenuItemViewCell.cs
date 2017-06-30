using System;

using Foundation;
using UIKit;

namespace Presentation.iOS.TableView
{
	public partial class MenuItemViewCell : UITableViewCell
	{

		public static readonly NSString Key = new NSString("cell");
		public static readonly UINib Nib = UINib.FromName("MenuItemViewCell", NSBundle.MainBundle);

		public UIImageView ImgSection
		{
			get
			{
				return this.imgSection;
			}
		}
		public UILabel LblSection
		{
			get
			{
				return this.lblSection;
			}
		}

		public MenuItemViewCell(IntPtr handle) : base(handle)
		{
		}

		public static void RegisterToTableView(UITableView tableView)
		{
			tableView.RegisterClassForCellReuse(typeof(MenuItemViewCell), MenuItemViewCell.Key);
			tableView.RegisterNibForCellReuse(MenuItemViewCell.Nib, MenuItemViewCell.Key);
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
		}
	}
}
