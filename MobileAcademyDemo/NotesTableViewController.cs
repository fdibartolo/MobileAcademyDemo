using System;
using MonoTouch.UIKit;

namespace MobileAcademyDemo
{
	public class NotesTableViewController : UITableViewController
	{
		public NotesTableViewController ()
		{
			Title = "My Notes";
			TableView.DataSource = new NotesDataSource();
		}
	}
	
	public class NotesDataSource : UITableViewDataSource 
	{
		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}	
		
		public override int RowsInSection (UITableView tableView, int section)
		{
			return 1;
		}
		
		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var noteId = "noteid";
			var cell = tableView.DequeueReusableCell(noteId);
				
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, noteId);
				cell.Accessory = UITableViewCellAccessory.None;
			}
				
			cell.TextLabel.Text = "Some note";
			return cell;
		}
	}
}

