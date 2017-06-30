using System;

using Foundation;
using UIKit;

namespace Presentation.iOS.TableView
{
    public partial class ProspectViewCell : UITableViewCell
    {
		public static readonly NSString Key = new NSString("cell");
		public static readonly UINib Nib = UINib.FromName("ProspectViewCell", NSBundle.MainBundle);

		public UILabel LblName
		{
			get
			{
                return this.lblName;
			}
		}
		public UILabel LblLastName
		{
			get
			{
                return this.lblLastName;
			}
		}
		public UILabel LblCitizenshipCard
		{
			get
			{
                return this.lblCitizenshipCard;
			}
		}
		public UILabel LblNumberPhone
		{
			get
			{
                return this.lblNumberPhone;
			}
		}
		public UIImageView ImgStatus
		{
		  get
		  {
                return this.imgStatus;
		  }
		}
        public UILabel LblStatus
		{
			get
			{
				return this.lblStatus;
			}
		}

		public ProspectViewCell(IntPtr handle) : base(handle)
        {
		}

		public static void RegisterToTableView(UITableView tableView)
		{
			tableView.RegisterClassForCellReuse(typeof(ProspectViewCell), ProspectViewCell.Key);
			tableView.RegisterNibForCellReuse(ProspectViewCell.Nib, ProspectViewCell.Key);
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
		}
    }
}
