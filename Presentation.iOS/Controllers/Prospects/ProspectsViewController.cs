using System;
using System.Collections.Generic;
using CoreGraphics;
using Domain.Models;
using Foundation;
using Presentation.iOS._Shared;
using Presentation.iOS.Classes.Controlls;
using Presentation.iOS.Classes.Controlls.TableView;
using Presentation.iOS.TableView;
using UIKit;

namespace Presentation.iOS.Prospects
{
	public partial class ProspectsViewController : BaseViewController
	{
        private ProspectModel _prospect;
        private List<ProspectModel> _prospects;

		public ProspectsViewController(IntPtr handle) : base (handle)
        {
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}

        public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
            SetBarButtonItem();
            SyncProspectsAsync();
		}

        private async void SyncProspectsAsync()
		{
            try
            {
                using (var loading = new LoadingHUD(this)) 
                {
					await Services.ProspectService.GetProspectsAsync();
					_prospects = Services.ProspectService.GetProspects();
					ConfigureProspects();
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.Handle(ex, this);
            }
        }

		private void ConfigureProspects()
		{

			tvProspects.RowHeight = UITableView.AutomaticDimension;
			tvProspects.EstimatedRowHeight = 94.0f;

			var dataSource = new TableViewBaseDataSource();

            dataSource.CellCreator -= GetCell;
			dataSource.CellHeight -= GetCellHeightRow;
			dataSource.CellSelected -= GetCellSelected;
			dataSource.CellRowInSection -= GetRowInSection;
			dataSource.CellCreator += GetCell;
			dataSource.CellHeight += GetCellHeightRow;
			dataSource.CellSelected += GetCellSelected;
			dataSource.CellRowInSection += GetRowInSection;

			tvProspects.Source = dataSource;
            tvProspects.RegisterNibForCellReuse(ProspectViewCell.Nib, ProspectViewCell.Key);
            tvProspects.ReloadData();
		}

		private UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (ProspectViewCell)tableView.DequeueReusableCell(ProspectViewCell.Key, indexPath);

			var model = _prospects[indexPath.Row];

            cell.LblName.Text = model.name;
            cell.LblLastName.Text = model.surname;
            cell.LblCitizenshipCard.Text = model.schProspectIdentification;
            cell.LblNumberPhone.Text = model.telephone;
            cell.ImgStatus.Image = UIImage.FromBundle(model.ImgStatus);
            cell.LblStatus.Text = model.StatusName;
            var statuscolor = model.StatusColor.Split(',');
            cell.LblStatus.TextColor = UIColor.FromRGB(Convert.ToInt32(statuscolor[0]), Convert.ToInt32(statuscolor[1]), Convert.ToInt32(statuscolor[2]));

			return cell;
		}

        private nint GetRowInSection(UITableView tableView, nint section)
        {
            return _prospects.Count;
        }

		private int GetCellHeightRow(UITableView tableView, NSIndexPath indexPath)
		{
            return 94;
		}

        private void GetCellSelected(UITableView tableView, NSIndexPath indexPath)
        {
			_prospect = _prospects[indexPath.Row];
            this.PerformSegue("Prospect", this);
        }

        public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if(segue.Identifier.Equals("Prospect"))
			{
                var prospect = segue.DestinationViewController as ProspectViewController;
				prospect.Prospect = _prospect;
			}
        }
	}
}

