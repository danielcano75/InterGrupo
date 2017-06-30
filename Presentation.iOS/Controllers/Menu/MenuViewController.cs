using System;
using System.Collections.Generic;
using CoreGraphics;
using Domain.Models;
using Foundation;
using Presentation.iOS._Shared;
using Presentation.iOS.Classes.Controlls.TableView;
using Presentation.iOS.Prospects;
using Presentation.iOS.TableView;
using UIKit;

namespace Presentation.iOS.Menu
{
	public partial class MenuViewController : BaseViewController
	{

		public NavigationViewController NavController;

		private List<SectionModel> _sections;

		public MenuViewController(IntPtr handle) : base (handle)
        {
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}

		public override void ViewWillAppear(bool animated)
		{
			GetSections();
			string version = NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleShortVersionString")].ToString();
			lblVersion.Text = "Versión: " + version;
		}

		private void GetSections()
		{

			_sections = SectionModel.GetAllSections();
            ConfigureSections();

			tvSections.Frame = new CGRect(0, 20, vMenu.Frame.Size.Width, _sections.Count * 65);

		}

        private void ConfigureSections()
        {
			tvSections.RowHeight = UITableView.AutomaticDimension;
			tvSections.EstimatedRowHeight = 65.0f;

			var dataSource = new TableViewBaseDataSource();

			dataSource.CellCreator -= GetCell;
			dataSource.CellSelected -= GetSelected;
			dataSource.CellRowInSection -= GetRowInSection;
			dataSource.CellHeight -= GetCellHeightRow;

			dataSource.CellCreator += GetCell;
			dataSource.CellSelected += GetSelected;
			dataSource.CellRowInSection += GetRowInSection;
			dataSource.CellHeight += GetCellHeightRow;

			tvSections.Source = dataSource;
			tvSections.RegisterNibForCellReuse(MenuItemViewCell.Nib, MenuItemViewCell.Key);
			tvSections.ReloadData();
        }

        private UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
			var cell = (MenuItemViewCell)tableView.DequeueReusableCell(MenuItemViewCell.Key, indexPath);

			var model = _sections[indexPath.Row];

			cell.ImgSection.Image = UIImage.FromBundle(model.ImgName);
			cell.LblSection.Text = model.SectionName;

			return cell;
        }

		private nint GetRowInSection(UITableView tableView, nint section)
		{
			return _sections.Count;
		}

		private int GetCellHeightRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 65;
		}

		private void GetSelected(UITableView tableView, NSIndexPath indexPath)
		{
			var model = (SectionModel)_sections[indexPath.Row];
			if (!model.IdentifierSegue.Equals("Salir"))
			{
				bool animate = false;
				ProspectsViewController prospects = null;
				NavigationViewController navigation = (NavigationViewController)RootViewController.StaticSidebarController.ContentAreaController;
				foreach (UIViewController controller in navigation.ViewControllers)
				{
					if (controller is ProspectsViewController)
					{
						prospects = (ProspectsViewController)controller;
						if (!model.IdentifierSegue.Equals("Prospectos"))
						{
							prospects.PerformSegue(model.IdentifierSegue, prospects);
						}
						else
						{
							animate = true;
							navigation.PopToRootViewController(false);
						}
					}
					else
					{
						var baseC = (BaseViewController)controller;
						baseC.SetHiddenBackButton();
						controller.RemoveFromParentViewController();
					}
				}
				RootViewController.StaticSidebarController.CloseMenu(animate);
			}
			else
			{
				LogoutClicked();
			}
		}

        private void LogoutClicked()
        {
            MessagePopup.ShowMessage(RootViewController.StaticSidebarController, "¿Desea cerrar la sesión?", "CANCELAR", "ACEPTAR", () =>
			{
				Services.UserService.LogOut();
				RootViewController.StaticSidebarController.ToggleMenu();
				NavController.PopToRootViewController(true);
				RootViewController.StaticSidebarController.DismissModalViewController(true);
			});
        }

        public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}
	}
}

