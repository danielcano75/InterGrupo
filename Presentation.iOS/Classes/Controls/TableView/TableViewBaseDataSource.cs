using System;
using Foundation;
using UIKit;

namespace Presentation.iOS.Classes.Controlls.TableView
{
	public class TableViewBaseDataSource : UITableViewSource
	{

		public delegate UITableViewCell CellCreatorHandler(UITableView tableView, NSIndexPath indexPath);
		public delegate int CellHeightHandler(UITableView tableView, NSIndexPath indexPath);
		public delegate void CellRowSelectedHandler(UITableView tableView, NSIndexPath indexPath);
		public delegate int CellSetionsHandler(UITableView tableView);
		public delegate UIView ViewForHeaderHandler(UITableView tableView, nint section);
		public delegate nfloat HeightForHeaderHandler(UITableView tableView, nint section);
		public delegate nint RowInSectionHandler(UITableView tableView, nint section);

		public event CellCreatorHandler CellCreator;
		public event CellHeightHandler CellHeight;
		public event CellRowSelectedHandler CellSelected;
		public event CellSetionsHandler CellSections;
		public event ViewForHeaderHandler ViewForHeader;
		public event HeightForHeaderHandler HeightForHeader;
		public event RowInSectionHandler CellRowInSection;

		public TableViewBaseDataSource()
		{
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			if (CellRowInSection != null)
			{
				return CellRowInSection(tableView, section);
			}
			return 0;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{

			UITableViewCell cell = CellCreator(tableView, indexPath);
			return cell;

		}

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return CellHeight(tableView, indexPath);
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			if (CellSelected != null)
			{
				CellSelected(tableView, indexPath);
			}
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			if (CellSections != null)
			{
				return CellSections(tableView);
			}
			return 1;
		}

		public override UIView GetViewForHeader(UITableView tableView, nint section)
		{
			if (ViewForHeader != null)
			{
				return ViewForHeader(tableView, section);
			}
			return new UIView();
		}

		public override nfloat GetHeightForHeader(UITableView tableView, nint section)
		{
			if (HeightForHeader != null)
			{
				return HeightForHeader(tableView, section);
			}
			return 0.0f;
		}

	}
}

