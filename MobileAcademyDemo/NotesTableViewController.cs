using System;
using System.Linq;
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
			TableView.Delegate = new NotesTableViewDelegate(this);
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			this.SetToolbarItems(
				new UIBarButtonItem[]{ new UIBarButtonItem(UIBarButtonSystemItem.Add, _addNote)	}, false);		
		}
			
		private void _addNote(object sender, EventArgs args)
		{
			this.PresentModalViewController(new AddNoteViewController(), true);
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			TableView.ReloadData();
		}
	}
	
	public class NotesDataSource : UITableViewDataSource 
	{
		private IList<Note> _notes;
		
		public NotesDataSource() {
			_notes = DataService.GetInstance.LoadNotes();
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
	
	public class NotesTableViewDelegate : UITableViewDelegate
	{
		NotesTableViewController _controller;
	
		public NotesTableViewDelegate(NotesTableViewController controller) { _controller = controller; }
		
		public override void RowSelected (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.CellAt(indexPath);
			var note = DataService.GetInstance.FindNoteByName(cell.TextLabel.Text);
			_controller.NavigationController.PushViewController(new NoteDetailsViewController(note), true);
		}
	}
}

