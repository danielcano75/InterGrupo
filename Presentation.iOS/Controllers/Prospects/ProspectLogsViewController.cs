using System;
using System.Collections.Generic;
using Domain.Models;
using Foundation;
using Presentation.iOS._Shared;
using Presentation.iOS.Classes.Controlls.TableView;
using Presentation.iOS.TableView;
using UIKit;

namespace Presentation.iOS.Prospects
{
    public partial class ProspectLogsViewController : BaseViewController
    {
        List<ProspectLogModel> _prospectLogs;

        public ProspectLogsViewController(IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            GetProspectLogs();
        }

        private void GetProspectLogs()
        {
            _prospectLogs = Services.ProspectService.GetProspectLogs();
            ConfigureProspectLogs();
        }

        private void ConfigureProspectLogs()
        {
			tvProspectLogs.RowHeight = UITableView.AutomaticDimension;
			tvProspectLogs.EstimatedRowHeight = 94.0f;

			var dataSource = new TableViewBaseDataSource();

			dataSource.CellCreator -= GetCell;
			dataSource.CellHeight -= GetCellHeightRow;
			dataSource.CellRowInSection -= GetRowInSection;
			dataSource.CellCreator += GetCell;
			dataSource.CellHeight += GetCellHeightRow;
			dataSource.CellRowInSection += GetRowInSection;

			tvProspectLogs.Source = dataSource;
			tvProspectLogs.RegisterNibForCellReuse(ProspectLogViewCell.Nib, ProspectLogViewCell.Key);
			tvProspectLogs.ReloadData();
        }

		private UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (ProspectLogViewCell)tableView.DequeueReusableCell(ProspectLogViewCell.Key, indexPath);

			var model = _prospectLogs[indexPath.Row];

            cell.LblId.Text = model.Id.ToString();
            cell.LblProspectId.Text = model.ProspectId;
            cell.LblName.Text = model.Name;
            cell.LblDate.Text = model.CreationDate.ToString("f");

			return cell;
		}

		private nint GetRowInSection(UITableView tableView, nint section)
		{
			return _prospectLogs.Count;
		}

		private int GetCellHeightRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 94;
		}

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }
    }
}

