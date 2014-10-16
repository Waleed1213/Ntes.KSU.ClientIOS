using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using System.Collections.ObjectModel;
using Ntes.KSU.ClientIOS.DataAccess;


namespace Ntes.KSU.ClientIOS
{
	public partial class MasterViewController : UITableViewController
	{
		DataSource dataSource;
		public static ObservableCollection<AlertJson> obs_alerts;
		public MasterViewController (IntPtr handle) : base (handle)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Master", "Master");

			// Custom initialization
		}

		void AddNewItem (object sender, EventArgs args)
		{
			//dataSource.Objects.Insert (0, DateTime.Now);

			using (var indexPath = NSIndexPath.FromRowSection (0, 0))
				TableView.InsertRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Automatic);
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			obs_alerts=CloudConnection.GetAllAlerts();
			DataSource.obs_alerts_I = obs_alerts;
			// Perform any additional setup after loading the view, typically from a nib.
			NavigationItem.LeftBarButtonItem = EditButtonItem;

			var addButton = new UIBarButtonItem (UIBarButtonSystemItem.Add, AddNewItem);
			NavigationItem.RightBarButtonItem = addButton;

			TableView.Source = dataSource = new DataSource (this);
		}

		class DataSource : UITableViewSource
		{
			static readonly NSString CellIdentifier = new NSString ("Cell");
			readonly List<object> objects = new List<object> ();
			string[] URL_arr;
			readonly MasterViewController controller;
			public static ObservableCollection<AlertJson> obs_alerts_I;
			public DataSource (MasterViewController controller)
			{
				URL_arr=new string();

				this.controller=controller;
			}


			// Customize the number of sections in the table view.
			public override int NumberOfSections (UITableView tableView)
			{
				return 1;
			}

			public override int RowsInSection (UITableView tableview, int section)
			{
				return obs_alerts_I.Count;
			}
			public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
			{

				return 100;
			}
			// Customize the appearance of table view cells.
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				//CatagoryCell cell = tableView.DequeueReusableCell (new NSString ("MyCustomViewCell")) as MyCustomViewCell ?? MyCustomViewCell.Create();

				AlertCell cell = tableView.DequeueReusableCell (new NSString ("AlertCell")) as AlertCell ?? AlertCell.Create(); 
				cell.Lbl_AlertTime.Text = obs_alerts_I [indexPath.Row].date_time.ToString ();
				cell.Lbl_InformerName.Text = obs_alerts [indexPath.Row].first_name;
				cell.Lbl_AlertDesc.Text = obs_alerts [indexPath.Row].description;
				//http://graph.facebook.com/857244580967143/picture
				for (int i = 0; i < URL_arr.Length; i++) {
					if (URL_arr [i] == obs_alerts [indexPath.Row].dp) {
						cell.Lbl_AlertDesc.Tag = i;
						break;
					}
				}
				if (cell.Lbl_AlertDesc.Tag == 0) {
					URL_arr[];
				}
				//Facilitator.loadImage (cell.Img_alert_dp);
				cell.Lbl_AlertDesc.LineBreakMode = UILineBreakMode.WordWrap;
				cell.Img_alert_dp.Layer.CornerRadius = 25;
				//controller.TableView.RowHeight = (cell.Lbl_AlertTime.Lines * 10) + 50;
				return cell;
			}

			public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
			{
				// Return false if you do not want the specified item to be editable.
				return true;
			}

			public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
			{
				if (editingStyle == UITableViewCellEditingStyle.Delete) {
					// Delete the row from the data source.
					objects.RemoveAt (indexPath.Row);
					controller.TableView.DeleteRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
				} else if (editingStyle == UITableViewCellEditingStyle.Insert) {
					// Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
				}
			}

			/*
			// Override to support rearranging the table view.
			public override void MoveRow (UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
			{
			}
			*/

			/*
			// Override to support conditional rearranging of the table view.
			public override bool CanMoveRow (UITableView tableView, NSIndexPath indexPath)
			{
				// Return false if you do not want the item to be re-orderable.
				return true;
			}
			*/
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "showDetail") {
				var indexPath = TableView.IndexPathForSelectedRow;
			//	var item = dataSource.Objects [indexPath.Row];

			//	((DetailViewController)segue.DestinationViewController).SetDetailItem (item);
			}
		}
	}
}

