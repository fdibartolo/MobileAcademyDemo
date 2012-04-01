using System;
using MonoTouch.UIKit;
using System.Collections.Generic;

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
		IList<Note> _notes;
		
		public NotesDataSource() {
			_notes = new NotesStore().Read();
		}
		
		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}	
		
		public override int RowsInSection (UITableView tableView, int section)
		{
			return _notes.Count;
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
				
			cell.TextLabel.Text = _notes[indexPath.Row].Name;
			return cell;
		}
	}
}

