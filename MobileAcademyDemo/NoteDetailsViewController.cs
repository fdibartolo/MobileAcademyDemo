using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace MobileAcademyDemo
{
	public class NoteDetailsViewController : UIViewController
	{
		UITextField textName = new UITextField(new RectangleF(20,30,280,30));
		UITextField textBody = new UITextField(new RectangleF(20,80,280,300));
		
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
				
			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Save, _saveNote), false);
		}
			
		private void _saveNote(object sender, EventArgs args){
			var note = new Note { Name = textName.Text, Body = textBody.Text };
			DataService.GetInstance.SaveNote(note);
			this.ParentViewController.DismissModalViewControllerAnimated(true);
		}
	}
}

