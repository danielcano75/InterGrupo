using System;

using Foundation;
using UIKit;

namespace Presentation.iOS.TableView
{
	public partial class ProspectLogViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("cell");
		public static readonly UINib Nib = UINib.FromName("ProspectLogViewCell", NSBundle.MainBundle);

		public UILabel LblId
		{
		  get
		  {
                return this.lblId;
		  }
		}
		public UILabel LblProspectId
		{
			get
			{
                return this.lblProspectId;
			}
		}
		public UILabel LblName
		{
			get
			{
                return this.lblName;
			}
		}
		public UILabel LblDate
		{
			get
			{
                return this.lblDate;
			}
		}

		public ProspectLogViewCell(IntPtr handle) : base(handle)
        {
		}

		public static void RegisterToTableView(UITableView tableView)
		{
			tableView.RegisterClassForCellReuse(typeof(ProspectLogViewCell), ProspectLogViewCell.Key);
			tableView.RegisterNibForCellReuse(ProspectLogViewCell.Nib, ProspectLogViewCell.Key);
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
		}
	}
}
