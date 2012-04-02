using System;
using MonoTouch.UIKit;
using System.Drawing;
using System.Linq;

namespace MobileAcademyDemo
{
	public class AddNoteViewController : UINavigationController
	{
		public AddNoteViewController() : base() {
			this.PushViewController(new NoteDetailsViewController(), true);
		}
		
		public override void ViewWillAppear (bool animated)
		{
			UIViewController firstController= this.ViewControllers.First();
			firstController.NavigationItem.Title = "New Note"; 
			firstController.NavigationItem.SetLeftBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Cancel, _cancelNote), false);
		}
		
		private void _cancelNote(object sender, EventArgs args){
			this.DismissModalViewControllerAnimated(true);
		}	
	}
}

