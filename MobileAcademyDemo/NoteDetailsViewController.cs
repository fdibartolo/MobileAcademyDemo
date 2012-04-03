using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace MobileAcademyDemo
{
	public class NoteDetailsViewController : UIViewController
	{
		UITextField textName = new UITextField(new RectangleF(20,30,280,30));
		UITextField textBody = new UITextField(new RectangleF(20,80,280,260));
		Note _note;
		
		public NoteDetailsViewController(Note note) {
			_note = note;		
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			UIView view = new UIView(new RectangleF(0,0,320,396)) { 
				BackgroundColor = UIColor.GroupTableViewBackgroundColor
			};
				
			textName.Placeholder = "your note name";
			textName.BorderStyle = UITextBorderStyle.RoundedRect;
			view.AddSubview(textName);
				
			textBody.Placeholder = "your note body";
			textBody.BorderStyle = UITextBorderStyle.RoundedRect;
			view.AddSubview(textBody);
				
			this.View.AddSubview(view);
				
			if (_isUpdateMode()) {
				this.NavigationItem.SetRightBarButtonItem(
					new UIBarButtonItem("Update", UIBarButtonItemStyle.Bordered, _updateNote), false);
			
				SetToolbarItems(new UIBarButtonItem[]{
					new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null),
					new UIBarButtonItem(UIBarButtonSystemItem.Trash, _deleteNote)	
				}, false);
			}
			else
				this.NavigationItem.SetRightBarButtonItem(
					new UIBarButtonItem(UIBarButtonSystemItem.Save, _saveNote), false);
		}
			
		private void _saveNote(object sender, EventArgs args){
			_note.Name = textName.Text;
			_note.Body = textBody.Text;
			DataService.GetInstance.SaveNote(_note);
			this.ParentViewController.DismissModalViewControllerAnimated(true);
		}
		
		private void _updateNote(object sender, EventArgs args){
			_note.Name = textName.Text;
			_note.Body = textBody.Text;
			DataService.GetInstance.SaveNote(_note);
			this.NavigationController.PopToRootViewController(true);
		}
		
		private void _deleteNote(object sender, EventArgs args){
			DataService.GetInstance.DeleteNote(_note);
			this.NavigationController.PopToRootViewController(true);
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			Title = (_isUpdateMode()) 
				? "Edit Note" 
				: "New Note";
			textName.Text = _note.Name;
			textBody.Text = _note.Body;
		}
		
		private bool _isUpdateMode(){
			return (_note.Id.HasValue);
		}
	}
}

